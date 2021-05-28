using System;
using System.Collections.Generic;
using System.Linq;
using MoodBoard.Shared;

namespace MoodBoard.Server.State
{
    public class VoteState {
        private List<Vote> votes = new List<Vote>();

        public void AddVote(Vote vote) {
            RemoveDuplicateTopicVote(vote);
            votes.Add(vote);
        }

        public List<Vote> GetVotes() {
            return votes;
        }

        void RemoveDuplicateTopicVote(Vote newVote)
        {
            var votesToRemove = votes.Where(vote => 
                vote.MoodboardId == newVote.MoodboardId
                && vote.topicId == newVote.topicId
                && vote.sessionId == newVote.sessionId)
                .ToList();

            if (votesToRemove != null && votesToRemove.Count() > 0)
                votesToRemove.ForEach(voteToRemove => votes.Remove(voteToRemove));
        }
    }
}