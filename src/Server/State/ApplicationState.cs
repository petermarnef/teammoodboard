using System;
using System.Collections.Generic;
using System.Linq;
using MoodBoard.Shared;

namespace MoodBoard.Server.State
{
    public class ApplicationState {
        private const int NotFoundIndexValue = -1;
        private List<Moodboard> moodboards = new List<Moodboard>();

        public void SaveMoodboard(Moodboard moodboard) {
            var moodboardIndex = moodboards
                .FindIndex(moodboard => moodboard.Id == moodboard.Id);

            if (moodboardIndex == NotFoundIndexValue)
                moodboards.Add(moodboard);
            else
                moodboards[moodboardIndex] = moodboard;
        }

        public Moodboard GetMoodboard(Guid moodboardId)
        {
            return moodboards
                .Where(moodboard => moodboard.Id == moodboardId)
                .SingleOrDefault();
        }
    }
}