using Buffalo.Kernel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace ScanLan
{
    public delegate void ErrorHandle(Exception ex);
    /// <summary>
    /// 网络服务
    /// </summary>
    public class SCWebServices
    {
        private static object LockObj = new object();
        private static byte[] HTMLContent = null;
        private static byte[] HTMLRedirectContent = null;
        /// <summary>
        /// 监听器
        /// </summary>
        HttpListener _httpListener;
        /// <summary>
        /// 监听端口
        /// </summary>
        private int _port;
        private Thread _thd;
        public event ErrorHandle OnException;
        public int Port
        {
            get { return _port; }
            set { _port = value; }
        }
        /// <summary>
        /// 是否运行中
        /// </summary>
        private bool _running;
        public SCWebServices()
        {

        }
        /// <summary>
        /// 开始服务
        /// </summary>
        public void Start()
        {
            _httpListener = new HttpListener();
            
            _httpListener.AuthenticationSchemes = AuthenticationSchemes.Anonymous;
            
                _httpListener.Prefixes.Add("http://+:"+_port+"/");
            
            _httpListener.Start();
            _running = true;
            _thd = new Thread(new ThreadStart(DoListen));
            _thd.Start();
        }
        
        private void DoListen()
        {
            while (_running)
            {
                try
                {
                    HttpListenerContext httpListenerContext = _httpListener.GetContext();
                    Thread thd = new Thread(new ParameterizedThreadStart(DoRequest));
                    thd.Start(httpListenerContext);
                }
                catch (Exception ex)
                {
                    if (OnException != null)
                    {
                        OnException(ex);
                    }
                }
            }
        }
        
        /// <summary>
        /// 获取网页内容
        /// </summary>
        /// <returns></returns>
        private static byte[] GetHTMLContent()
        {
            if (HTMLContent != null)
            {
                return HTMLContent;
            }
            lock (LockObj)
            {
                
                HTMLContent = LoadWeb();

                return HTMLContent;
            }
        }
        /// <summary>
        /// 获取网页内容
        /// </summary>
        /// <returns></returns>
        private static byte[] GetHTMLRedirectContent()
        {
            if (HTMLRedirectContent != null)
            {
                return HTMLRedirectContent;
            }
            lock (LockObj)
            {

                HTMLRedirectContent = LoadRedirectWeb();

                return HTMLRedirectContent;
            }
        }
        private static List<LanMachine> _lstMachines;


        /// <summary>
        /// 刷新网页
        /// </summary>
        /// <param name="lstMachines"></param>
        public static void WriteWakeUp(List<LanMachine> lstMachines)
        {
            _lstMachines = lstMachines;
            HTMLContent= LoadWeb();
        }
        private static byte[] LoadWeb()
        {
            string model = CommonMethods.GetBaseRoot() + "resources\\model.html";
            string content = File.ReadAllText(model, Encoding.UTF8);
            StringBuilder sbButtons = new StringBuilder();
            if (_lstMachines != null)
            {
                foreach (LanMachine machine in _lstMachines)
                {

                    sbButtons.AppendLine("<input name=\"btnSub\" value=\"" + HttpUtility.HtmlEncode(machine.NickName) +
                        "\" class=\"btnSty\" type=\"submit\" onclick=\"return onSubmit('"+ HttpUtility.HtmlEncode(machine.NickName) + 
                        "','" + machine.Mac.Mac + "')\" />");
                }
            }
            content = content.Replace("<%#Buttons#%>", sbButtons.ToString());

            return System.Text.Encoding.UTF8.GetBytes(content);
        }
        private static byte[] LoadRedirectWeb()
        {
            string model = CommonMethods.GetBaseRoot() + "resources\\modelredirect.html";
            string content = File.ReadAllText(model, Encoding.UTF8);
           
            return System.Text.Encoding.UTF8.GetBytes(content);
        }
        private void DoRequest(object objhttpListenerContext)
        {
            try
            {
                HttpListenerContext context = objhttpListenerContext as HttpListenerContext;
                if (context == null)
                {
                    return;
                }
                HttpListenerRequest request = context.Request;
                //取得响应对象
                HttpListenerResponse response = context.Response;
                response.ContentType = "text/html; charset=utf-8";

                byte[] content = null;
                string url = request.Url.AbsolutePath;
                string mac = request.QueryString["mac"];
                if (!string.IsNullOrWhiteSpace(mac))
                {
                    WakeOn(mac);
                    content = GetHTMLRedirectContent();
                }
                else
                {
                    content = GetHTMLContent();
                }
                //设置响应头部内容，长度及编码
                response.ContentLength64 = content.Length;
                response.OutputStream.Write(content, 0, content.Length);
            }
            catch (Exception ex)
            {
                if (OnException != null)
                {
                    OnException(ex);
                }
            }
        }
        
        /// <summary>
        /// 唤醒
        /// </summary>
        /// <param name="mac"></param>
        private void WakeOn(string strmac)
        {
            long mac = 0;
            if (!long.TryParse(strmac, out mac))
            {
                return;
            }
            LanMachine machine = new LanMachine();
            machine.Mac = new MacInfo(mac);
            machine.WakeOnLan();
        }
       

        /// <summary>
        /// 停止
        /// </summary>
        public void Stop()
        {
            _running = false;
            if (_thd != null)
            {
                try
                {
                    _thd.Abort();
                }
                catch { }
            }
            _thd = null;

            if (_httpListener != null)
            {
                try
                {
                    _httpListener.Stop();
                }
                catch { }
            }
            _httpListener = null;
            Thread.Sleep(200);
        }

        
    }
}
