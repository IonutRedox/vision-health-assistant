using System;
using System.Runtime.InteropServices;

namespace VisionHealthAssistant.UI.Helper
{
    public static class UserIdleHelper
    {
        [DllImport("user32.dll")]
        private static extern bool GetLastInputInfo(ref LastInputInfo plii);

        /// <summary>
        /// Gets the idle time in seconds.
        /// </summary>
        /// <returns></returns>
        public static uint GetLastInputTime()
        {
            uint idleTime = 0;
            LastInputInfo lastInputInfo = new LastInputInfo();
            lastInputInfo.cbSize = (uint)Marshal.SizeOf(lastInputInfo);
            lastInputInfo.dwTime = 0;

            uint envTicks = (uint)Environment.TickCount;

            if(GetLastInputInfo(ref lastInputInfo)) {
                uint lastInputTick = lastInputInfo.dwTime;
                idleTime = envTicks - lastInputTick;
            }

            return (idleTime > 0) ? (idleTime / 1000) : 0;
        }
    }
}
