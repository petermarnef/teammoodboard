using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using MoodBoard.Server.State;
using MoodBoard.Shared;

namespace MoodBoard.Server.Hubs
{
    public class MoodboardHub : Hub
    {
        private ApplicationState applicationState;

        public MoodboardHub(ApplicationState applicationState)
        {
            this.applicationState = applicationState;
        }

        public async Task<Moodboard> RegisterNewClient(Guid moodboardId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, moodboardId.ToString());
            return InitialiseMoodboard(moodboardId);
        }

        public async Task ProcessUpdatedMoodboard(Moodboard moodboard)
        {
            applicationState.SaveMoodboard(moodboard);
            await UpdateAllClients(moodboard.Id);
        }

        public async Task UpdateAllClients(Guid moodboardId)
        {
            var moodboard = applicationState.GetMoodboard(moodboardId);
            await Clients.Group(moodboardId.ToString()).SendAsync("MoodboardUpdate", moodboard);
        }

        private Moodboard InitialiseMoodboard(Guid moodboardId)
        {
            var existingMoodboard = applicationState.GetMoodboard(moodboardId);

            if (existingMoodboard == null)
                return Moodboard.Initialise(moodboardId);
            else
                return existingMoodboard;
        }
    }
}