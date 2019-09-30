using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using ScanLan.Controls;
using System.Threading;
using System.Net.NetworkInformation;


namespace ScanLan
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private static readonly string LastScanFile = AppDomain.CurrentDomain.BaseDirectory + "\\LastScan.xml";

        NumericText[] _txtS =null;
        LanMachine _localMachine;
        ScanSpeed _speed = new ScanSpeed("","",100,1000);
        /// <summary>
        /// 初始化IP框
        /// </summary>
        private void InitIPBox() 
        {
            txtEnd.textBox1.Enabled = false;
            txtEnd.textBox2.Enabled = false;
            txtEnd.textBox3.Enabled = false;

            txtStar.textBox1.TextChanged += new EventHandler(textBox1_TextChanged);
            txtStar.textBox2.TextChanged += new EventHandler(textBox2_TextChanged);
            txtStar.textBox3.TextChanged += new EventHandler(textBox3_TextChanged);
        }
        void textBox2_TextChanged(object sender, EventArgs e)
        {
            txtEnd.textBox2.Text = txtStar.textBox2.Text;
        }
        void textBox3_TextChanged(object sender, EventArgs e)
        {
            txtEnd.textBox3.Text = txtStar.textBox3.Text;
        }
        void textBox1_TextChanged(object sender, EventArgs e)
        {
            txtEnd.textBox1.Text = txtStar.textBox1.Text;
        }

        /// <summary>
        /// 绑定IP
        /// </summary>
        private void BindIP() 
        {
            //cmbIP.Items.Clear();
            List<LanMachine> lst = LanMachine.GetLocalInfos();
            //foreach (LanMachine machine in lst) 
            //{
            //    cmbIP.Items.Add(machine);
            //}
            cmbIP.DisplayMember = "IP";
            cmbIP.ValueMember = "IP";
            cmbIP.DataSource = lst;
            if (cmbIP.Items.Count > 0) 
            {
                cmbIP.SelectedIndex = 0;
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            string ver=System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            this.Text = "局域网扫描(ver:" + ver + ")";
            InitIPBox();
            DoScaning(false);
            //_localMachine = LanMachine.GetLocalInfo();
            BindIP();
            BindSpeed();
            LostLastScan();
        }

        private void BindSpeed() 
        {
            List<ScanSpeed> lst = new List<ScanSpeed>();
            lst.Add(new ScanSpeed("fast","快",10,100));
            lst.Add(new ScanSpeed("normal", "中", 100,1000));
            lst.Add(new ScanSpeed("slow", "慢", 300,10000));
            cmbSpeed.DisplayMember = "Text";
            cmbSpeed.ValueMember = "SleepTime";
            cmbSpeed.DataSource = lst;
        }

        private void LostLastScan() 
        {
            try
            {
                LoadInfo(LastScanFile);
            }
            catch { }
        }

        private void AddToGrid(LanMachine machine) 
        {
            this.Invoke(new MethodInvoker(delegate
                {
                    
                    DataGridViewRow row = GetRow(machine);
                    
                    
                }));
        }
        /// <summary>
        /// 获取y已存在的机器行
        /// </summary>
        /// <param name="machine"></param>
        /// <returns></returns>
        private DataGridViewRow GetRow(LanMachine machine)
        {
            foreach(DataGridViewRow currow in dgMembers.Rows)
            {
                LanMachine curmachine = currow.Tag as LanMachine;
                if (curmachine == null)
                {
                    continue;
                }
                if (curmachine.Mac.Mac==machine.Mac.Mac)
                {
                    if (curmachine.IP != machine.IP)
                    {
                        curmachine.IP = machine.IP;
                        curmachine.HostName = machine.HostName;
                        currow.Cells["ColName"].Value = machine.HostName;
                        currow.Cells["ColIP"].Value = machine.IP.ToString();
                    }
                    return currow;
                }
            }
            int i = dgMembers.Rows.Add();
            DataGridViewRow newrow = dgMembers.Rows[i];
            newrow.Cells["ColIP"].Value = machine.IP.ToString();
            newrow.Cells["ColMAC"].Value = machine.Mac.ToString();
            newrow.Cells["ColName"].Value = machine.HostName;
            newrow.Tag = machine;
            return newrow;
        }

        /// <summary>
        /// 扫描机器
        /// </summary>
        /// <param name="machine"></param>
        private void ScanMachine(object objMachine) 
        {
            LanMachine machine = objMachine as LanMachine;
            
            try
            {
                if (machine.Ping(_speed.Timeout).Status == IPStatus.Success)
                {
                    try
                    {
                        machine.HostName = LanMachine.GetHostName(machine.IP);
                    }
                    catch
                    {
                        machine.HostName = machine.IP.ToString();
                    }
                    try
                    {
                        machine.Mac = MacInfo.GetRemoteMac(machine.IP.ToString());
                    }
                    catch { }
                    AddToGrid(machine);
                }
            }
            catch (Exception ex) { }
            finally
            {
                try
                {
                    if (!this.IsDisposed && !_isStop)
                    {


                        this.Invoke(new MethodInvoker(delegate
                        {

                            tspbScan.Value++;
                            tsProcess.Text = (tspbScan.Value * 100 / tspbScan.Maximum).ToString() + "%";
                            if (tspbScan.Value >= tspbScan.Maximum)
                            {
                                DoScaning(false);
                                
                            }

                        }));
                    }
                }
                catch { }
            }
        }

        

        /// <summary>
        /// 扫描状态
        /// </summary>
        /// <param name="isScaning">是否扫描中</param>
        private void DoScaning(bool isScaning) 
        {
            btnStop.Enabled = isScaning;
            _isStop = !isScaning;
            satProcess.Visible = isScaning;
            btnSearch.Enabled = !isScaning;
            txtStar.Enabled = !isScaning;
            txtEnd.Enabled = !isScaning;
            msMenu.Visible = !isScaning;
            cmbIP.Enabled = !isScaning;
        }

        private void StopThreads() 
        {
            
            foreach(Thread thd in _lstThreads)
            {
                if (thd.ThreadState == ThreadState.Running || thd.ThreadState == ThreadState.Background)
                {
                    thd.Abort();
                }
            }
        }

        Queue<Thread> _lstThreads=new Queue<Thread>();
        private bool _isStop = false;
        /// <summary>
        /// 开始扫描
        /// </summary>
        private void DoScan()
        {
            int numStar = 0;
            int numEnd = 0;
            _lstThreads.Clear();
            string head=GetInfo(ref numStar, ref numEnd);
            for (int i = numStar; i <= numEnd; i++)
            {
                if (_isStop)
                {
                    break;
                }
                LanMachine machine = new LanMachine();
                machine.IP = IPAddress.Parse(head + i.ToString());
                Thread thd=new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(ScanMachine));
                _lstThreads.Enqueue(thd);
                thd.Start(machine);
                Thread.Sleep(_speed.SleepTime);
            }

        }

        private string GetInfo(ref int numStar,ref int numEnd)
        {
            string star = txtStar.Value;
            string end = txtEnd.Value;
            int starIndex = star.LastIndexOf('.');
            int endIndex = end.LastIndexOf('.');
            numStar = Convert.ToInt32(star.Substring(starIndex + 1));
            numEnd = Convert.ToInt32(end.Substring(endIndex + 1));
            string head = star.Substring(0, starIndex + 1);
            return head;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int numStar = 0;
            int numEnd = 0;
            GetInfo(ref numStar, ref numEnd);
            if (numStar > numEnd) 
            {
                MessageBox.Show("起始地址不能大于结束地址");
                return;
            }
            _speed = cmbSpeed.SelectedItem as ScanSpeed;
            //_isStop = false;
            tspbScan.Maximum = numEnd-numStar+1;
            tspbScan.Value = 0;
            new System.Threading.Thread(new System.Threading.ThreadStart(DoScan)).Start();
            tspbScan.Visible = true;
            //dgMembers.Rows.Clear();
            DoScaning(true);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            DoScaning(false);
            StopThreads();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_isStop)
            {
                e.Cancel = true;
                return;
            }
            try
            {
                SaveTo(LastScanFile);
            }
            catch { }
            _isStop = true;
            StopThreads();
            Thread.Sleep(300);

        }

        private void ping主机ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgMembers.SelectedRows.Count > 0) 
            {
                DataGridViewRow row = dgMembers.SelectedRows[0];
                LanMachine machine = row.Tag as LanMachine;
                if (machine == null)
                {
                    return;
                }
                string ip = machine.IP.ToString();
                if (!string.IsNullOrEmpty(ip)) 
                {
                    FrmPing frm = new FrmPing();
                    frm.ShowAndPing(ip);
                }
            }
        }

        private void btnPing_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUrl.Text))
            {
                FrmPing frm = new FrmPing();
                frm.ShowAndPing(txtUrl.Text);
            }
        }

        private void cmbIP_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            LanMachine localMachine = cmbIP.SelectedItem as LanMachine;
            if (localMachine == null) 
            {
                return;
            }
            _localMachine = localMachine;
            byte[] arrIP = _localMachine.IP.GetAddressBytes();
            StringBuilder sbIP = new StringBuilder();
            for (int i = 0; i < 3; i++)
            {
                sbIP.Append(arrIP[i].ToString());
                sbIP.Append(".");
            }
            txtStar.Value = sbIP.ToString() + "1";
            txtEnd.Value = sbIP.ToString() + "254";
            gpScan.Text = "扫描局域网:" + "网络IP:" + _localMachine.IP.ToString();
        }

        /// <summary>
        /// 打开共享
        /// </summary>
        /// <param name="ip"></param>
        private void OpenShare(string ip) 
        {
            IPAddress ipadd=null;
            if(!IPAddress.TryParse(ip,out ipadd))
            {
                MessageBox.Show("此IP不合法");
                return;
            }
            try
            {
                System.Diagnostics.Process.Start("\\\\" + ip);
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "打开网络共享错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenShare(txtUrl.Text);
        }

        private void 查看共享ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgMembers.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgMembers.SelectedRows[0];
                LanMachine machine=row.Tag as LanMachine;
                if (machine == null) 
                {
                    return;
                }
                string ip = machine.IP.ToString();
                if (!string.IsNullOrEmpty(ip))
                {
                    FrmPing frm = new FrmPing();
                    OpenShare(ip);
                }
            }
        }

        private void dgMembers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            查看共享ToolStripMenuItem_Click(null, new EventArgs());
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgMembers.Rows.Count==0) 
            {
                MessageBox.Show("没有要保存的内容");
                return;
            }
            if (sfd.ShowDialog() == DialogResult.OK) 
            {
                try
                {
                    bool ret = SaveTo(sfd.FileName);
                    if (!ret)
                    {
                        MessageBox.Show("没有保存文件");
                    }
                    else
                    {
                        MessageBox.Show("保存完毕");
                    }
                }
                catch (Exception ex) 
                {
                    MessageBox.Show(ex.Message, "保存文件错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// 保存到文件
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private bool SaveTo(string path) 
        {
            List<LanMachine> lstMachine = new List<LanMachine>();
            foreach (DataGridViewRow row in dgMembers.Rows) 
            {
                LanMachine machine = row.Tag as LanMachine;
                if (machine == null) 
                {
                    continue;
                }
                lstMachine.Add(machine);

            }
            if (lstMachine.Count == 0) 
            {
                return false;
            }
            LanMachine.SaveTo(path, lstMachine);
            return true;
        }

        /// <summary>
        /// 加载文件
        /// </summary>
        /// <returns></returns>
        private void LoadInfo(string path) 
        {
            List<LanMachine> lstMachine=LanMachine.LoadList(path);
            dgMembers.Rows.Clear();
            foreach (LanMachine machine in lstMachine) 
            {
                AddToGrid(machine);
            }
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                     LoadInfo(ofd.FileName);
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "打开文件错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgMembers.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgMembers.SelectedRows[0];
                LanMachine machine = row.Tag as LanMachine;
                if (machine == null)
                {
                    return;
                }
                string str = machine.IP.ToString() + "   " + machine.HostName+"   "+machine.Mac;
                Clipboard.SetDataObject(str);
            }

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(MacInfo.GetRemoteMac("192.168.1.25").ToString());
        }

        private void 唤醒ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgMembers.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgMembers.SelectedRows[0];
                LanMachine machine = row.Tag as LanMachine;
                if (machine == null)
                {
                    return;
                }
                machine.WakeOnLan();
            }
        }

        private void tsDelete_Click(object sender, EventArgs e)
        {
            if (dgMembers.SelectedRows.Count <= 0)
            {
                return;
            }
            DataGridViewRow row = dgMembers.SelectedRows[0];
            if (row.Index < 0)
            {
                return;
            }
           
            dgMembers.Rows.Remove(row);
        }

        private void tsClear_Click(object sender, EventArgs e)
        {
            dgMembers.Rows.Clear();
        }

        private void tsCreateSnap_Click(object sender, EventArgs e)
        {
            if (dgMembers.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgMembers.SelectedRows[0];
                LanMachine machine = row.Tag as LanMachine;
                if (machine == null)
                {
                    return;
                }
                machine.CreateWakeOnSnapshot(false);
            }
        }

        private void TsCreateSnapPing_Click(object sender, EventArgs e)
        {
            if (dgMembers.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgMembers.SelectedRows[0];
                LanMachine machine = row.Tag as LanMachine;
                if (machine == null)
                {
                    return;
                }
                machine.CreateWakeOnSnapshot(true);
            }
        }
    }
}