using System;

namespace MoodBoard.Shared
{
    public record Vote(Guid moodboardId, Guid subjectId, Guid voteId);
}