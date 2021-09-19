using System;
using System.Collections.Generic;
using System.Linq;
using MoodBoard.Shared;

namespace MoodBoard.Server.State
{
    public class ApplicationState {
        private const int NotFoundIndexValue = -1;
        private List<Moodboard> moodboards = new List<Moodboard>();

        public void SaveMoodboard(Moodboard newMoodboard) {
            var moodboardIndex = moodboards
                .FindIndex(moodboard => moodboard.Id == newMoodboard.Id);

            if (moodboardIndex == NotFoundIndexValue)
                moodboards.Add(newMoodboard);
            else
                moodboards[moodboardIndex] = newMoodboard;
        }

        public Moodboard GetMoodboard(Guid moodboardId)
        {
            return moodboards
                .Where(moodboard => moodboard.Id == moodboardId)
                .SingleOrDefault();
        }
    }
}