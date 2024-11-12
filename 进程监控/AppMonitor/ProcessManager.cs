
using Buffalo.Kernel;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GameDaemon
{
    /// <summary>
    /// 进程管理
    /// </summary>
    public class ProcessManager: List<ProcessItem>
    {
        private IShowMessage _mess;

       
        public ProcessManager(IShowMessage mess)
        {
            _mess = mess;
        }
        /// <summary>
        /// 记录重启
        /// </summary>
        public void LogRestart(string message)
        {
            if (_mess != null && _mess.ShowWarning)
            {
                _mess.LogWarning(message);
            }
            ApplicationLog.LogAuto(message);
        }
        /// <summary>
        /// 记录错误
        /// </summary>
        public void LogError(string message)
        {
            if (_mess != null && _mess.ShowError)
            {
                _mess.LogError(message);
            }
        }
        
       

        private int _restartHour = 0;
        /// <summary>
        /// 重启小时数
        /// </summary>
        public int RestartHour
        {
            get
            {
                return _restartHour;
            }
        }
        
        private static int LoadRestart()
        {
            string ret = AppSetting.Default["App.RestartHour"];
            if (string.IsNullOrWhiteSpace(ret))
            {
                return 4;
            }
            return ret.ConvertTo<int>(4);
        }
        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            _restartHour = LoadRestart();
            XmlDocument doc = new XmlDocument();
            string file = CommonMethods.GetBaseRoot() + "\\App_Data\\applist.xml";
            doc.Load(file);
            XmlNodeList lstroot= doc.GetElementsByTagName("root");
            Dictionary<string, string> dic = new Dictionary<string, string>();
            if (lstroot.Count > 0)
            {
                XmlNode root = lstroot[0];
                FillArgs(root, dic);
            }

            XmlNodeList lstApp = doc.GetElementsByTagName("app");
            string path = null;
            string serverName = null;
            string name = null;
            ProcessItem item = null;
            bool checkReset=false;
            foreach (XmlNode node in lstApp)
            {
                XmlAttribute att = node.Attributes["path"];
                if (att == null)
                {
                    continue;
                }
                path = FormatPath(att.InnerText,dic);

                att = node.Attributes["serverName"];
                if (att == null)
                {
                    continue;
                }
                serverName = att.InnerText;

                att = node.Attributes["name"];
                if (att == null)
                {
                    continue;
                }
                name = att.InnerText;

                att = node.Attributes["checkReset"];
                if (att != null && att.InnerText == "0")
                {
                    checkReset = false;
                }
                else
                {
                    checkReset = true;
                }

                long immRestartMB = 0;
                att = node.Attributes["immRestartMB"];
                if (att != null)
                {
                    immRestartMB = att.InnerText.ConvertTo<long>();
                    
                }
                bool isRunning = false;
                att = node.Attributes["running"];
                if (att != null)
                {
                    isRunning = att.InnerText=="1";

                }
                string args = "";
                att =  node.Attributes["args"];
                if (att != null)
                {
                    args = att.InnerText ;

                }
                item = new ProcessItem(name, serverName, args, path,isRunning,this, checkReset, immRestartMB);
                this.Add(item);
            }
        }

        private string FormatPath(string path, Dictionary<string, string> dic)
        {

            foreach(KeyValuePair<string,string> kvp in dic)
            {
                string key = "{" + kvp.Key + "}";
                if (path.Contains(key))
                {
                    path = path.Replace(key, kvp.Value);
                    return path;
                }
            }
            return path;
        }

        /// <summary>
        /// 填充参数
        /// </summary>
        /// <param name="node"></param>
        /// <param name="dic"></param>
        /// <returns></returns>
        private Dictionary<string,string> FillArgs(XmlNode node, Dictionary<string, string> dic)
        {
            foreach (XmlAttribute attr in node.Attributes)
            {
                dic[attr.Name] = attr.InnerText;
            }
            return dic;
        }
        /// <summary>
        /// 检查CPU占用
        /// </summary>
        public void CheckCPURestart()
        {
            foreach (ProcessItem item in this)
            {
                
                if (!item.NeedCheckCPU)
                {
                    continue;
                }
                item.RefreashCPU();
                item.CheckCPU();
            }
        }

        /// <summary>
        /// 刷新进程
        /// </summary>
        public void RefreashProcess(IShowMessage mess)
        {
            Dictionary<string, ProcessItem> dicNeedRestart = new Dictionary<string, ProcessItem>(StringComparer.CurrentCultureIgnoreCase);
            //Dictionary<string, ProcessItem> dicRestartFail = new Dictionary<string, ProcessItem>(StringComparer.CurrentCultureIgnoreCase);
            foreach (ProcessItem item in this)
            {
                
                if (item.IsServerRunning)
                {
                    
                    if (!item.HasAppRunning)
                    {
                        dicNeedRestart[item.Path] = item;
                    }
                    else
                    {
                        item.RefreashMemory();
                        item.RefreashCPU();
                        item.CheckRestart();
                    }
                    
                }
                
            }
            if (dicNeedRestart.Count<=0)
            {
                return;
            }
            if (mess != null)
            {
                mess.Log("刷新进程");
            }
            Process[] pros = Process.GetProcesses();
            ProcessItem tmpitem = null;
            foreach (Process pro in pros)//重新绑定进程
            {
                try
                {
                    string path = pro.MainModule.FileName;
                    if(!dicNeedRestart.TryGetValue(path,out tmpitem))
                    {
                        continue;
                    }
                    tmpitem.AppProcess = pro;
                    tmpitem.RefreashMemory();
                    tmpitem.RefreashCPU();
                    dicNeedRestart.Remove(path);
                }
                catch { }
            }
            foreach(KeyValuePair<string, ProcessItem> kvp in dicNeedRestart)
            {
                try
                {
                    kvp.Value.CheckProcessActive();
                }
                catch(Exception ex)
                {
                    _mess.LogError(ex.ToString());
                }
            }
            //foreach (KeyValuePair<string, ProcessItem> kvp in dicRestartFail)
            //{
            //    try
            //    {
            //        kvp.Value.CheckRestartFail();
            //    }
            //    catch (Exception ex)
            //    {
            //        _mess.LogError(ex.ToString());
            //    }
            //}
            
            dicNeedRestart = null;
            //dicRestartFail = null;

        }
    }
}
