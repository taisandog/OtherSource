using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ScanLan
{
    /// <summary>
    /// 定时唤醒的后台执行服务
    /// </summary>
    public class WakeupSchedulerService
    {
        private Timer _timer;

        /// <summary>
        /// 启动定时检查
        /// </summary>
        public void Start()
        {
            if (_timer != null)
            {
                return;
            }
            _timer = new Timer();
            _timer.Interval = 20000;
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }

        /// <summary>
        /// 停止定时检查
        /// </summary>
        public void Stop()
        {
            if (_timer == null)
            {
                return;
            }
            _timer.Stop();
            _timer.Tick -= Timer_Tick;
            _timer.Dispose();
            _timer = null;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            CheckAndRun();
        }

        /// <summary>
        /// 检查所有任务，触发到点的唤醒
        /// </summary>
        private void CheckAndRun()
        {
            List<WakeupTask> tasks = WakeupTaskManager.LoadTasks();
            if (tasks.Count == 0)
            {
                return;
            }
            DateTime now = DateTime.Now;
            bool changed = false;
            foreach (WakeupTask task in tasks)
            {
                if (!task.Enabled)
                {
                    continue;
                }
                if (task.Hour != now.Hour || task.Minute != now.Minute)
                {
                    continue;
                }
                if (task.LastRunDate.HasValue && task.LastRunDate.Value.Date == now.Date)
                {
                    continue;
                }
                if (!IsDueToday(task, now))
                {
                    continue;
                }
                try
                {
                    LanMachine machine = new LanMachine();
                    machine.Mac = new MacInfo(task.MacValue);
                    machine.WakeOnLan();
                }
                catch { }
                task.LastRunDate = now.Date;
                changed = true;
            }
            if (changed)
            {
                WakeupTaskManager.SaveTasks(tasks);
            }
        }

        private static bool IsDueToday(WakeupTask task, DateTime now)
        {
            switch (task.Mode)
            {
                case WakeupMode.Daily:
                    return true;
                case WakeupMode.Weekly:
                    return task.WeekDays != null && task.WeekDays.Contains((int)now.DayOfWeek);
                case WakeupMode.Monthly:
                    return now.Day == task.DayValue;
                default:
                    return false;
            }
        }
    }
}
