using System;
using System.Collections.Generic;
using MoodBoard.Shared;

namespace MoodBoard.Server.State
{
    public class VoteState {
        private List<Vote> votes = new List<Vote>();

        public void AddVote(Vote vote) {
            votes.Add(vote);
        }

        public List<Vote> GetVotes() {
            return votes;
        }
    }
}