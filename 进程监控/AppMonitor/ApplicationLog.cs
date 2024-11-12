
using Buffalo.Kernel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


public class ApplicationLog
{
    private readonly static string BaseRoot = GetBaseRoot();
    private static Encoding _defaultEncoding = Encoding.UTF8;
    /// <summary>
    /// 获取基础路径
    /// </summary>
    /// <returns></returns>
    private static string GetBaseRoot()
    {
        string ret = AppDomain.CurrentDomain.BaseDirectory;

        string logPath = AppSetting.Default["App.LogPath"];
        if (!string.IsNullOrWhiteSpace(logPath))
        {
            return Path.Combine(ret, logPath);
        }


        ret = Path.Combine(ret, "App_Data", "Log");
        if (!Directory.Exists(ret))
        {
            Directory.CreateDirectory(ret);
        }
        return ret;
    }

    private static object _payStateLock = false;
    public static void LogPayState(string modelname, string message)
    {
        string dir = BaseRoot;
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
        string name = "paystate." + DateTime.Now.ToString("yyyyMMdd") + ".txt";
        string fileName = Path.Combine(dir, name);
        lock (_exceptionLock)
        {
            using (StreamWriter sw = new StreamWriter(fileName, true, _defaultEncoding))
            {
                sw.WriteLine("====pay:" + modelname + ",date:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "=====");
                sw.WriteLine(message);
                sw.WriteLine("===========");
                sw.WriteLine("");
                sw.WriteLine("");
                sw.WriteLine("");
            }
        }

    }
    private static object _payLock = false;
    public static void LogPay(string modelname, string message)
    {
        string dir = BaseRoot;
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
        string name = "pay." + DateTime.Now.ToString("yyyyMMdd") + ".txt";
        string fileName = Path.Combine(dir, name);
        lock (_exceptionLock)
        {
            using (StreamWriter sw = new StreamWriter(fileName, true, _defaultEncoding))
            {
                sw.WriteLine("====pay:" + modelname + ",date:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "=====");
                sw.WriteLine(message);
                sw.WriteLine("===========");
                sw.WriteLine("");
                sw.WriteLine("");
                sw.WriteLine("");
            }
        }

    }

    private static object _autoLock = false;
    /// <summary>
    /// 记录自动日志日志
    /// </summary>
    /// <param name="message"></param>
    public static void LogAuto(string message)
    {
        string dir = BaseRoot;
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
        string name = "auto" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
        string fileName = Path.Combine(dir, name);
        lock (_autoLock)
        {
            using (StreamWriter sw = new StreamWriter(fileName, true, _defaultEncoding))
            {
                sw.WriteLine("====" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "=====");
                sw.WriteLine(message);
                sw.WriteLine("===========");
                sw.WriteLine("");
                sw.WriteLine("");
                sw.WriteLine("");
            }
        }
    }
    private static object _messLock = false;
    /// <summary>
    /// 记录日志
    /// </summary>
    /// <param name="message"></param>
    public static void LogMessage(string message)
    {
        string dir = BaseRoot;
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
        string name = "log" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
        string fileName = Path.Combine(dir,name);
        lock (_messLock)
        {
            using (StreamWriter sw = new StreamWriter(fileName, true, _defaultEncoding))
            {
                sw.WriteLine("====" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "=====");
                sw.WriteLine(message);
                sw.WriteLine("===========");
                sw.WriteLine("");
                sw.WriteLine("");
                sw.WriteLine("");
            }
        }

    }

    private static object _warningLock = false;
    /// <summary>
    /// 记录日志
    /// </summary>
    /// <param name="message"></param>
    public static void LogWarning(string message)
    {
        string dir = BaseRoot;
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
        string name = "warning" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
        string fileName = dir + name;
        lock (_warningLock)
        {
            using (StreamWriter sw = new StreamWriter(fileName, true, _defaultEncoding))
            {
                sw.WriteLine("====" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "=====");
                sw.WriteLine(message);
                sw.WriteLine("===========");
                sw.WriteLine("");
                sw.WriteLine("");
                sw.WriteLine("");
            }
        }

    }


    private static object _errorLock = false;
    /// <summary>
    /// 记录日志
    /// </summary>
    /// <param name="message"></param>
    public static void LogError(string message)
    {
        string dir = BaseRoot;
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
        string name = "error" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
        string fileName = dir + name;
        lock (_errorLock)
        {
            using (StreamWriter sw = new StreamWriter(fileName, true, _defaultEncoding))
            {
                sw.WriteLine("====" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "=====");
                sw.WriteLine(message);
                sw.WriteLine("===========");
                sw.WriteLine("");
                sw.WriteLine("");
                sw.WriteLine("");
            }
        }

    }
    private static object _exceptionLock = false;
    /// <summary>
    /// 记录自动日志日志
    /// </summary>
    /// <param name="message"></param>
    public static void LogException(string modelname, Exception ex)
    {
        string dir = BaseRoot;
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
        string name = "exception" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
        string fileName = dir + name;
        lock (_exceptionLock)
        {
            using (StreamWriter sw = new StreamWriter(fileName, true, _defaultEncoding))
            {
                sw.WriteLine("====model:" + modelname + ",date:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "=====");
                sw.WriteLine(ex.ToString());
                sw.WriteLine("===========");
                sw.WriteLine("");
                sw.WriteLine("");
                sw.WriteLine("");
            }
        }
    }


    private static object _debugLock = false;
    /// <summary>
    /// 记录测试日志
    /// </summary>
    /// <param name="message"></param>
    public static void LogDebug(string message)
    {
        string dir = BaseRoot;
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
        string name = "debug" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
        string fileName = dir + name;
        lock (_debugLock)
        {
            using (StreamWriter sw = new StreamWriter(fileName, true, _defaultEncoding))
            {
                sw.WriteLine("====" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "=====");
                sw.WriteLine(message);
                sw.WriteLine("===========");
                sw.WriteLine("");
                sw.WriteLine("");
                sw.WriteLine("");
            }
        }
    }

}

