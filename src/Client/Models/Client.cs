using System;
using MoodBoard.Shared;
using Microsoft.AspNetCore.SignalR.Client;

namespace MoodBoard.Models
{
  public record Client
  {
    public Guid SessionId { get; init; }
    public bool Initialised { get; set; }
    public Moodboard Moodboard { get; set; }
    public HubConnection HubConnection { get; set; }
  }
}