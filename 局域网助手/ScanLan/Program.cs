using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ScanLan
{
    static class Program
    {
        private static bool _autoRun = false;
        public static bool AutoRun
        {
            get
            {
                return _autoRun;
            }
        }
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (DoWakeOn(args))
            {
                return;
            }
            _autoRun = ISAutoRun(args);
            bool canRun = false;
            using (System.Threading.Mutex mutex = new System.Threading.Mutex(true, "Buffalo.ScanLan", out canRun))
            {
                if ( !canRun)
                {
                    System.Windows.Forms.MessageBox.Show("已经启动了一个局域网扫描的实例");
                    return;
                }

                Application.Run(new FrmMain());

            }
        }

        // <summary>
        /// 是否自动启动
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        private static bool ISAutoRun(string[] args)
        {
            foreach (string arg in args)
            {
                if (string.Equals(arg, "auto", StringComparison.CurrentCultureIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 命令行网络唤醒功能
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        private static bool DoWakeOn(string[] args)
        {
            if(args==null || args.Length < 2)
            {
                return false;
            }
            if (!string.Equals(args[0], "-wakeon", StringComparison.CurrentCultureIgnoreCase))
            {
                return false;
            }

            long mac = 0;
            if(!long.TryParse(args[1],out mac))
            {
                return false;
            }
            LanMachine machine = new LanMachine();
            machine.Mac = new MacInfo(mac);
            machine.WakeOnLan();
            return true;
        }
    }
}