using System;
using System.Collections.Generic;

namespace ScanLan
{
    /// <summary>
    /// 定时唤醒的重复模式
    /// </summary>
    public enum WakeupMode
    {
        /// <summary>
        /// 每天
        /// </summary>
        Daily = 0,
        /// <summary>
        /// 每周
        /// </summary>
        Weekly = 1,
        /// <summary>
        /// 每月
        /// </summary>
        Monthly = 2
    }

    /// <summary>
    /// 一条定时唤醒计划任务
    /// </summary>
    public class WakeupTask
    {
        public WakeupTask()
        {
            Id = Guid.NewGuid().ToString();
            Enabled = true;
            WeekDays = new List<int>();
        }

        /// <summary>
        /// 唯一标识
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 任务名
        /// </summary>
        public string TaskName { get; set; }

        /// <summary>
        /// MAC地址数值
        /// </summary>
        public long MacValue { get; set; }

        /// <summary>
        /// MAC地址显示文本
        /// </summary>
        public string MacDisplay { get; set; }

        /// <summary>
        /// 主机名/备注名
        /// </summary>
        public string HostName { get; set; }

        /// <summary>
        /// 重复模式
        /// </summary>
        public WakeupMode Mode { get; set; }

        /// <summary>
        /// 每周模式下要唤醒的星期几列表(0=周日..6=周六)，可多选
        /// </summary>
        public List<int> WeekDays { get; set; }

        /// <summary>
        /// 每月模式下的日期(1-31)
        /// </summary>
        public int DayValue { get; set; }

        /// <summary>
        /// 唤醒小时(0-23)
        /// </summary>
        public int Hour { get; set; }

        /// <summary>
        /// 唤醒分钟(0-59)
        /// </summary>
        public int Minute { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// 最后一次触发的日期，用于避免同一天重复触发
        /// </summary>
        public DateTime? LastRunDate { get; set; }

        /// <summary>
        /// 获取模式的显示文本
        /// </summary>
        public string GetModeText()
        {
            switch (Mode)
            {
                case WakeupMode.Daily:
                    return "每天";
                case WakeupMode.Weekly:
                    return "每周" + GetWeekDaysText();
                case WakeupMode.Monthly:
                    return "每月" + DayValue.ToString() + "号";
                default:
                    return "";
            }
        }

        /// <summary>
        /// 获取每周选中的星期文本，如"一、三、四"
        /// </summary>
        private string GetWeekDaysText()
        {
            if (WeekDays == null || WeekDays.Count == 0)
            {
                return "";
            }
            List<int> sorted = new List<int>(WeekDays);
            sorted.Sort();
            List<string> names = new List<string>();
            foreach (int d in sorted)
            {
                names.Add(GetWeekDayText(d));
            }
            return string.Join("、", names.ToArray());
        }

        private static readonly string[] WeekDayNames = { "日", "一", "二", "三", "四", "五", "六" };

        public static string GetWeekDayText(int dayOfWeek)
        {
            if (dayOfWeek < 0 || dayOfWeek > 6)
            {
                return "";
            }
            return WeekDayNames[dayOfWeek];
        }

        /// <summary>
        /// 获取唤醒时间的显示文本
        /// </summary>
        public string GetTimeText()
        {
            return Hour.ToString("D2") + ":" + Minute.ToString("D2");
        }
    }
}
