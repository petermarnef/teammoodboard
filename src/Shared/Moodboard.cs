using System;
using System.Collections.Generic;

namespace MoodBoard.Shared;

public record Option(int Id, string Emoji); 
public record Topic(int Id, string Name);
public record Configuration(IList<Topic> Topics, IList<Option> Options);
public record Vote(Guid ClientSessionId, int TopicId, int OptionId);

public class Moodboard
{
    public Guid Id { get; init; }
    public Configuration Configuration { get; init; }
    public IList<Vote> Votes { get; init; }

    public static Moodboard Initialise(Guid moodboardId)
    {
        return new Moodboard {
        Id = moodboardId,
        Configuration = new Configuration( 
            new List<Topic> {
            new Topic(1, "Team"),
            new Topic(2, "Process"),
            new Topic(3, "End Result"),
            new Topic(4, "How I Felt")
        },
            new List<Option> {
            new Option(1, "ð"),
            new Option(2, "ð"),
            new Option(3, "ðĨ")
            // new Option(4, "ðĪŠ")
        }),
        Votes = new List<Vote>()
        };
    }
}
