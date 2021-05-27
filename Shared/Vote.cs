using System;

namespace MoodBoard.Shared
{
    public record Vote(string moodboardId, Guid topicId, Guid voteId);
}