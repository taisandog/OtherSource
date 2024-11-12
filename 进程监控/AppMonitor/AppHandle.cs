using Buffalo.ArgCommon;
using Buffalo.Kernel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AppMonitor
{
    public class AppHandle
    {
        public static long RestartMemory = AppSetting.Default["App.RestartMemory"].ConvertTo<long>();
        public static long MBValue = 1024*1024;
        /// <summary>
        /// 重启标记
        /// </summary>
        private const int AppCommand = 0x500;
        /// <summary>
        /// 发送消息到指定窗口
        /// </summary>
        /// <param name="hWnd">其窗口程序将接收消息的窗口的句柄。如果此参数为HWND_BROADCAST，则消息将被发送到系统中所有顶层窗口，
        /// 包括无效或不可见的非自身拥有的窗口、被覆盖的窗口和弹出式窗口，但消息不被发送到子窗口</param>
        /// <param name="msg">指定被发送的消息</param>
        /// <param name="wParam">指定附加的消息指定信息</param>
        /// <param name="lParam">指定附加的消息指定信息</param>
        /// <returns></returns>
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern IntPtr SendMessage(int hWnd, int msg, IntPtr wParam, IntPtr lParam);//窗口句柄

        /// <summary>
        /// 发送重启命令
        /// </summary>
        /// <param name="process"></param>
        /// <returns></returns>
        public static APIResault SendRestart(Process process) 
        {
            int handle = (int)process.MainWindowHandle;
            long result = SendMessage(handle, AppCommand, new IntPtr(1), new IntPtr(1)).ToInt64();

            return ApiCommon.GetSuccess();
        }
    }
}
