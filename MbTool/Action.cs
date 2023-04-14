using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MbTool
{
    public class Action
    {
        public void ADBClick(string id, int x, int y)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = string.Format(@"/c cd C:\scrcpy-win64-v2.0\ && adb -s {0} shell input tap {1} {2}", id, x, y),
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden,
                Verb = "runas"
            };

            Process.Start(startInfo);
        }
        
        public int clickcount = 0, clickcountmax;
        int x = 250; int y;

        public void Clickk(string id)
        {
            ADBClick(id, x, y);
            y += 42;
            clickcount++;
            if (clickcount == clickcountmax)
            {
                clickcount = 0;
                y -= clickcountmax * 42;
            }
        }

        Random rd = new Random();
        const uint WM_LBUTTONDOWN = 0x0201;
        const uint WM_LBUTTONUP = 0x0202;
        const uint WM_RBUTTONDOWN = 0x0204;
        const uint WM_RBUTTONUP = 0x0205;
        const uint WM_CHAR = 0x0102;
        const uint WM_KEYDOWN = 0x0100;
        const uint WM_MOUSEWHEEL = 0X020A;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool PostMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

        private static int MakeLParam(int LoWord, int HiWord) { return (int)((HiWord << 16) | (LoWord & 0xffff)); }

        internal static IntPtr MAKEWPARAM(int direction, float multiplier, uint button)
        {
            int delta = (int)(SystemInformation.MouseWheelScrollDelta * multiplier);
            return (IntPtr)(((delta << 16) * Math.Sign(direction) | (ushort)button));
        }

        // Click
        public void Click(PhoneModel phone, int x, int y)
        {

            int tempx = rd.Next(-15, 15);
            int tempy = rd.Next(-2, 2);
            int tempPos = MakeLParam(x /*tempx*/, y /*tempy*/);
            //Win32.SendMessage((int)getProcess, Win32.WM_LBUTTONDOWN, 0x00000001, tempPos);
            //Win32.SendMessage((int)getProcess, Win32.WM_LBUTTONUP, 0x00000000, tempPos);
            SendMessage(phone.Process.MainWindowHandle, WM_LBUTTONDOWN, 0x00000001, tempPos);
            SendMessage(phone.Process.MainWindowHandle, WM_LBUTTONUP, 0x00000000, tempPos);
        }
        // ScrollDown
        public struct Rect
        {
            public int Left { get; set; }
            public int Top { get; set; }
            public int Right { get; set; }
            public int Bottom { get; set; }
        }

        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hwnd, ref Rect rectangle);
        private void ScrollDown(PhoneModel phone, int x, int y)
        {
            Rect rect = new Rect();
            GetWindowRect(phone.Process.MainWindowHandle, ref rect);
            int xx = rect.Left;
            int yy = rect.Top;
            int directionDown = -1;

            // Scrolls [Handle] down by 1/2 wheel rotation with Left Button pressed
            IntPtr wParam = MAKEWPARAM(directionDown, .9f, 0x0001);
            IntPtr lParam = (IntPtr)MakeLParam(xx + x, yy + y);

            PostMessage(phone.Process.MainWindowHandle, WM_MOUSEWHEEL, (int)wParam, (int)lParam);
        }
    }
}
