using System;
using System.Drawing;
using System.Runtime.InteropServices;


namespace CoHNotAlwaysOnTop
{
    class CoHNotAlwaysOnTop
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("USER32.DLL")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        
        [DllImport("USER32.DLL")]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("gdi32.dll")]
        static extern int GetDeviceCaps(IntPtr hdc, int nIndex);

        public static int GWL_STYLE = -16;

        //WS_MAXIMIZEBOX WS_MINIMIZEBOX WS_THICKFRAME WS_SYSMENU WS_DLGFRAME WS_BORDER
        public static int WS_MAXIMIZEBOX = 0x00010000;
        public static int WS_MINIMIZEBOX = 0x00020000;
        public static int WS_THICKFRAME = 0x00040000;
        public static int WS_SYSMENU = 0x00080000;
        public static int WS_DLGFRAME = 0x00400000;
        public static int WS_BORDER = 0x00800000;

        public static int STYLES = ~(WS_MAXIMIZEBOX | WS_MINIMIZEBOX | WS_THICKFRAME | WS_SYSMENU | WS_DLGFRAME | WS_BORDER);

        public enum DeviceCap
        {
            HORZSIZE = 4,
            VERTSIZE = 6,
            HORZRES = 8,
            VERTRES = 10,
            DESKTOPVERTRES = 117,
            DESKTOPHORZRES = 118

            // http://pinvoke.net/default.aspx/gdi32/GetDeviceCaps.html
        }


        static void Main(string[] args) {
            var cohWindow = FindWindow("CrypticWindow", null);
            var currentStyle = GetWindowLong(cohWindow, GWL_STYLE);
            SetWindowLong(cohWindow, GWL_STYLE, currentStyle & STYLES);

            Graphics g = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr desktop = g.GetHdc();
            
            int w = GetDeviceCaps(desktop, (int)DeviceCap.DESKTOPHORZRES);
            int h = GetDeviceCaps(desktop, (int)DeviceCap.DESKTOPVERTRES);

            MoveWindow(cohWindow, 0, 0, w + 1, h, true);


            g.ReleaseHdc(desktop);
            g.Dispose();


        }
    }
}
