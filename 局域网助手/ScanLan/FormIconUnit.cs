using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library.Unit
{
    /// <summary>
    /// 任务栏图标管理
    /// </summary>
    public class FormIconUnit:IDisposable
    {
        /// <summary>
        /// 图标
        /// </summary>
        private NotifyIcon _icon;
        /// <summary>
        /// 窗体
        /// </summary>
        private Form _frm;
        /// <summary>
        /// 任务栏图标管理
        /// </summary>
        /// <param name="frm"></param>
        /// <param name="icon"></param>
        public FormIconUnit(Form frm, NotifyIcon icon)
        {
            _frm = frm;
            _icon = icon;
            

        }
        public void Bind()
        {
            _frm.SizeChanged += FrmMain_SizeChanged;
            _icon.DoubleClick += _icon_DoubleClick;
            _icon.Text = _frm.Text;
            _icon.Icon = _frm.Icon;
            SetIconVisable();
        }

        private void _icon_DoubleClick(object sender, EventArgs e)
        {
            ShowMain();
        }
        /// <summary>
        /// 显示主窗体
        /// </summary>
        public void ShowMain()
        {
            
            _frm.Invoke((EventHandler)delegate
            {
                _frm.Show();
                _frm.WindowState = _lastWindowState;
                _frm.TopMost = true;
                _frm.TopMost = false;
                SetIconVisable();
            });

        }

        /// <summary>
        /// 设置图标是否显示
        /// </summary>
        private void SetIconVisable()
        {
            _icon.Visible = !_frm.Visible;
        }

        FormWindowState _lastWindowState = FormWindowState.Normal;
        private void FrmMain_SizeChanged(object sender, EventArgs e)
        {
            if (_frm.WindowState == FormWindowState.Minimized)
            {
                _frm.Visible = false;//隐藏窗体
                SetIconVisable();
            }
            else
            {
                _lastWindowState = _frm.WindowState;
            }
        }

        public void Dispose()
        {
            _frm.SizeChanged -= FrmMain_SizeChanged;
            _icon.DoubleClick -= _icon_DoubleClick;
            _frm = null;
            _icon = null;
        }
    }
}
