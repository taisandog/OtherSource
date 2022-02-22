using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Runtime.InteropServices;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Threading;
using Buffalo.Win32Kernel.Win32;



namespace WordFilter
{
    public partial class FrmMain : Form
    {
        HotKey _hotKey;
        HotKey _readHotKey;
        HotKey _formHotKey;
        bool _visable = false;
        WordPicture _wp;
        QRCodeUnit _qrcode;
        Base64Unit _base64Unit;
        private ToolStripMenuItem[] _toolItems;
        internal bool _isSys = false;//是否系统复制
        ConfigSave _config;
        private ScreenCapture _sc = null;
        //ClipboardListener _listener;
        public FrmMain()
        {
            

            
            _wp = new WordPicture();
            _wp.LineAlpha = 200;
            
            _qrcode = new QRCodeUnit();
            _base64Unit = new Base64Unit();
            _sc = new ScreenCapture();
            InitializeComponent();
            _config = ConfigSave.ReadConfig();

            _toolItems = new ToolStripMenuItem[] { itemFont, itemQRCode, itemQRCodeEncry,itemBase64,itemBase64Encry };
            //_listener = new ClipboardListener(this.Handle);
            
            //_listener.OnClipboardWrite += new DelOnWndProc(_listener_OnClipboardWrite);
            //if (_config.ListenClipboard)
            //{
            //    _listener.Listen();
            //}
            InitSelectItem();

            ReSetConfig();
            
        }

        //void _listener_OnClipboardWrite(Message msg)
        //{
        //    if (!_isSys)
        //    {
        //        string str = _qrcode.GetQRCodeString();
        //        if (!string.IsNullOrEmpty(str))
        //        {
        //            FrmQRResault.ShowBox(str);
        //        }
                
        //    }
        //}

        
       
        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
        /// <summary>
        /// 配置
        /// </summary>
        public ConfigSave Config
        {
            get { return _config; }
        }
        protected override void WndProc(ref Message m)
        {
            if (_hotKey != null) 
            {
                _hotKey.DoWndProc(m);
            }
            if (_readHotKey != null)
            {
                _readHotKey.DoWndProc(m);
            }
            if (_formHotKey != null)
            {
                _formHotKey.DoWndProc(m);
            }
            //if (_listener != null)
            //{
            //    _listener.DoWndProc(m);
            //}
            base.WndProc(ref m);
        }

        protected override void SetVisibleCore(bool value)
        {
            base.SetVisibleCore(_visable);
        }

        /// <summary>
        /// 获取图片
        /// </summary>
        /// <returns></returns>
        private Bitmap GetPicture(string str) 
        {
            if (itemFont.Checked) 
            {
                return  _wp.DrawWordPicture(str);
            }
            else if (itemQRCode.Checked) 
            {
                return _qrcode.GetQRCode(str);
            }
            else if (itemQRCodeEncry.Checked) 
            {
                return _qrcode.GetEncryQRCode(str);
            }
            return null;
        }
        

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //kbListener.StopListener();
            //SaveSelectItem();
            //FreeConfig();
            //Application.Exit();
            this.Close();
        }

        ~FrmMain() 
        {
            FreeConfig();
        }

        /// <summary>
        /// 释放钩子
        /// </summary>
        private void FreeConfig() 
        {
            //if (_listener != null)
            //{
            //    _listener.StopListen();
            //}
            if (_hotKey!=null&&_hotKey.IsRegistered)
            {
                _hotKey.UnRegister();
            }
            if (_readHotKey != null && _readHotKey.IsRegistered)
            {
                _readHotKey.UnRegister();
            }
            if (_formHotKey != null && _formHotKey.IsRegistered)
            {
                _formHotKey.UnRegister();
            }
        }

        /// <summary>
        /// 重新启动配置
        /// </summary>
        public void ReSetConfig() 
        {
            FreeConfig();

            _hotKey = new HotKey(1, _config.Modifiers, _config.HotKey, this);
            _hotKey.OnHotKeyPress += new DelOnWndProc(_hotKey_OnHotKeyPress);
            if (!_hotKey.Register()) 
            {
                MessageBox.Show("转换图片的热键注册失败，请设置另一组热键", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
            _readHotKey = new HotKey(2, _config.ReadModifiers, _config.ReadHotKey, this);
            _readHotKey.OnHotKeyPress += new DelOnWndProc(_readHotKey_OnHotKeyPress);
            if (!_readHotKey.Register())
            {
                MessageBox.Show("读取二维码的热键注册失败，请设置另一组热键", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
            _formHotKey = new HotKey(3, _config.FormModifiers, _config.FormHotKey, this);
            _formHotKey.OnHotKeyPress += new DelOnWndProc(_formHotKey_OnHotKeyPress);
            if (!_formHotKey.Register())
            {
                MessageBox.Show("读取活动窗体二维码的热键注册失败，请设置另一组热键", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            _qrcode.QRSize=new System.Drawing.Size(_config.Side,_config.Side);
            //if (_config.ListenClipboard)
            //{
            //    if (!_listener.IsListen)
            //    {
            //        _listener.Listen();
            //    }
            //}
            //else 
            //{
            //    if (_listener.IsListen)
            //    {
            //        _listener.StopListen();
            //    }
            //}
        }

        void _hotKey_OnHotKeyPress(Message msg)
        {
            try
            {
                _isSys = true;
                Clipboard.Clear();
                SendKeys.SendWait("^a");
                Thread.Sleep(50);
                SendKeys.SendWait("^c");
                Thread.Sleep(50);
                try
                {
                    if (Clipboard.ContainsText())
                    {
                        string str = (String)Clipboard.GetData(DataFormats.Text);

                        if (ConvertToImage(str)) 
                        {
                            return;
                        }
                        if (ConvertToText(str))
                        {
                            return;
                        }
                        
                    }
                }
                catch (Exception ex)
                {
                    ShowMessage(ex.Message, "错误", ToolTipIcon.Error, 3);
                }
            }


            finally
            {
                _isSys = false;
            }
        }
        /// <summary>
        /// 转成图片
        /// </summary>
        /// <param name="str"></param>
        private bool ConvertToText(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return false;
            }
            string retStr = null;
            if (itemBase64.Checked)
            {
                retStr=_base64Unit.ToBaseString(str, false);
            }
            else if (itemBase64Encry.Checked)
            {
                retStr = _base64Unit.ToBaseString(str, true);
            }
            if (!string.IsNullOrWhiteSpace(retStr)) 
            {
                Clipboard.SetText(retStr);
                Thread.Sleep(50);
                SendKeys.SendWait("^v");

                if (_config.ShowTime > 0)
                {
                    ShowMessage(str, "已经转换文字", ToolTipIcon.Info, _config.ShowTime);
                }
                Clipboard.Clear();
                return true;
            }

            return false;
        }

        /// <summary>
        /// 转成图片
        /// </summary>
        /// <param name="str"></param>
        private bool ConvertToImage(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return false;
            }
            Image img = GetPicture(str);
            if (img != null)
            {
                Clipboard.SetImage(img);
                Thread.Sleep(50);
                SendKeys.SendWait("^v");

                if (_config.ShowTime > 0)
                {
                    ShowMessage(str, "已经转换文字", ToolTipIcon.Info, _config.ShowTime);
                }
                Clipboard.Clear();
                return true;
            }

            return false;
        }

        /// <summary>
        /// 显示信息
        /// </summary>
        /// <param name="message">内容</param>
        /// <param name="title">标题</param>
        /// <param name="icon">图标</param>
        /// <param name="showTime">显示时间</param>
        private void ShowMessage(string message,string title, ToolTipIcon icon,int showTime) 
        {
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon1.BalloonTipText = message;
            notifyIcon1.BalloonTipTitle = title;
            notifyIcon1.ShowBalloonTip(_config.ShowTime);
        }
        void _readHotKey_OnHotKeyPress(Message msg)
        {

            if (!_isSys)
            {
                try
                {
                    using (Bitmap bmap = QRCodeUnit.GetClipboardBitmap())
                    {
                        if (bmap != null)
                        {
                            ReadQR(bmap);
                            return;
                        }
                    }
                    string str = (String)Clipboard.GetData(DataFormats.Text);
                    if (!string.IsNullOrEmpty(str))
                    {
                        ReadBase64(str);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    ShowMessage(ex.Message, "错误", ToolTipIcon.Error, 3);
                }
            }
        }
        private void ReadBase64(string base64)
        {
            string str = _base64Unit.GetBaseString(base64);
            if (!string.IsNullOrEmpty(str))
            {
                FrmQRResault.ShowBox(str);
            }
        }

        /// <summary>
        /// 读取QR
        /// </summary>
        /// <param name="bmap"></param>
        private void ReadQR(Bitmap bmap) 
        {
            
            string str = _qrcode.GetQRCodeString(bmap);
            if (!string.IsNullOrEmpty(str))
            {
                FrmQRResault.ShowBox(str);
            }
        }

        void _formHotKey_OnHotKeyPress(Message msg)
        {
            if (!_isSys)
            {
                try
                {
                    using (Bitmap bmap = _sc.CaptureActive() as Bitmap)
                    {
                        if (bmap == null)
                        {
                            return;
                        }
                        string str = _qrcode.GetQRCodeString(bmap);
                        if (!string.IsNullOrEmpty(str))
                        {
                            FrmQRResault.ShowBox(str);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ShowMessage(ex.Message, "错误", ToolTipIcon.Error, 3);
                }
            }
        }
        /// <summary>
        /// 清空选中的项
        /// </summary>
        private void ClearSelectItem() 
        {
            foreach (ToolStripMenuItem item in _toolItems)
            {
                item.Checked = false;
            }
        }

        private void itemType_Click(object sender, EventArgs e)
        {
            ClearSelectItem();
            ToolStripMenuItem cur = sender as ToolStripMenuItem;
            if (cur != null) 
            {
                cur.Checked = true;
                
            }
            SaveSelectItem();
        }

        /// <summary>
        /// 保存选中的项
        /// </summary>
        private void SaveSelectItem() 
        {
            for (int i = 0; i < _toolItems.Length; i++)
            {
                if (_toolItems[i].Checked)
                {
                    try
                    {
                        _config.OutItem = i;
                    }
                    catch { }
                    break;
                }
            }
            _config.SaveConfig();
        }

        /// <summary>
        /// 初始化选中的输出类型
        /// </summary>
        private void InitSelectItem() 
        {
            
            try
            {
                
                int index = _config.OutItem;
                ClearSelectItem();

                _toolItems[index].Checked = true; ;
            }
            catch { }
        }

        private void toolKey_Click(object sender, EventArgs e)
        {
            FrmKeys.ShowBox();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            FreeConfig();
        }
    }
}