using System;
using System.Collections.Generic;

namespace MoodBoard.Shared
{
    public record Vote(Guid MoodboardId, int VoteId);
    public record VoteOption(int Id, string Emoji);
    public record VoteTopic(string Name, List<VoteOption> VoteOptions);    
}