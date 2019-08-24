/*****************************************************************
 * �������������IP��ַ�����뼰��֤����IPAddress��Gateway������֤��ʽ��
 * 
 * �� �� �ߣ����Ͽ�Դ���룬��� �Ľ�
 * 
 * ������ڣ�2008��7��9�� 18ʱ20��42��
 * 
 * 
 * ***************************************************************/

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Windows.Forms.VisualStyles;


namespace LC.Library.Controls
{
    /// <summary>
    /// IPBox ������
    /// <para>    �ṩһ��IP��ַ����Ŀؼ�����IPAddress��Gateway������֤��ʽ��</para>
    /// </summary>
    public partial class IPBox : UserControl
    {
        private Color _orgColor;
        private Color _backColor ;

        //string pattern = @"^([1-9]|\d{2}|1[0-9]{1,2}|2[0-5]{2})\.(\d{1,2}|1[0-9]{1,2}|[1-2][0-5]{2})\.(\d{1,2}|1[0-9]{1,2}|[1-2][0-5]{2})\.(\d{1,2}|1[0-9]{1,2}|[1-2][0-5]{2})$"; 
        private string pattern223 = @"^([1-9]|\d{2}|1[0-9]{1,2}|2[0-5]{2})$";
        private string pattern225 = @"^(\d{1,2}|1[0-9]{1,2}|[1-2][0-5]{2})$"; 

        public IPBox()
        {
            InitializeComponent();
            BackColor = SystemColors.Window;
            _orgColor = BackColor;
            
        }

        private ToolTip _CurToolTip = null;
        private ToolTip CurToolTip
        {
            get
            {
                if (_CurToolTip == null)
                {
                    _CurToolTip = new ToolTip();
                    _CurToolTip.AutomaticDelay = 2000;
                    _CurToolTip.ShowAlways = true;
                    _CurToolTip.IsBalloon = true;
                    _CurToolTip.ToolTipIcon = ToolTipIcon.Error;
                    _CurToolTip.ToolTipTitle = "˵��:";
                }
                return _CurToolTip;
            }
        }

        /// <summary>
        /// ��ʾ����
        /// </summary>
        /// <param name="msg"></param>
        private void ShowError(string msg) 
        {
            Point ep = Point.Empty;
            TextBox txt = GetFocusedText();
            if (txt != null) 
            {
                ep =new Point( txt.Location.X+this.Width,txt.Location.Y+this.Height);
            }
            CurToolTip.Show(msg, this, ep.X , ep.Y , 2000);
            CurToolTip.Hide(this);
            CurToolTip.Show(msg, this, ep.X , ep.Y , 2000);
            
        }

        /// <summary>
        /// ��ȡ����ı�
        /// </summary>
        /// <returns></returns>
        private TextBox GetFocusedText() 
        {
            if (textBox1.Focused) { return textBox1; }
            if (textBox2.Focused) { return textBox2; }
            if (textBox3.Focused) { return textBox3; }
            if (textBox4.Focused) { return textBox4; }
            return null;
        }

        private void textBox1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            //System.Text.Encoding.GetEncoding(0).GetString(); 
        }

        private void textBox1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            MaskIpAddr(textBox1, e);
        }

        private void textBox2_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            MaskIpAddr(textBox2, e);
        }

        private void textBox3_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            MaskIpAddr(textBox3, e);
        }

        private void textBox4_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            MaskIpAddr(textBox4, e);
        }

        private void MaskIpAddr(System.Windows.Forms.TextBox textBox, KeyPressEventArgs e)
        {
            int len = textBox.Text.Length;
            errVerify.SetError(this, "");

            if (Char.IsDigit(e.KeyChar) || e.KeyChar == '.' || e.KeyChar == 8)
            {
                if (e.KeyChar != 8)
                {
                    if (len == 2 && e.KeyChar != '.')
                    {
                        int maxnum = 233;
                        if (_inputType == InputType.Gateway)
                        {
                            maxnum = 255;
                        }
                        string tmp = textBox.Text + e.KeyChar;
                        if (textBox.Name == "textBox1")
                        {
                            if (Int32.Parse(tmp) > maxnum) // ������֤ 
                            {
                                textBox.Text = maxnum.ToString();
                                textBox.Focus();
                                if (_showErrorFlag)
                                {
                                    errVerify.SetError(this, "��ָ��һ������ 1 �� 223 ֮�����ֵ��");
                                }
                                else
                                {
                                    //MessageBox.Show(tmp + " ����һ����Ч��Ŀ����ָ��һ������ 1 �� 223 ֮�����ֵ��",
                                    //    "����",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                                    ShowError(tmp + " ����һ����Ч��Ŀ����ָ��һ������ 1 �� 223 ֮�����ֵ��");
                                }
                                e.Handled = true;
                                return;
                            }

                            textBox2.Focus();
                            textBox2.SelectAll();

                        }
                        else if (textBox.Name == "textBox2")
                        {
                            if (Int32.Parse(tmp) > 255)
                            {
                                textBox.Text = "255";
                                textBox.Focus();
                                if (_showErrorFlag)
                                {
                                    errVerify.SetError(this, "��ָ��һ������ 1 �� 255 ֮�����ֵ��");
                                }
                                else
                                {
                                    //MessageBox.Show(tmp + " ����һ����Ч��Ŀ����ָ��һ������ 1 �� 255 ֮�����ֵ��",
                                    //    "����", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    ShowError(tmp + " ����һ����Ч��Ŀ����ָ��һ������ 1 �� 255 ֮�����ֵ��");
                                }
                                e.Handled = true;
                                return;
                            }
                            textBox3.Focus();
                            textBox3.SelectAll();
                        }
                        else if (textBox.Name == "textBox3")
                        {
                            if (Int32.Parse(tmp) > 255)
                            {
                                textBox.Text = "255";
                                textBox.Focus();
                                if (_showErrorFlag)
                                {
                                    errVerify.SetError(this, "��ָ��һ������ 1 �� 255 ֮�����ֵ��");
                                }
                                else
                                    //MessageBox.Show(tmp + " ����һ����Ч��Ŀ����ָ��һ������ 1 �� 255 ֮�����ֵ��",
                                    //    "����", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                ShowError(tmp + " ����һ����Ч��Ŀ����ָ��һ������ 1 �� 255 ֮�����ֵ��");
                                e.Handled = true;
                                return;
                            }
                            textBox4.Focus();
                            textBox4.SelectAll();
                        }
                        else if (textBox.Name == "textBox4")
                        {
                            if (Int32.Parse(tmp) > 255)
                            {
                                textBox.Text = "255";
                                textBox.Focus();
                                if (_showErrorFlag)
                                {
                                    errVerify.SetError(this, "��ָ��һ������ 1 �� 255 ֮�����ֵ��");
                                }
                                else
                                    //MessageBox.Show(tmp + " ����һ����Ч��Ŀ����ָ��һ������ 1 �� 255 ֮�����ֵ��",
                                    //    "����", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                ShowError(tmp + " ����һ����Ч��Ŀ����ָ��һ������ 1 �� 255 ֮�����ֵ��");
                                e.Handled = true;
                                return;
                            }

                        }

                    }
                    if (e.KeyChar == '.')
                    {
                        if (textBox.Name == "textBox1" && textBox.Text != "")
                        {
                            textBox2.Focus();
                            textBox2.SelectAll();
                        }
                        if (textBox.Name == "textBox2" && textBox.Text != "")
                        {
                            textBox3.Focus();
                            textBox3.SelectAll();
                        }
                        if (textBox.Name == "textBox3" && textBox.Text != "")
                        {
                            textBox4.Focus();
                            textBox4.SelectAll();
                        }
                        if (textBox.Name == "textBox4" && textBox.Text != "")
                        {

                        }
                        e.Handled = true;
                    }
                }
                else
                {
                    if (textBox.Name == "textBox1" && textBox.Text == "")
                    {

                    }
                    if (textBox.Name == "textBox2" && textBox.Text == "")
                    {
                        textBox1.Focus();
                        textBox1.SelectionStart = textBox1.Text.Length;
                    }
                    if (textBox.Name == "textBox3" && textBox.Text == "")
                    {
                        textBox2.Focus();
                        textBox2.SelectionStart = textBox2.Text.Length;
                    }
                    if (textBox.Name == "textBox4" && textBox.Text == "")
                    {
                        textBox3.Focus();
                        textBox3.SelectionStart = textBox3.Text.Length;
                    }
                    e.Handled = false;
                }
            }
            else
                e.Handled = true;
            //textBox5.TextAlign = HorizontalAlignment.Center;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            if (this.BorderStyle == BorderStyle.FixedSingle)
            {
                //������һ���߿���ɫ������
                ControlPaint.DrawBorder(e.Graphics, new Rectangle(0, 0, ClientRectangle.Width - 1, ClientRectangle.Height - 1),
                    this._borderColor, ButtonBorderStyle.Solid);
            }
            else
            { 
                if (VisualStyleRenderer.IsSupported && Application.RenderWithVisualStyles)
                {
                    ControlPaint.DrawVisualStyleBorder(e.Graphics, new Rectangle(0, 0, ClientRectangle.Width - 1, ClientRectangle.Height - 1));
                }
                else
                {
                    ControlPaint.DrawBorder3D(e.Graphics, new Rectangle(0, 0, ClientRectangle.Width - 1, ClientRectangle.Height - 1), Border3DStyle.Sunken);
                }
            }
        }

        protected override void OnResize(EventArgs e)
        {
            if (this.Width < 140)
            {
                this.Width = 140;
            }
            this.Height = 21;
            base.OnResize(e);
            SetCenter();
            this.Invalidate();
        }

        /// <summary>
        /// ���ö��С�
        /// </summary>
        private void SetCenter()
        {
            int left = (this.Width - panel1.Width - this.Padding.Left - Padding.Right) / 2;
            int p = 1;
            if (!(VisualStyleRenderer.IsSupported && Application.RenderWithVisualStyles))
            {
                p = 2;
            }
            if (left < p )
            {
                left = p;
            }
            panel1.Left = left;
            panel1.Top = p;
        }

        private void SetBackColor(Color color)
        {
            panel1.BackColor = color;
            textBox1.BackColor = color;
            label1.BackColor = color;
            textBox2.BackColor = color;
            label2.BackColor = color;
            textBox3.BackColor = color;
            label3.BackColor = color;
            textBox4.BackColor = color;
        }

        private bool isValidateValue()
        {
            bool validate = true;
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "")
            {
                validate = false;
            }
            else
            {
                int num = Int32.Parse(textBox1.Text.Trim());
                if (_inputType == InputType.IPAddress)
                {
                    if (num < 1 || num > 233)
                        validate = false;
                }
                else
                {
                    if (num < 1 || num > 233)
                        validate = false;
                }
                if (validate)
                {
                    validate = VerifyForIP(textBox2);
                }
                if (validate)
                {
                    validate = VerifyForIP(textBox3);
                }
                if (validate)
                {
                    validate = VerifyForIP(textBox4);
                }
            }
            return validate;
        }

        private bool VerifyForIP(TextBox box)
        {
            bool validate = true;
            int num = Int32.Parse(box.Text.Trim());
            if (num < 0 || num > 255)
            {
                validate = false;
            }
            return validate;
        }
        protected override void OnEnabledChanged(EventArgs e)
        {
            if (!DesignMode)
            {
                if (Enabled)
                {
                    this.BackColor = _orgColor;
                }
                else
                {
                    _orgColor = BackColor;
                    this.BackColor = SystemColors.Control;
                }
            }

            base.OnEnabledChanged(e);
        }

        protected override void OnValidating(CancelEventArgs e)
        {
            if (_showErrorFlag)
            {
                if (isValidateValue())
                {
                    errVerify.SetError(this, "");
                }
                else
                {
                    errVerify.SetError(this, "��Ч�� IP ��ַ��");
                }
            }
            base.OnValidating(e);
        }
        #region Properties

        private InputType _inputType = InputType.IPAddress;
        /// <summary>
        /// ѡ�����������
        /// </summary>
        /// 
        [Description("ѡ�����������"),DefaultValue(typeof(InputType),"IPAddress")]
        public InputType InputType
        {
            get { return _inputType; }
            set { _inputType = value; }
        }

        [DefaultValue(typeof(Color),"Window")]
        public override Color BackColor
        {
            get
            {
                return _backColor;
            }
            set
            {
                _backColor = value;
                base.BackColor = value;
                SetBackColor(_backColor);
               
            }
        }

        /// <summary>
        /// ���û��ȡΪֻ��
        /// </summary>
        /// 
        [Description("���û��ȡΪֻ��"),DefaultValue(false)]
        public bool ReadOnly
        {
            get { return textBox1.ReadOnly; }
            set
            {
                textBox1.ReadOnly = value;
                textBox2.ReadOnly = value;
                textBox3.ReadOnly = value;
                textBox4.ReadOnly = value;
            }
        }

        private HorizontalAlignment _textAlign = HorizontalAlignment.Center;
        /// <summary>
        /// ��ȡ�������ı��Ķ��뷽ʽ
        /// </summary>
        [Description("��ȡ�������ı��Ķ��뷽ʽ"), DefaultValue(typeof(HorizontalAlignment), "Center")]
        public HorizontalAlignment TextAlign
        {
            get { return _textAlign; }
            set
            {
                _textAlign = value;
                //���¼���Panel��λ��
                if (_textAlign == HorizontalAlignment.Left)
                {
                    panel1.Dock = DockStyle.Left;
                }
                else if (_textAlign == HorizontalAlignment.Right)
                {
                    panel1.Dock = DockStyle.Right;
                }
                else
                {
                    //����λ��
                    panel1.Dock = DockStyle.None;
                    SetCenter();
                }
                this.Refresh();
            }
        }

        /// <summary>
        /// ��ȡIP��ַ����Ч�ԡ�
        /// </summary>
        /// 
        [Browsable(false)]
        public bool IsValidate
        {
            get { return isValidateValue(); }
        }

        private bool _showErrorFlag = false;
        /// <summary>
        /// ��ȡ�������Ƿ���ʾ�����־
        /// </summary>
        /// 
        [Description("��ȡ�������Ƿ���ʾ�����־"),
        DefaultValue(false)]
        public bool ShowErrorFlag
        {
            get { return _showErrorFlag; }
            set
            {
                _showErrorFlag = value;
            }
        }

        private Color _borderColor = Color.FromArgb(0, 60, 116);
        /// <summary>
        /// ��ȡ�����ñ߿���ɫ��
        /// </summary>
        [DefaultValue(typeof(Color), "0, 60, 116"), Description("��ȡ�����ñ߿���ɫ")]
        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value;
                this.Invalidate();
            }
        }

        private BorderStyle _borderStyle = BorderStyle.Fixed3D;
        /// <summary>
        /// �߿����ʽ
        /// </summary>
        /// 
        [Description("�߿����ʽ")]
        [DefaultValue(typeof(BorderStyle),"Fixed3D")]
        public new BorderStyle BorderStyle
        {
            get { return _borderStyle; }
            set
            {
                _borderStyle = value;
                this.Invalidate();
            }
        }

        private string _text = ""; 
        /// <summary>
        /// IP��ֵ
        /// </summary>
        /// 
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]       //�ڴ���������һ��ֵ
        [Browsable(true),DefaultValue("")]
        [Description("IP ��ַ��ֵ")]
        public new string Value
        {
            get
            {
                if (textBox1.Text == ""
                 || textBox2.Text == ""
                 || textBox3.Text == ""
                 || textBox4.Text == "")
                {
                    _text = "";
                    return _text;
                }
                else
                {
                    _text = Convert.ToInt32(textBox1.Text).ToString() + "." + Convert.ToInt32(textBox2.Text).ToString() + "." + Convert.ToInt32(textBox3.Text).ToString() + "." + Convert.ToInt32(textBox4.Text).ToString();
                    return _text;
                }
            }
            set
            {
                //ע�⣺�ڹ��������ϳ��ؼ�ʱ���ܶ�Ƚ��ǲ�׼ȷ�ġ�
                _text = value;
                if (_text != null && _text != "")
                {
                    string[] nums = value.Split('.');
                    if (nums.Length < 4)
                    {
                        if (_showErrorFlag)
                        {
                            errVerify.SetError(this, "ָ����һ����Ч�� IP ��ַ!");
                        }
                    }
                    SetTextBox(nums);
                }
                else
                {
                    _text = "";
                    SetIPEmptyValue();
                }
            }
            /* set  //  
             { 
              if(value != null) 
              { 
               // 255-255-255-255 
               //string pattern = @"^([1-9]|\d{2}|1[0-9]{1,2}|2[0-5]{2})\.(\d{1,2}|1[0-9]{1,2}|[1-2][0-5]{2})\.(\d{1,2}|1[0-9]{1,2}|[1-2][0-5]{2})\.(\d{1,2}|1[0-9]{1,2}|[1-2][0-5]{2})$"; 
               // 223-255-255-255 
               string pattern = @"^([1-9]|\d{2}|1[0-9]{1,2}|2[1-2][1-3])\.(\d{1,2}|1[0-9]{1,2}|[1-2][0-5]{2})\.(\d{1,2}|1[0-9]{1,2}|[1-2][0-5]{2})\.(\d{1,2}|1[0-9]{1,2}|[1-2][0-5]{2})$"; 

               if( !Regex.IsMatch(value , pattern) ) 
               { 
                _text = ""; 
                throw new Exception("IP ��ַ��ʽ����"); 
               } 
               else 
               { 
                string[] ipnum = value.Split('.'); 
                textBox1.Text = ipnum[0]; 
                textBox2.Text = ipnum[1]; 
                textBox3.Text = ipnum[2]; 
                textBox4.Text = ipnum[3]; 
               } 
              } 

              _text = value; 

             } 
            */

        }

        //�ӹ������ϳ���ʱ�����ؼ�����ʱ����������ٵ�
        private void SetTextBox(string[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                string val = nums[i];
                if (Regex.IsMatch(val, @"\d"))
                {
                    int num = Int32.Parse(val);
                    if (i == 0)
                    {
                        if (_inputType == InputType.IPAddress)
                        {
                            if (num < 1 && num > 233)
                            {
                                if (_showErrorFlag)
                                    errVerify.SetError(this, "��Ч�� IP ��ַ��");
                            }
                        }
                        else
                        {
                            if (num < 0 && num > 255)
                            {
                                if (_showErrorFlag)
                                    errVerify.SetError(this, "��Ч�� IP ��ַ��");
                            }
                        }
                        textBox1.Text = num.ToString();
                    }
                    if (i > 0)
                    {
                        if (num < 0 && num > 255)
                        {
                            if (_showErrorFlag)
                                errVerify.SetError(this, "��Ч�� IP ��ַ��");
                        }
                        if (i == 1)
                            textBox2.Text = num.ToString();
                        else if (i == 2)
                            textBox3.Text = num.ToString();
                        else
                            textBox4.Text = num.ToString();
                    }
                }
            }
        }

        /// <summary>
        /// ����IPΪ��
        /// </summary>
        private void SetIPEmptyValue()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        #endregion

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            string num = textBox1.Text;
            if (_inputType == InputType.IPAddress)
            {
                if (num.Trim() != "")
                {
                    if (num == "0")
                    {
                        string msg = "0 ����һ����Ч��Ŀ����ָ��һ������ 1 �� 223 ֮�����ֵ��";
                        if (_showErrorFlag)
                        {
                            errVerify.SetError(this, msg);
                        }
                        else
                        {
                            //MessageBox.Show(msg, "����",
                            //    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            ShowError(msg);
                        }
                        textBox1.Text = "1";
                    }
                }
            }
        }

        private void IPBox_Validated(object sender, EventArgs e)
        {
            errVerify.SetError(this, "");
        }
    }
    /// <summary>
    /// ��������
    /// </summary>
    public enum InputType
    {
        /// <summary>
        /// IP��ַ
        /// </summary>
        IPAddress,
        /// <summary>
        /// ����
        /// </summary>
        Gateway
    }
}
