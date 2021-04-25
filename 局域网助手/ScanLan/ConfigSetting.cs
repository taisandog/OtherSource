using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScanLan
{
    /// <summary>
    /// 配置
    /// </summary>
    public class ConfigSetting
    {

        private static readonly string LastConfigFile = AppDomain.CurrentDomain.BaseDirectory + "\\config.json";
        /// <summary>
        /// 读取配置
        /// </summary>
        /// <returns></returns>
        public static ConfigSetting LoadConfig()
        {
            if (!File.Exists(LastConfigFile))
            {
                return new ConfigSetting();
            }
            try
            {
                string content = File.ReadAllText(LastConfigFile, Encoding.UTF8);
                return JsonConvert.DeserializeObject<ConfigSetting>(content);
            }
            catch (Exception ex) { }
            return new ConfigSetting();
        }

        /// <summary>
        /// 写入配置
        /// </summary>
        /// <returns></returns>
        public void SaveConfig()
        {

            string content = JsonConvert.SerializeObject(this);
            File.WriteAllText(LastConfigFile, content, Encoding.UTF8);
        }

        /// <summary>
        /// 监听端口
        /// </summary>
        private int _port=8089;
        /// <summary>
        /// 监听端口
        /// </summary>
        public int Port
        {
            get { return _port; }
            set { _port = value; }
        }

        private bool _onListen = false;
        /// <summary>
        /// 是否监听中
        /// </summary>
        public bool OnListen
        {
            get { return _onListen; }
            set { _onListen = value; }
        }
        

    }
}
