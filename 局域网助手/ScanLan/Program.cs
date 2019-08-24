﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ScanLan
{
    static class Program
    {
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
            Application.Run(new FrmMain());
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