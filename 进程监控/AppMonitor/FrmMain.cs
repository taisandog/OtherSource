using Buffalo.ArgCommon;
using Buffalo.Kernel.TreadPoolManager;
using GameDaemon;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace AppMonitor
{
    public partial class FrmMain : Form, IShowMessage
    {
        public FrmMain()
        {
            InitializeComponent();
        }


        /// <summary>
        /// ���ӷ������߳�
        /// </summary>
        private BlockThread ConnectThread;

        /// <summary>
        /// ���Dump���߳�
        /// </summary>
        private BlockThread DumpThread;

        private bool _isRunning = false;
        /// <summary>
        /// ���ñ���
        /// </summary>
        private void SetTitle()
        {
            this.Text = string.Format("���̼��(v.{0})", this.GetType().Assembly.GetName().Version.ToString());
        }


        public bool ShowLog
        {
            get
            {
                return mbDisplay.ShowLog;
            }
        }

        public bool ShowError
        {
            get
            {
                return mbDisplay.ShowError;
            }
        }

        public bool ShowWarning
        {
            get
            {
                return mbDisplay.ShowWarning;
            }
        }
        public void Log(string message)
        {

            mbDisplay.Log(message);
        }
        public void LogError(string message)
        {
            mbDisplay.LogError(message);
        }
        public void LogWarning(string message)
        {
            mbDisplay.LogWarning(message);
        }


        private ProcessManager _proManager;
        private void BtnTest_Click(object sender, EventArgs e)
        {

            _lastCheckProcess = DateTime.MinValue;
            //CheckProcess(true);
        }

        private double _refreashSeconds = 60;
        private DateTime _lastCheckProcess = DateTime.MinValue;
        /// <summary>
        /// ������
        /// </summary>
        /// <param name="force">ǿ��ˢ��</param>
        private void CheckProcess(bool force)
        {


            double curSec = DateTime.Now.Subtract(_lastCheckProcess).TotalSeconds;
            double num = _refreashSeconds - curSec;
            if (num < 0)
            {
                num = 0;
            }
            try
            {
                if (!force && curSec < _refreashSeconds)
                {

                    _proManager.CheckCPURestart();

                    return;
                }
            }
            catch (Exception ex)
            {
                LogError(ex.ToString());
            }
            try
            {


                lock (_proManager)
                {
                    _proManager.RefreashProcess(this);

                    this.Invoke((EventHandler)delegate
                    {
                        dgView.Refresh();
                        labLast.Text = DateTime.Now.ToString();
                    });
                }


            }
            catch (Exception ex)
            {
                LogError(ex.ToString());
            }
            finally
            {
                _lastCheckProcess = DateTime.Now;

            }
        }



        private DateTime _lastGC = DateTime.MinValue;
        private const long RestartMemory = 400L * 1024L * 1024L;//400M������

        private DateTime _lastDump = DateTime.MinValue;
        /// <summary>
        /// ����ڴ�ռ�
        /// </summary>
        private void CheckMemory()
        {
            DateTime lastRun = DateTime.MinValue;
            while (_isRunning)
            {
                try
                {
                    DateTime nowDate = DateTime.Now;
                    if (nowDate.Subtract(lastRun).TotalMilliseconds >= 5000)
                    {
                        CheckProcess(false);
                        lastRun = nowDate;
                    }



                }
                catch (Exception ex)
                {
                    LogError(ex.ToString());
                }
                finally
                {
                    Thread.Sleep(200);
                }
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            dgView.AutoGenerateColumns = false;
            _proManager = new ProcessManager(this);
            _proManager.Init();
            SetTitle();

            mbDisplay.ShowError = true;
            mbDisplay.ShowWarning = true;
            mbDisplay.ShowLog = false;
            SetConnEnable(true);

            nupMemory.Maximum = int.MaxValue;
            nupMemory.Value = AppHandle.RestartMemory / AppHandle.MBValue;

            if (Program.AutoRun)
            {
                Btn_Connect.PerformClick();
            }
        }
        private void Btn_Disconnect_Click(object sender, EventArgs e)
        {
            StopServer();
        }
        private void Btn_Connect_Click(object sender, EventArgs e)
        {
            _isRunning = true;
            LogWarning("�û����Ӽ��������ɹ�");
            AppHandle.RestartMemory = (long)nupMemory.Value * AppHandle.MBValue;
            dgView.DataSource = null;
            dgView.DataSource = _proManager;
            SetConnEnable(false);
            ConnectThread = BlockThread.Create(CheckMemory);



            _refreashSeconds = (double)nupSecond.Value;
            if (_refreashSeconds < 1)
            {
                _refreashSeconds = 10;
            }
            ConnectThread.StartThread();
        }
        /// <summary>
        /// ���ÿ�����ť������
        /// </summary>
        /// <param name="enable"></param>
        public void SetConnEnable(bool enable)
        {
            Btn_Connect.Enabled = enable;
            Btn_Disconnect.Enabled = !enable;
            btnTest.Enabled = !enable;
            nupMemory.Enabled = enable;
            nupSecond.Enabled = enable;
        }
        public void StopServer()
        {
            _isRunning = false;
            SetConnEnable(true);
            if (ConnectThread != null)
            {

                try
                {
                    ConnectThread.StopThread();
                }
                catch { }

                ConnectThread = null;
                Thread.Sleep(200);
            }




            LogWarning("�ر�����");
        }

        private void DgView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dg = sender as DataGridView;
            if (dg == null)
            {
                return;
            }
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            string colName = dg.Columns[e.ColumnIndex].Name;
            ProcessItem data = dg.Rows[e.RowIndex].DataBoundItem as ProcessItem;
            if (data == null)
            {
                return;
            }
            APIResault res = null;
            if (string.Equals(colName, "ColStart", StringComparison.OrdinalIgnoreCase))
            {
                res = data.StartProcess();
                if (!res.IsSuccess)
                {
                    LogError(res.Message);
                }
                return;
            }
            if (string.Equals(colName, "ColRestart", StringComparison.OrdinalIgnoreCase))
            {
                res = data.SendRestart();
                if (!res.IsSuccess)
                {
                    LogError(res.Message);
                }
                return;
            }
            if (string.Equals(colName, "ColDir", StringComparison.OrdinalIgnoreCase))
            {
                string path = data.Path;
                if (string.IsNullOrEmpty(path))
                {
                    LogError("�Ҳ���·��");
                }
                FileInfo file = new FileInfo(path);
                Process.Start(file.DirectoryName);

                return;
            }
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Btn_Disconnect.Enabled)
            {
                e.Cancel = true;
            }

        }

        private void nfIcon_MouseClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.TopMost = true;
            this.TopMost = false;
        }

        private void FrmMain_Deactivate(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();//���ش���
            }
        }

        private void tsExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsShow_Click(object sender, EventArgs e)
        {
            this.Show();
            this.TopMost = true;
            this.TopMost = false;
        }
    }
}
