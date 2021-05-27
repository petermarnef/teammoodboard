using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using MoodBoard.Server.State;
using MoodBoard.Shared;

namespace MoodBoard.Server.Hubs
{
    public class VoteHub : Hub
    {
        private VoteState voteState;

        public VoteHub(VoteState voteState)
        {
            this.voteState = voteState;
        }

        public async Task Vote(Guid moodboardId, Guid topicId, Guid voteId)
        {
            voteState.AddVote(new Vote(moodboardId, topicId, voteId));
            await UpdateAllClients();
        }

        public async Task UpdateAllClients() => 
            await Clients.All.SendAsync(VoteHubAction.ReceiveVotes, voteState.GetVotes());
    }
}