using System;

namespace MoodBoard.Shared
{
    public record Vote(Guid MoodboardId, int VoteId);
}