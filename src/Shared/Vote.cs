using System;

namespace MoodBoard.Shared
{
    public record Vote(Guid MoodboardId, int topicId, int VoteId, Guid sessionId);
}