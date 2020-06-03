using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskScheduler;

namespace ConfigPictures
{
    /// <summary>
    /// 计划任务工具
    /// </summary>
    public class TaskSchedulerUnit
    {
        /// <summary>
        /// 删除计划任务
        /// </summary>
        /// <param name="taskName"></param>
        public static void DeleteTask(string taskName)
        {
            TaskSchedulerClass ts = new TaskSchedulerClass();
            ts.Connect(null, null, null, null);
            ITaskFolder folder = ts.GetFolder("\\");
            folder.DeleteTask(taskName, 0);
        }
        /// <summary>
        /// 获取所有计划任务
        /// </summary>
        public static IRegisteredTaskCollection GetAllTasks()
        {
            TaskSchedulerClass ts = new TaskSchedulerClass();
            ts.Connect(null, null, null, null);
            ITaskFolder folder = ts.GetFolder("\\");
            IRegisteredTaskCollection tasks_exists = folder.GetTasks(1);
            return tasks_exists;
        }

        /// <summary>
        /// 查找任务
        /// </summary>
        /// <param name="taskName"></param>
        /// <returns></returns>
        public static IRegisteredTask FindTask(string taskName)
        {
            IRegisteredTaskCollection tasks_exists = GetAllTasks();
            for (int i = 1; i <= tasks_exists.Count; i++)
            {
                IRegisteredTask t = tasks_exists[i];
                if (t.Name.Equals(taskName))
                {
                    return t;
                }
            }
            return null;
        }
        /// <summary>
        /// 计划任务是否存在
        /// </summary>
        /// <param name="taskName"></param>
        /// <returns></returns>
        public static bool IsExists(string taskName)
        {
            
            return FindTask(taskName)!=null;
        }

        /// <summary>
        /// 创建计划任务
        /// </summary>
        /// <param name="creator">创建人</param>
        /// <param name="taskName">计划任务名称</param>
        /// <param name="path">执行文件的路径</param>
        /// <param name="intervalMintue">计划任务执行的频率(分钟)</param>
        /// <param name="startBoundary">开始时间(默认是DateTime.MinValue)</param>
        /// <param name="endBoundary">结束时间(默认是DateTime.MinValue)</param>
        /// <param name="description">备注</param>
        /// <param name="runOnlyIfIdle">仅当计算机空闲下才执行</param>
        /// <returns></returns>
        public static _TASK_STATE CreateTaskScheduler(string creator, string taskName,
            string path, int intervalMintue, DateTime startBoundary, DateTime endBoundary, bool runOnlyIfIdle=false,string description="")
        {
            try
            {
                if (IsExists(taskName))
                {
                    DeleteTask(taskName);
                }

                //new scheduler
                TaskSchedulerClass scheduler = new TaskSchedulerClass();
                //pc-name/ip,username,domain,password
                scheduler.Connect(null, null, null, null);
                //get scheduler folder
                ITaskFolder folder = scheduler.GetFolder("\\");


                //set base attr 
                ITaskDefinition task = scheduler.NewTask(0);
                task.RegistrationInfo.Author = creator;//creator
                task.RegistrationInfo.Description = description;//description

                //set trigger  (IDailyTrigger ITimeTrigger)
                ITimeTrigger tt = (ITimeTrigger)task.Triggers.Create(_TASK_TRIGGER_TYPE2.TASK_TRIGGER_TIME);
                tt.Repetition.Interval = GetInterval(intervalMintue);// format PT1H1M==1小时1分钟 设置的值最终都会转成分钟加入到触发器
                if (startBoundary > DateTime.MinValue)
                {
                    tt.StartBoundary = startBoundary.ToString("yyyy-MM-ddTHH:mm:ss");//start time
                }
                else
                {
                    tt.StartBoundary = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");//start time
                }
                if (startBoundary > DateTime.MinValue)
                {
                    tt.EndBoundary = startBoundary.ToString("yyyy-MM-ddTHH:mm:ss"); ;
                }
                //set action
                IExecAction action = (IExecAction)task.Actions.Create(_TASK_ACTION_TYPE.TASK_ACTION_EXEC);
                action.Path = path;//计划任务调用的程序路径

                task.Settings.ExecutionTimeLimit = "PT0S"; //运行任务时间超时停止任务吗? PTOS 不开启超时
                task.Settings.DisallowStartIfOnBatteries = false;//只有在交流电源下才执行
                task.Settings.RunOnlyIfIdle = false;//仅当计算机空闲下才执行

                IRegisteredTask regTask = folder.RegisterTaskDefinition(taskName, task,
                                                                    (int)_TASK_CREATION.TASK_CREATE, null, //user
                                                                    null, // password
                                                                    _TASK_LOGON_TYPE.TASK_LOGON_INTERACTIVE_TOKEN,
                                                                    "");
                IRunningTask runTask = regTask.Run(null);
                return runTask.State;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// 获取间隔
        /// </summary>
        /// <returns></returns>
        private static string GetInterval(int mintue)
        {
            //int totalmin = (int)nupMintue.Value;
            return System.Xml.XmlConvert.ToString(TimeSpan.FromMinutes(mintue));
        }

        /// <summary>
        /// 获取间隔
        /// </summary>
        /// <returns></returns>
        public static TimeSpan GetTimeSpan(string interval)
        {
            //int totalmin = (int)nupMintue.Value;
            return System.Xml.XmlConvert.ToTimeSpan(interval);
        }
    }
}
