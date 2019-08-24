using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Threading;

namespace ScanLan
{
    public partial class FrmPing : Form
    {
        public FrmPing()
        {
            InitializeComponent();
        }

        private string _ip;

        /// <summary>
        /// 要ping的IP
        /// </summary>
        public string IP
        {
            get { return _ip; }
            set { _ip = value; }
        }

        private bool _isStop=false;

        private void DoPing() 
        {
            
            while (!_isStop) 
            {
                PingReply rep = LanMachine.Ping(_ip,1000);
                string msg = GetMessage(rep);
                try
                {
                    if (!this.IsDisposed && !_isStop)
                    {
                        this.Invoke(new MethodInvoker(delegate
                        {
                            if (rtbInfo.Text.Length > 8000) 
                            {
                                rtbInfo.Text = "";
                            }
                            rtbInfo.Text += msg+"\n\n";
                            rtbInfo.SelectionStart = rtbInfo.Text.Length ;
                        }));
                    }
                }
                catch { }
                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// 获取ping结果消息
        /// </summary>
        /// <param name="rep"></param>
        /// <returns></returns>
        private string GetMessage(PingReply reply) 
        {
            StringBuilder sbInfo = new StringBuilder();
            sbInfo.Append(string.Format("主机: {0}  ", reply.Address));
            if (reply.Status == IPStatus.Success)
            {
                
                
                sbInfo.Append(string.Format("响应时间: {0}毫秒  ", reply.RoundtripTime));
                sbInfo.Append(string.Format("TTL: {0}  ", reply.Options.Ttl));
                //sbInfo.Append("Don't fragment: {0}", reply.Options.DontFragment);
                sbInfo.Append(string.Format("发送字节: {0}", reply.Buffer.Length));
                
            }
            else 
            {
                sbInfo.Append(LanMachine.GetPingError(reply.Status));
            }
            return sbInfo.ToString();
        }



        Thread _thdPing = null;
        /// <summary>
        /// 开启并开始ping
        /// </summary>
        public void ShowAndPing(string ip) 
        {
            _ip = ip;
            this.Text = "正在Ping主机:" + ip+"  ......";
            this.Show();
            _isStop = false;
            _thdPing = new Thread(new ThreadStart(DoPing));
            _thdPing.Start();
        }

        private void FrmPing_FormClosing(object sender, FormClosingEventArgs e)
        {
            _isStop = true;
            if (_thdPing != null) 
            {
                _thdPing.Abort();
                Thread.Sleep(300);
            }
        }
    }
}