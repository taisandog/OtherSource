using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
namespace ScanLan.Controls
{
    [ToolboxBitmap(typeof(TextBox))]
    public partial class NumericText : TextBox
    {
        private decimal _Max = decimal.MaxValue;
        /// <summary>
        /// 可输入的最大值
        /// </summary>
        [Description("可输入的最大值")]
        public decimal Max
        {
            get { return _Max; }
            set { _Max = value; }
        }

        private decimal _Min = decimal.MinValue;
        /// <summary>
        /// 可输入的最小值
        /// </summary>
        [Description("可输入的最小值")]
        public decimal Min
        {
            get { return _Min; }
            set { _Min = value; }
        }

        private int _decimalPlaces = -1;

        /// <summary>
        /// 小数位数(小于0则表示无规定)
        /// </summary>
        [Description("小数位数(小于0则表示无规定)")]
        public int DecimalPlaces
        {
            get { return _decimalPlaces; }
            set { _decimalPlaces = value; }
        }


        /// <summary>
        /// 值
        /// </summary>
        [Description("值")]
        public decimal Value
        {
            get
            {
                decimal d;
                if (decimal.TryParse(this.Text, out d))
                {
                    return d;
                }
                return 0;
            }
            set 
            {
                if (_decimalPlaces > 0)
                {
                    this.Text = value.ToString("N" + _decimalPlaces);
                }
                else 
                {
                    this.Text = value.ToString();
                }
            }
        }

        public NumericText()
        {
            InitializeComponent();
            MaxLength = 12;
        }

        public NumericText(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            MaxLength = 12;
        }

        
        

        private List<char> _AllowKey = new List<char>(new char[]{'\b'});


        string lastText = "";

        protected override void OnTextChanged(EventArgs e)
        {
            
            if (!IsCorrect(this.Text))
            {
                int sel = this.SelectionStart;
                if (sel > 0)
                {
                    Text = lastText;
                    this.SelectionStart = sel - 1;
                }
                return;
            }
            lastText = Text;
            base.OnTextChanged(e);
        }

        /// <summary>
        /// 验证事件
        /// </summary>
        /// <param name="e"></param>
        protected override void OnValidating(CancelEventArgs e)
        {
            if (!IsCorrect(this.Text) || this.Text == "-")
            {
                Text = "0";
                return;
            }
            this.Text = decimal.Parse(this.Text).ToString();
            base.OnValidating(e);
        }

        //protected override void OnKeyPress(KeyPressEventArgs e)
        //{
        //    base.OnKeyPress(e);

        //    if (!Multiline)
        //    {
        //        if (e.KeyChar == (char)13 && _nextControl!=null)
        //        {
        //            _nextControl.Focus();
        //        }
        //    }
        //}

        private const int WM_GETTEXT=0x000d;
        private const int WM_COPY = 0x0301;
        private const int WM_PASTE = 0x0302;
        private const int WM_CONTEXTMENU = 0x007B;
        private const int WM_RBUTTONDOWN = 0x0204;
        protected override void WndProc(ref   Message m)
        {
            if (m.Msg == WM_PASTE)
            {
                PasteFromClip();
                return;
            }
            base.WndProc(ref   m);
        }

        private void PasteFromClip()
        {
            string data = this.Text + Clipboard.GetText();
            if (IsCorrect(data))
            {
                this.Text = data;
            }
        }

        private ToolTip _CurToolTip = null;
        private ToolTip CurToolTip
        {
            get
            {
                if (_CurToolTip == null)
                {
                    _CurToolTip = new ToolTip();
                    _CurToolTip.AutomaticDelay = 5000;
                    _CurToolTip.ShowAlways = true;
                    _CurToolTip.ToolTipTitle = "说明:";
                }
                return _CurToolTip;
            }
        }
        private bool IsCorrect(string data)
        {
            if (data == "-")
            {
                return true;
            }
            
            decimal d = 0;
            if (!decimal.TryParse(data, out d))
            {
                CurToolTip.Show("输入必须为数字", this);
                return false;
            }
            if (_decimalPlaces >= 0)
            {
                long places = (long)Math.Pow(10, _decimalPlaces);
                decimal dec = places * d;
                if (dec % 1 > 0) 
                {
                    CurToolTip.Show("输入小数不能超过" + _decimalPlaces, this);
                    return false;
                }
            }
            if (d > Max)
            {
                CurToolTip.Show("输入最大不能超过" + Max, this);
                return false;
            }
            if (d < Min)
            {
                CurToolTip.Show("输入最小不能小于" + Min, this);
                return false;
            }
            return true;
        }        
    }
}
