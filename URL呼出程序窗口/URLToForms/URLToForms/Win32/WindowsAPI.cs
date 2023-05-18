using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;


namespace Buffalo.Win32Kernel.Win32
{
  /// <summary>
  /// Windows API Functions
  /// </summary>
    public class WindowsAPI
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static public extern IntPtr FindWindowEx(IntPtr hWnd, IntPtr hChild, string strClassName, string strName);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static public extern IntPtr FindWindowEx(IntPtr hWnd, IntPtr hChild, string strClassName, IntPtr strName);
        [DllImport("User32.dll ", EntryPoint = "FindWindow")]
        public static extern IntPtr FindWindow(string lpClassName,string lpWindowName);   
        [DllImport("user32.dll", CharSet = CharSet.Auto)]

        public static extern IntPtr SendMessage(IntPtr hWnd, Msg msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, Msg msg, ref int wParam, ref int lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hWnd, Msg msg, int wParam, int lParam);
        
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, Msg msg, int wParam, IntPtr lParam);
       
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hWnd, Msg msg, int wParam, ref COPYDATASTRUCT lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessageW(IntPtr hWnd, Msg msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessageW(IntPtr hWnd, Msg msg, ref int wParam, ref int lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessageW(IntPtr hWnd, Msg msg, int wParam, int lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessageW(IntPtr hWnd, Msg msg, int wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessageW(IntPtr hWnd, Msg msg, int wParam, ref COPYDATASTRUCT lParam);
    }
}
