using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ScanLan
{
    /// <summary>
    /// 定时唤醒任务的读写管理
    /// </summary>
    public static class WakeupTaskManager
    {
        private static readonly string TaskFile = AppDomain.CurrentDomain.BaseDirectory + "\\WakeupTasks.json";

        /// <summary>
        /// 读取所有定时唤醒任务
        /// </summary>
        public static List<WakeupTask> LoadTasks()
        {
            if (!File.Exists(TaskFile))
            {
                return new List<WakeupTask>();
            }
            try
            {
                string content = File.ReadAllText(TaskFile, Encoding.UTF8);
                List<WakeupTask> lst = JsonConvert.DeserializeObject<List<WakeupTask>>(content);
                return lst ?? new List<WakeupTask>();
            }
            catch
            {
                return new List<WakeupTask>();
            }
        }

        /// <summary>
        /// 保存所有定时唤醒任务
        /// </summary>
        public static void SaveTasks(List<WakeupTask> tasks)
        {
            string content = JsonConvert.SerializeObject(tasks, Formatting.Indented);
            File.WriteAllText(TaskFile, content, Encoding.UTF8);
        }
    }
}
