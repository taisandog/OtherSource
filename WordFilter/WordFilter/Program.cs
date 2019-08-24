using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WordFilter
{
    static class Program
    {
        private static FrmMain _mainForm;
        /// <summary>
        /// 主窗体
        /// </summary>
        public static FrmMain MainForm
        {
            get { return Program._mainForm; }
        }
        
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            bool flag = false;
            using (System.Threading.Mutex mutex = new System.Threading.Mutex(true, "Buffalo.Demo.WordFilter", out flag))
            {
                if (!flag) 
                {
                    MessageBox.Show("已经有一个本程序在运行", "Buffalo.WordFilter", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (_mainForm = new FrmMain())
                {
                    Application.Run(_mainForm);
                }
            }
        }
    }
}