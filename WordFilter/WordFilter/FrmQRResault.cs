using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace WordFilter
{
    public partial class FrmQRResault : Form
    {
        private static FrmQRResault _frm;
        /// <summary>
        /// 当前窗体
        /// </summary>
        public static FrmQRResault Current 
        {
            get 
            {
                if (_frm == null || _frm.IsDisposed) 
                {
                    _frm=new FrmQRResault();
                }
                return _frm;
            }
        }
        public FrmQRResault()
        {
            InitializeComponent();
        }

        private void FrmQRResault_Load(object sender, EventArgs e)
        {
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        /// <summary>
        /// 显示结果框
        /// </summary>
        /// <param name="content"></param>
        public static void ShowBox(string content) 
        {
            FrmQRResault frm = Current;
            frm.Text = "二维码信息";
            frm.txtContent.Text = content;
            frm.txtContent.ForeColor = Color.Black;
            ShowForm(frm);
        }

        private static void ShowForm(FrmQRResault frm) 
        {
            frm.Show();
            Point p=Cursor.Position;
            Screen curScreen = Screen.FromPoint(p);
            //Rectangle curRec=Screen.GetBounds(frm);

            int maxWidth=curScreen.Bounds.X + curScreen.Bounds.Width - frm.Width;
            int x = p.X - (frm.Width / 2);
            if (x  > maxWidth) 
            {
                x = maxWidth;
            }
            else if (x < curScreen.Bounds.X )
            {
                x = curScreen.Bounds.X ;
            }

            int y = p.Y-50 ;
            int maxHeight = curScreen.Bounds.Y + curScreen.Bounds.Height - frm.Height;
            if (y  > maxHeight)
            {
                y = p.Y - frm.Height + 50;
                if (y > maxHeight)
                {
                    y = maxHeight;
                }
            }
            else if (y < curScreen.Bounds.Y) 
            {
                y = curScreen.Bounds.Y;
            }

            frm.Location = new Point(x, y);
            frm.TopMost = true;
            //frm.TopMost = false;
        }
        /// <summary>
        /// 显示结果框
        /// </summary>
        /// <param name="content"></param>
        public static void ShowError(string content)
        {
            FrmQRResault frm = Current;
            frm.Text = "解析二维码错误";
            frm.txtContent.Text = content;
            frm.txtContent.ForeColor = Color.Red;
            ShowForm(frm);
        }
        private void btnCopy_Click(object sender, EventArgs e)
        {
            try
            {
                Program.MainForm._isSys = true;
                Clipboard.SetText(this.txtContent.Text);
            }
            catch { }
            finally 
            {
                Program.MainForm._isSys = false;
            }
        }

        private void txtContent_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(e.LinkText);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}