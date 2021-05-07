using System;
using System.Collections.Generic;
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

        public async Task Vote(Guid moodboardId, Guid subjectId, Guid voteId)
        {
            voteState.AddVote(new Vote(moodboardId, subjectId, voteId));
            await Clients.All.SendAsync("ReceiveVotes", voteState.GetVotes());
        }
    }
}