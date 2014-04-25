using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MessageHelper
{
    public class MessageHelper
    {
        public const int WM_DOWNLOAD_COMPLETED = 0x00AA;
        public const int WM_COPYDATA = 0x004A;

        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        public static extern int SendMessage(IntPtr wnd, int msg, int wP, ref DataStruct.DataStruct cds);
    }
}
