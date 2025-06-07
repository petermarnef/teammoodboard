using System;
using System.Collections.Generic;

namespace MoodBoard.Shared;

public record Option(int Id, string Emoji, string Text); 
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
            new Topic(4, "How I Feel")
        },
            new List<Option> {
            new Option(1, "😍", "Loving it"),
            new Option(2, "🙂", "Great"),
            new Option(3, "💪🏻", "Motivated"),
            new Option(4, "😏", "It's okay"),
            new Option(5, "💩", "Meh"),
            new Option(6, "☝🏻", "Need to talk")
            }),
        Votes = new List<Vote>()
        };
    }
}
