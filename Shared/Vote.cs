using System;

namespace MoodBoard.Shared
{
    public record Vote(Guid moodboardId, Guid topicId, Guid voteId);
}