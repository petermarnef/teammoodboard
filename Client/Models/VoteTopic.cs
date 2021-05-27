using System.Collections.Generic;

namespace MoodBoard.Models
{
    public record VoteOption(int Id, string Emoji);
    public record VoteTopic(string Name, List<VoteOption> VoteOptions);    
}