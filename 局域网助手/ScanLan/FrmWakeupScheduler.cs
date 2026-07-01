using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ScanLan
{
    /// <summary>
    /// 定时唤醒任务管理
    /// </summary>
    public partial class FrmWakeupScheduler : Form
    {
        public FrmWakeupScheduler()
        {
            InitializeComponent();
        }

        private List<WakeupTask> _tasks;

        private void FrmWakeupScheduler_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void LoadGrid()
        {
            _tasks = WakeupTaskManager.LoadTasks();
            dgTasks.Rows.Clear();
            foreach (WakeupTask task in _tasks)
            {
                int i = dgTasks.Rows.Add();
                DataGridViewRow row = dgTasks.Rows[i];
                row.Cells["ColTaskName"].Value = task.TaskName;
                row.Cells["ColTime"].Value = task.GetTimeText();
                row.Cells["ColMode"].Value = task.GetModeText();
                row.Cells["ColMac"].Value = task.MacDisplay;
                row.Cells["ColEnabled"].Value = task.Enabled ? "启用" : "停用";
                row.Tag = task;
            }
        }

        private WakeupTask GetSelectedTask()
        {
            if (dgTasks.SelectedRows.Count == 0)
            {
                return null;
            }
            return dgTasks.SelectedRows[0].Tag as WakeupTask;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            WakeupTask task = FrmAddWakeupTask.ShowAdd("", "");
            if (task == null)
            {
                return;
            }
            _tasks.Add(task);
            WakeupTaskManager.SaveTasks(_tasks);
            LoadGrid();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            WakeupTask task = GetSelectedTask();
            if (task == null)
            {
                MessageBox.Show("请先选择一条任务", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            WakeupTask result = FrmAddWakeupTask.ShowEdit(task);
            if (result == null)
            {
                return;
            }
            WakeupTaskManager.SaveTasks(_tasks);
            LoadGrid();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            WakeupTask task = GetSelectedTask();
            if (task == null)
            {
                MessageBox.Show("请先选择一条任务", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("确定要删除任务[" + task.TaskName + "]吗?", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }
            _tasks.Remove(task);
            WakeupTaskManager.SaveTasks(_tasks);
            LoadGrid();
        }

        private void BtnEnable_Click(object sender, EventArgs e)
        {
            WakeupTask task = GetSelectedTask();
            if (task == null)
            {
                MessageBox.Show("请先选择一条任务", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            task.Enabled = !task.Enabled;
            WakeupTaskManager.SaveTasks(_tasks);
            LoadGrid();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DgTasks_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            BtnEdit_Click(sender, e);
        }
    }
}
