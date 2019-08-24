using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Buffalo.Win32Kernel;
using Buffalo.Kernel;
using Buffalo.Win32Kernel.Win32;
using System.Reflection;


namespace WordFilter
{
    public partial class FrmKeys : Form
    {
        public FrmKeys()
        {
            InitializeComponent();
        }

        private static FrmKeys _frm;
        /// <summary>
        /// 显示热键
        /// </summary>
        public static void ShowBox() 
        {
            if (_frm == null || _frm.IsDisposed) 
            {
                _frm = new FrmKeys();
            }
            _frm.Show();
            _frm.TopMost = true;
            _frm.TopMost = false;
        }

        private void FrmKeys_Load(object sender, EventArgs e)
        {
            BindKeys();
            InitKeys();
            SetTitle();
        }
        /// <summary>
        /// 设置标题
        /// </summary>
        private void SetTitle()
        {
            this.Text = GetToolVerInfo("文字图片", this.GetType().Assembly)+"--设置";
        }
        /// <summary>
        /// 软件标题版本信息
        /// </summary>
        /// <param name="title"></param>
        /// <param name="ass"></param>
        /// <returns></returns>
        public static string GetToolVerInfo(string title, Assembly ass)
        {

            string ver = ass.GetName().Version.ToString();
            StringBuilder sbInfo = new StringBuilder();
            sbInfo.Append(title);
            sbInfo.Append("   [v");
            sbInfo.Append(ver);
            sbInfo.Append("]");
            return sbInfo.ToString();
        }
        private void BindKeys() 
        {
            BindModifiers(cmbModifiers);
            BindModifiers(cmbReadModifiers);
            BindModifiers(cmbFormModifiers);
            BindKeys(cmbKeys);
            BindKeys(cmbReadKeys);
            BindKeys(cmbFormKeys);
        }

        
        private void BindModifiers(ComboBox cmb) 
        {
            List<EnumInfo> lstModifiers = EnumUnit.GetEnumInfos(typeof(KeyModifiers));
            cmb.Items.Clear();
            List<ComboBoxItem> lstValue = new List<ComboBoxItem>();
            foreach (EnumInfo info in lstModifiers)
            {
                string name = info.FieldName;
                if (name == "Control")
                {
                    name = "Ctrl";
                }
                else if (name == "Windows" || name == "All")
                {
                    continue;
                }
                ComboBoxItem item = new ComboBoxItem(name, (int)info.Value);
                lstValue.Add(item);
            }
            cmb.DisplayMember = "FieldName";
            cmb.ValueMember = "Value";
            cmb.DataSource = lstValue;
        }

        private void BindKeys(ComboBox cmb)
        {
            List<EnumInfo> lstKeys = EnumUnit.GetEnumInfos(typeof(Keys));
            cmb.Items.Clear();
            List<ComboBoxItem>  lstValue = new List<ComboBoxItem>();
            foreach (EnumInfo info in lstKeys)
            {
                int val = (int)info.Value;
                if (val >= 48 && val <= 120)
                {
                    string name = info.FieldName;
                    if (name.Length == 2 && name[0] == 'D')
                    {
                        name = name.Substring(1);
                    }
                    ComboBoxItem item = new ComboBoxItem(name, (int)info.Value);
                    lstValue.Add(item);
                }
            }
            cmb.DisplayMember = "FieldName";
            cmb.ValueMember = "Value";
            cmb.DataSource = lstValue;
        }
        /// <summary>
        /// 初始化热键
        /// </summary>
        private void InitKeys() 
        {
            ConfigSave config = Program.MainForm.Config;


            int modifiers = (int)config.Modifiers; 
            if (modifiers == 0)
            {
                cmbModifiers.SelectedIndex = 0;
            }
            else
            {
                cmbModifiers.SelectedValue = (int)config.Modifiers;
            }
            cmbKeys.SelectedValue = (int)config.HotKey;


            modifiers = (int)config.ReadModifiers;
            if (modifiers == 0)
            {
                cmbReadModifiers.SelectedIndex = 0;
            }
            else
            {
                cmbReadModifiers.SelectedValue = (int)config.ReadModifiers;
            }
            cmbReadKeys.SelectedValue = (int)config.ReadHotKey;


            modifiers = (int)config.FormModifiers;
            if (modifiers == 0)
            {
                cmbFormModifiers.SelectedIndex = 0;
            }
            else
            {
                cmbFormModifiers.SelectedValue = (int)config.FormModifiers;
            }
            cmbFormKeys.SelectedValue = (int)config.FormHotKey;


            txtPwd.Text = config.Password;
            txtSide.Value = config.Side;
            txtShow.Value = config.ShowTime;
            chkPoint.Checked = config.HasPointLine;
            //chkListen.Checked = config.ListenClipboard;
            btnTextColor.BackColor = config.TextSetColor;
            btnBackColor.BackColor = config.BackSetColor;
            nupTwist.Value = config.Twist;
            btnQRBackColor.BackColor = config.QRBackSetColor;
            btnQRTextColor.BackColor = config.QRSetColor;

            SetSelectFont(config.TextFont);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ConfigSave config = Program.MainForm.Config;

            config.Modifiers = (KeyModifiers)cmbModifiers.SelectedValue;
            config.HotKey = (Keys)cmbKeys.SelectedValue;
            config.Side = (int)txtSide.Value;
            config.ShowTime = (int)txtShow.Value;
            config.ReadModifiers = (KeyModifiers)cmbReadModifiers.SelectedValue;
            config.ReadHotKey = (Keys)cmbReadKeys.SelectedValue;
            config.FormModifiers = (KeyModifiers)cmbFormModifiers.SelectedValue;
            config.FormHotKey = (Keys)cmbFormKeys.SelectedValue;
            //config.ListenClipboard = chkListen.Checked;
            config.Password = txtPwd.Text;
            config.HasPointLine = chkPoint.Checked;
            config.BackSetColor = btnBackColor.BackColor;
            config.TextSetColor = btnTextColor.BackColor;
            config.Twist = (int)nupTwist.Value;
            config.QRBackSetColor = btnQRBackColor.BackColor;
            config.QRSetColor = btnQRTextColor.BackColor;
            config.TextFont = GetSelectFont();
            Program.MainForm.ReSetConfig();
            config.SaveConfig();
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbKeys_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            Button btn=sender as Button;
            if(btn==null)
            {
                return;
            }
            cdPicker.Color = btn.BackColor;
            if (cdPicker.ShowDialog() == DialogResult.OK) 
            {
                btn.BackColor = cdPicker.Color;
            }
        }

        private void btnFont_Click(object sender, EventArgs e)
        {
            Font f = GetSelectFont();
            fdPick.Font = f;
            if (fdPick.ShowDialog() == DialogResult.OK) 
            {
                SetSelectFont(fdPick.Font);
            }
        }
        /// <summary>
        /// 获取选中的字体
        /// </summary>
        /// <returns></returns>
        public Font GetSelectFont() 
        {
            Font f = btnFont.Tag as Font;
            if (f == null)
            {
                f = new Font("宋体", 12, FontStyle.Bold);
            }
            return f;
        }
        /// <summary>
        /// 设置选中的字体
        /// </summary>
        /// <returns></returns>
        public void SetSelectFont(Font font)
        {
            btnFont.Tag = font;
            btnFont.Text = font.FontFamily.Name+","+font.Size+","+font.Style;
        }
    }
}