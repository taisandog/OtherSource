using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;


public partial class UIMessageBox : UserControl
{
    int MaxLength = 0;
    public UIMessageBox()
    {
        InitializeComponent();
    }
    /// <summary>
    /// 浮动按钮按下
    /// </summary>
    public event EventHandler OnFlowButtonClick;
    /// <summary>
    /// 点击单元格
    /// </summary>
    public event DataGridViewCellEventHandler OnCellClick;
    private static readonly Color LogColor = Color.Black;
    private static readonly Color WarningColor = Color.FromArgb(218, 128, 0);
    private static readonly Color ErrorColor = Color.FromArgb(255, 0, 0);
    public bool ShowLog
    {
        get
        {
            return Cbx_Normal.Checked;
        }
        set
        {
            Cbx_Normal.Checked = value;
        }
    }
    public bool ShowError
    {
        get
        {
            return Cbx_Error.Checked;
        }
        set
        {
            Cbx_Error.Checked = value;
        }
    }
    public bool ShowWarning
    {
        get
        {
            return Cbx_Warning.Checked;
        }
        set
        {
            Cbx_Warning.Checked = value;
        }
    }
    public int MaxRow
    {
        get
        {
            return (int)nupMax.Value;
        }
        set
        {
            nupMax.Value = value;
        }
    }

    public void Log(string message, DateTime createTime, bool isServer = false)
    {
        if (string.IsNullOrWhiteSpace(message) || !ShowLog)
        {
            return;
        }
        if (ParentForm == null || this.IsDisposed || ParentForm.IsDisposed)
        {
            return;
        }
        string title = "本地消息";
        if (isServer) 
        {
            title = "服务消息";
        }
        
        this.Invoke((EventHandler)delegate
        {
            if (!ShowLog)
            {
                return;
            }
            dgDisplay.Rows.Add(title, message, createTime);
            dgDisplay.Rows[dgDisplay.Rows.Count - 1].DefaultCellStyle.ForeColor = LogColor;
            CheckRow();
        });
    }

    /// <summary>
    /// 浮动按钮可见
    /// </summary>
    public bool FlowButtnVisable 
    {
        get 
        {

            return btnFlow.Visible;
        }
        set 
        { 
            btnFlow.Visible = value;
            
        }
    }


    public void Log(string message)
    {
        Log(message, DateTime.Now);
    }


    public void LogError(string message, DateTime createTime,bool isServer=false)
    {
        if (string.IsNullOrWhiteSpace(message) || !ShowError)
        {
            return;
        }
        if (ParentForm==null || this.IsDisposed || ParentForm.IsDisposed)
        {
            return;
        }
        string title = "本地错误";
        if (isServer)
        {
            title = "服务错误";
        }
        try
        {
            this.Invoke((EventHandler)delegate
            {
                if (!ShowError)
                {
                    return;
                }
                dgDisplay.Rows.Add(title, message, createTime);
                dgDisplay.Rows[dgDisplay.Rows.Count - 1].DefaultCellStyle.ForeColor = ErrorColor;
                CheckRow();
            });
        }
        catch { }
        //ApplicationLog.LogError(message);
    }
    public void LogError(string message)
    {
        LogError(message, DateTime.Now);
    }

    private void CheckRow()
    {
        int max = (int)nupMax.Value;
        while (dgDisplay.Rows.Count > max)
        {
            dgDisplay.Rows.RemoveAt(0);
        }
        dgDisplay.CurrentCell = dgDisplay.Rows[dgDisplay.Rows.Count - 1].Cells[0];
        dgDisplay.CurrentCell = null;
    }

    public void LogWarning(string message,DateTime createDate, bool isServer = false)
    {
        if (ParentForm == null || this.IsDisposed || ParentForm.IsDisposed)
        {
            return;
        }
        if (this.IsDisposed)
        {
            return;
        }
        string title = "本地警告";
        if (isServer)
        {
            title = "服务警告";
        }
        this.Invoke((EventHandler)delegate
        {
            if (!ShowWarning) 
            {
                return;
            }
            dgDisplay.Rows.Add(title, message, createDate);
            dgDisplay.Rows[dgDisplay.Rows.Count - 1].DefaultCellStyle.ForeColor = WarningColor;
            CheckRow();
        });
    }

    public void LogWarning(string message)
    {
        LogWarning(message, DateTime.Now);
    }

    private void tsCopy_Click(object sender, EventArgs e)
    {
        DataGridViewRow row = dgDisplay.CurrentRow;
        if (row == null)
        {
            return;
        }
        //sb.AppendLine("===="+row.Cells[0].Value + ":" + row.Cells[2].Value+ "====");

        StringBuilder sb = new StringBuilder();
        sb.Append("====");
        sb.Append(row.Cells[0].Value.ToString());
        sb.Append(":");
        sb.Append(row.Cells[2].Value.ToString());
        sb.AppendLine("====");
        sb.AppendLine(row.Cells[1].Value.ToString());
        Clipboard.SetDataObject(sb.ToString());
    }

    private void dgDisplay_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
        {
            dgDisplay.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
        }
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
        dgDisplay.Rows.Clear();
    }

    private void btnFlow_Click(object sender, EventArgs e)
    {
        if (OnFlowButtonClick != null) 
        {
            OnFlowButtonClick(sender, e);
        }
    }

    private void dgDisplay_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        if (OnCellClick != null)
        {
            OnCellClick(sender, e);
        }
    }

    //private void MessageBox_SizeChanged(object sender, EventArgs e)
    //{
    //    Console.WriteLine("尺寸------"+richTextBox1.Height);            
    //    MaxLength = (richTextBox1.Height / (richTextBox1.Font.Height + 2) - 1);
    //    Console.WriteLine("数量" + MaxLength);
    //    if (MaxLength < 10)
    //    {
    //        MaxLength = 10;
    //    }
    //}

}


