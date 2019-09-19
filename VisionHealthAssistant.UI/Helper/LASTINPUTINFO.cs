using System;
using System.Runtime.InteropServices;

namespace VisionHealthAssistant.UI.Helper
{
    [StructLayout(LayoutKind.Sequential)]
    public struct LastInputInfo
    {
        public static readonly int SizeOf = Marshal.SizeOf(typeof(LastInputInfo));

        [MarshalAs(UnmanagedType.U4)]
        public uint cbSize;
        [MarshalAs(UnmanagedType.U4)]
        public uint dwTime;
    }
}
