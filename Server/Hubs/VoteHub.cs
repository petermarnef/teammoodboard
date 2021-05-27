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

        public async Task Vote(string moodboardId, Guid topicId, Guid voteId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, moodboardId);
            voteState.AddVote(new Vote(moodboardId, topicId, voteId));
            await UpdateAllClients(moodboardId);
        }

        public async Task UpdateAllClients(string moodboardId) {
            await Groups.AddToGroupAsync(Context.ConnectionId, moodboardId);
            await Clients.Group(moodboardId).SendAsync("ReceiveVotes", 
                voteState.GetVotes().Where(vote => vote.moodboardId.ToLower().Equals(moodboardId.ToLower())));
        }
    }
}