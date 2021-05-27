using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using MoodBoard.Server.State;
using MoodBoard.Shared;
using System.Linq;

namespace MoodBoard.Server.Hubs
{
    public class VoteHub : Hub
    {
        private VoteState voteState;

        public VoteHub(VoteState voteState)
        {
            this.voteState = voteState;
        }

        public Task AddClientToMoodboard(string moodboardId) =>
            Groups.AddToGroupAsync(Context.ConnectionId, moodboardId);

        public async Task ProcessNewVote(string moodboardId, VoteType voteType)
        {
            voteState.AddVote(new Vote(moodboardId, voteType));
            await SendUpdateToAllClientsForMoodboard(moodboardId);
        }

        public async Task SendUpdateToAllClientsForMoodboard(string moodboardId) {
            await Clients.Group(moodboardId).SendAsync("ReceiveVotes", 
                voteState.GetVotes().Where(vote => vote.moodboardId.ToLower().Equals(moodboardId.ToLower())));
        }
    }
}