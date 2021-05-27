using System;

namespace MoodBoard.Shared
{
    public struct VoteHubAction
    {
        public const string ReceiveVotes = "ReceiveVotes";
        public const string UpdateAllClients = "UpdateAllClients";
        public const string Vote = "Vote";
    }
}