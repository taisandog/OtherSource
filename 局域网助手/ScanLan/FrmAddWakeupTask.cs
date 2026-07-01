using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ScanLan
{
    /// <summary>
    /// 添加/编辑定时唤醒任务
    /// </summary>
    public partial class FrmAddWakeupTask : Form
    {
        public FrmAddWakeupTask()
        {
            InitializeComponent();
        }

        private WakeupTask _editingTask;
        private CheckBox[] _weekChecks;

        /// <summary>
        /// 添加后的结果任务
        /// </summary>
        public WakeupTask Result { get; private set; }

        /// <summary>
        /// 弹出添加对话框
        /// </summary>
        /// <param name="macDisplay">预填的MAC地址，可为空</param>
        /// <param name="hostName">预填的备注名，可为空</param>
        public static WakeupTask ShowAdd(string macDisplay, string hostName)
        {
            using (FrmAddWakeupTask frm = new FrmAddWakeupTask())
            {
                frm.Text = "添加到定时唤醒";
                frm.txtMac.Text = macDisplay;
                frm.txtHostName.Text = hostName;
                frm.StartPosition = FormStartPosition.CenterParent;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    return frm.Result;
                }
            }
            return null;
        }

        /// <summary>
        /// 弹出编辑对话框
        /// </summary>
        public static WakeupTask ShowEdit(WakeupTask task)
        {
            using (FrmAddWakeupTask frm = new FrmAddWakeupTask())
            {
                frm.Text = "编辑定时唤醒";
                frm._editingTask = task;
                frm.StartPosition = FormStartPosition.CenterParent;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    return frm.Result;
                }
            }
            return null;
        }

        private void FrmAddWakeupTask_Load(object sender, EventArgs e)
        {
            _weekChecks = new CheckBox[] { chkWeek0, chkWeek1, chkWeek2, chkWeek3, chkWeek4, chkWeek5, chkWeek6 };

            if (_editingTask != null)
            {
                txtMac.Text = _editingTask.MacDisplay;
                txtHostName.Text = _editingTask.HostName;
                txtTaskName.Text = _editingTask.TaskName;
                dtpTime.Value = DateTime.Today.AddHours(_editingTask.Hour).AddMinutes(_editingTask.Minute);
                switch (_editingTask.Mode)
                {
                    case WakeupMode.Weekly:
                        radWeekly.Checked = true;
                        if (_editingTask.WeekDays != null)
                        {
                            foreach (int d in _editingTask.WeekDays)
                            {
                                if (d >= 0 && d < _weekChecks.Length)
                                {
                                    _weekChecks[d].Checked = true;
                                }
                            }
                        }
                        break;
                    case WakeupMode.Monthly:
                        radMonthly.Checked = true;
                        nudMonthDay.Value = _editingTask.DayValue;
                        break;
                    default:
                        radDaily.Checked = true;
                        break;
                }
            }
            else
            {
                radDaily.Checked = true;
                _weekChecks[(int)DateTime.Now.DayOfWeek].Checked = true;
                nudMonthDay.Value = DateTime.Now.Day;
                dtpTime.Value = DateTime.Now;
                if (string.IsNullOrEmpty(txtTaskName.Text))
                {
                    string name = string.IsNullOrEmpty(txtHostName.Text) ? txtMac.Text : txtHostName.Text;
                    txtTaskName.Text = name + "定时唤醒";
                }
            }

            UpdateModeControls();
        }

        private void RadMode_CheckedChanged(object sender, EventArgs e)
        {
            UpdateModeControls();
        }

        private void UpdateModeControls()
        {
            pnlWeekDays.Visible = radWeekly.Checked;
            nudMonthDay.Visible = radMonthly.Checked;
        }

        private List<int> GetCheckedWeekDays()
        {
            List<int> days = new List<int>();
            for (int i = 0; i < _weekChecks.Length; i++)
            {
                if (_weekChecks[i].Checked)
                {
                    days.Add(i);
                }
            }
            return days;
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            string name = txtTaskName.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("请输入任务名", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MacInfo mac;
            if (!MacInfo.TryParse(txtMac.Text, out mac))
            {
                MessageBox.Show("请输入正确的MAC地址，如 AA-BB-CC-DD-EE-FF", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<int> weekDays = null;
            if (radWeekly.Checked)
            {
                weekDays = GetCheckedWeekDays();
                if (weekDays.Count == 0)
                {
                    MessageBox.Show("请至少选择一个星期几", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            WakeupTask task = _editingTask ?? new WakeupTask();
            task.TaskName = name;
            task.MacValue = mac.Mac;
            task.MacDisplay = mac.ToString();
            task.HostName = txtHostName.Text.Trim();
            task.Hour = dtpTime.Value.Hour;
            task.Minute = dtpTime.Value.Minute;
            task.LastRunDate = null;

            if (radWeekly.Checked)
            {
                task.Mode = WakeupMode.Weekly;
                task.WeekDays = weekDays;
            }
            else if (radMonthly.Checked)
            {
                task.Mode = WakeupMode.Monthly;
                task.DayValue = (int)nudMonthDay.Value;
                task.WeekDays = new List<int>();
            }
            else
            {
                task.Mode = WakeupMode.Daily;
                task.WeekDays = new List<int>();
            }

            Result = task;
            DialogResult = DialogResult.OK;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
