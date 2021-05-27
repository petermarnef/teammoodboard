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

        public Task AddClientToMoodboard(Guid moodboardId) =>
            Groups.AddToGroupAsync(Context.ConnectionId, moodboardId.ToString());

        public async Task ProcessNewVote(Guid moodboardId, int voteId)
        {
            voteState.AddVote(new Vote(moodboardId, voteId));
            await SendUpdateToAllClientsForMoodboard(moodboardId);
        }

        public async Task SendUpdateToAllClientsForMoodboard(Guid moodboardId) {
            await Clients.Group(moodboardId.ToString()).SendAsync("ReceiveVotes", 
                voteState.GetVotes().Where(vote => vote.MoodboardId.ToString().ToLower().Equals(moodboardId.ToString().ToLower())));
        }
    }
}