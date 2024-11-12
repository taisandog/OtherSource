
using AppMonitor;
using Buffalo.ArgCommon;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDaemon
{
    /// <summary>
    /// 进程项
    /// </summary>
    public class ProcessItem
    {
        private ProcessManager _parent;


        /// <summary>
        /// CPU计数器
        /// </summary>
        private PerformanceCounter _useCPUCounter;
        /// <summary>
        /// 高CPU占用次数
        /// </summary>
        private int _curhighCPUload = 0;
        /// <summary>
        /// 高CPU占用率
        /// </summary>
        private const float HighCPULoad = 80;
        /// <summary>
        /// 检测出连续几次高占用就重启程序
        /// </summary>
        private const int RestartHighCPUCount = 10;
        /// <summary>
        /// 是否需要检查高CPU和内存占用
        /// </summary>
        private bool _needCheckRestart;
        /// <summary>/// <summary>
        /// 立即重启内存数
        /// </summary>
        private long _immRestart = long.MaxValue;

        private string _processArgs;
        /// 进程项
        /// </summary>
        /// <param name="serverName">服务器Key</param>
        /// <param name="path">文件名</param>
        /// <param name="name">服务名字</param>
        public ProcessItem(string name, string serverName, string processArgs, string path,bool autoRunning, ProcessManager parent, bool needCheckRestart, long immRestartMB)
        {
            _name = name;
            _serverName = serverName;
            _path = path;
            _isRunning = autoRunning;
            _parent = parent;
            _needCheckRestart = needCheckRestart;
            _processArgs = processArgs;
            if (immRestartMB > 0)
            {
                _immRestart = immRestartMB * 1024 * 1024;
            }
        }
        /// <summary>
        /// 立即重启内存数
        /// </summary>
        public long ImmRestart
        {
            get
            {
                return _immRestart;
            }
        }
        ///// <summary>
        ///// 重启内存
        ///// </summary>
        //public const long RestartMemory =  800 * 1024L * 1024L;//800M

        private Process _appProcess;
        /// <summary>
        /// 程序进程
        /// </summary>
        public Process AppProcess
        {
            get
            {
                return _appProcess;
            }
            set
            {
                _appProcess = value;
                if (_appProcess == null)
                {
                    _useCPUCounter = null;
                }
                else
                {
                    string pName = GetProcessInstanceName(_appProcess.Id);
                    _useCPUCounter = new PerformanceCounter("Process", "% Processor Time", pName);
                }
            }
        }

        private bool _isRunning;

        /// <summary>
        /// 服务器是否运行中
        /// </summary>
        public bool IsServerRunning
        {
            get
            {
                
                return _isRunning;
            }
            set
            {
                _isRunning = value;
            }
        }

        private long _useMemory;
        /// <summary>
        /// 使用内存
        /// </summary>
        public long UseMemory
        {
            get
            {
                return _useMemory;

            }

        }
       
        private float _useCPU;
        /// <summary>
        /// CPU使用率
        /// </summary>
        public float UseCPU
        {
            get
            {
                return _useCPU;

            }

        }
        /// <summary>
        /// 进程是否在运行
        /// </summary>
        public bool HasAppRunning
        {
            get
            {
                return _appProcess != null && (!_appProcess.HasExited);
            }
        }

        /// <summary>
        /// 刷新使用内存
        /// </summary>
        internal void RefreashMemory()
        {
            _useMemory = 0;

            try
            {
                _appProcess.Refresh();
                _useMemory = _appProcess.WorkingSet64;
            }
            catch (Exception ex)
            {
                _parent.LogError(ex.ToString());
            }
        }

        /// <summary>
        /// 刷新使用CPU
        /// </summary>
        internal void RefreashCPU()
        {
            _useCPU = 0;

            try
            {
                if (_useCPUCounter != null)
                {
                    _useCPU = _useCPUCounter.NextValue();
                }
            }
            catch (Exception ex)
            {
                _parent.LogError(ex.ToString());
            }
        }

        private string _serverName;
        /// <summary>
        /// 服务名
        /// </summary>
        public string ServerName
        {
            get
            {
                return _serverName;
            }

        }
        /// <summary>
        /// 状态
        /// </summary>
        public string StateText
        {
            get
            {
                if (!IsServerRunning)
                {
                    return "已停止";
                }
                
                return "正常";
            }
        }
        /// <summary>
        /// 设置重启的时间
        /// </summary>
        private DateTime _setRestartTime = DateTime.MinValue;

        


        private string _path;
        /// <summary>
        /// 主文件路径
        /// </summary>
        public string Path
        {
            get
            {
                return _path;
            }

        }
        private string _name;
        /// <summary>
        /// 服务名
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
        }
        /// <summary>
        /// 检查进程存活
        /// </summary>
        public void CheckProcessActive(string message = null)
        {

            if (!HasAppRunning)
            {
                if (!File.Exists(_path))
                {
                    return;
                }


                AppProcess = Process.Start(_path, _processArgs);
                if (string.IsNullOrWhiteSpace(message))
                {
                    _parent.LogRestart(Name + "意外终止，正重新启动");
                }
                else
                {
                    _parent.LogRestart(message);
                }
                return;
            }

        }
        /// <summary>
        /// 检测是否需要重启
        /// </summary>
        public void CheckRestartFail()
        {
            CheckProcessActive("["+ Name + "]，自动重启失败，正在启动...");
        }
        
        /// <summary>
        /// 检测是否需要重启
        /// </summary>
        public void CheckRestart()
        {
            if (UseMemory >= AppHandle.RestartMemory)
            {
                if ((DateTime.Now.Hour==_parent.RestartHour|| UseMemory>=_immRestart) && IsServerRunning )
                {
                    _parent.LogRestart(Name + "的内存到达:" + UseMemory + "，现在进行重启");
                    AppHandle.SendRestart(_appProcess);
                    return;
                }
            }

            if (!NeedCheckCPU)
            {
                CheckCPU();
            }
        }
        /// <summary>
        /// 是否需要连续检查CPU
        /// </summary>
        public bool NeedCheckCPU
        {
            get
            {
                return _curhighCPUload > 0;
            }
        }

        /// <summary>
        /// 检查CPU占用
        /// </summary>
        public void CheckCPU()
        {
            if (_useCPU > HighCPULoad && _needCheckRestart)
            {
                _curhighCPUload++;
                if (_curhighCPUload >= RestartHighCPUCount && IsServerRunning)
                {
                    string message = Name + "的CPU占用在连续" + RestartHighCPUCount + "次到达:" + HighCPULoad + "，现在进行重启";
                    _parent.LogRestart(message);
                    AppHandle.SendRestart(_appProcess);
                }
            }
            else
            {
                _curhighCPUload = 0;
            }
        }
        /// <summary>
        /// 获取进程名
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        private string GetProcessInstanceName(int pid)
        {
            var category = new PerformanceCounterCategory("Process");

            var instances = category.GetInstanceNames();
            foreach (var instance in instances)
            {

                using (PerformanceCounter counter = new PerformanceCounter(category.CategoryName,
                     "ID Process", instance, true))
                {
                    int val = (int)counter.RawValue;
                    if (val == pid)
                    {
                        return instance;
                    }
                }
            }
            return null;
        }
        /// <summary>
        /// 打开程序
        /// </summary>
        public APIResault StartProcess()
        {
            if (!HasAppRunning)
            {
                if (!File.Exists(_path))
                {
                    return ApiCommon.GetFault(_path+" 文件不存在"); 
                }
                AppProcess = Process.Start(_path, _processArgs);
            }
            else
            {
                
            }
            return ApiCommon.GetSuccess("打开完毕");
        }
        /// <summary>
        /// 发送重启指令
        /// </summary>
        public APIResault SendRestart()
        {
            if (!IsServerRunning)
            {
                return ApiCommon.GetFault("程序没打开");
            }
            AppHandle.SendRestart(_appProcess);
            return ApiCommon.GetSuccess("已发送重启");
        }
        
        private Process FindProcess()
        {
            Process[] pros = Process.GetProcesses();
            foreach (Process pro in pros)
            {
                try
                {
                    if (string.Equals(pro.MainModule.FileName, _path))
                    {
                        return pro;
                    }
                }
                catch
                {

                }
            }
            return null;
        }

        
    }
}
