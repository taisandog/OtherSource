using System.Net;

namespace AppMonitor
{
    internal static class Program
    {
        private static FrmMain _mainForm;
        /// <summary>
        /// Ö÷´°Ìå
        /// </summary>
        public static FrmMain MainForm
        {
            get { return Program._mainForm; }
        }

        private static bool _autoRun = false;
        public static bool AutoRun
        {
            get
            {
                return _autoRun;
            }
        }
        public static System.Threading.Mutex LockMutex;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.ThreadException += Application_ThreadException;
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            bool canRun = false;
            string AppCode = "App.AppMonitor";
            LockMutex = new System.Threading.Mutex(true, AppCode, out canRun);
            if (!canRun)
            {
                return;
            }

            try
            {

                _autoRun = IsAuto(args);

                using (_mainForm = new FrmMain())
                {
                    Application.Run(_mainForm);
                }

            }
            finally
            {
                LockMutex.Dispose();
            }
        }

        private static bool IsAuto(string[] args) 
        {
            if (args.Length >0) 
            {
                args[0] = "auro";
                return true;
            }
            return false;
        }
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                _mainForm.LogError((e.ExceptionObject as Exception).ToString());
            }
            catch { }
        }
        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            try
            {
                _mainForm.LogError(e.Exception.ToString());
            }
            catch { }
        }
    }
}