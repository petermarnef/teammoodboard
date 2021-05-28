using System.Collections.Generic;

namespace MoodBoard.Models
{
    public record VoteOption(int Id, string Emoji);
    public record VoteTopic(int Id, string Name, List<VoteOption> VoteOptions);    
}