using System;

namespace MoodBoard.Shared
{
    public record Vote(Guid moodboardId, VoteType voteType);

    public enum VoteType
    {
        TeamHappy = 1,
        TeamMeh = 2,
        TeamSad = 3,
        ProcessHappy = 4,
        ProcessMeh = 5,
        ProcessSad = 6,
        EndResultHappy = 7,
        EndResultMeh = 8,
        EndResultSad = 9
    }
}