using System;

namespace VisionHealthAssistant.UI.Helper
{
    public static class BreakTimerHelper
    {
        /// <summary>
        /// Gets the time formated hh:mm:ss from seconds.
        /// </summary>
        /// <returns></returns>
        public static string GetFormattedTimeFromSeconds(int seconds)
        {
            return TimeSpan.FromSeconds(seconds).ToString(@"hh\:mm\:ss");
        }

        /// <summary>
        /// Gets the time formated hh:mm:ss from minutes.
        /// </summary>
        /// <returns></returns>
        public static string GetFormattedTimeFromMinutes(int minutes)
        {
            return TimeSpan.FromMinutes(minutes).ToString(@"hh\:mm\:ss");
        }

    }
}
