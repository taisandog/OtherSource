
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit
{
    /// <summary>
    /// 上次操作记录
    /// </summary>
    public class AppSave
    {
        private static Encoding DefaultEncoding = Encoding.UTF8;
        /// <summary>
        /// 最后读取的路径
        /// </summary>
        public string LastLoad { get; set; }
        /// <summary>
        /// 输出位置
        /// </summary>
        public string OutputPath { get; set; }

        /// <summary>
        /// 保存
        /// </summary>
        public void Save()
        {
            string path = GetBaseRoot() + "\\app.sav";
            File.WriteAllText(path,JsonConvert.SerializeObject(this), DefaultEncoding);
        }
        public void Load()
        {
            string path = GetBaseRoot() + "\\app.sav";
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                JsonConvert.PopulateObject(json, this);
            }

        }

        private static string _baseRoot = null;//基目录
        /// <summary>
        /// 获取基路径
        /// </summary>
        /// <param name="configRoot"></param>
        /// <returns></returns>
        public static string GetBaseRoot(string configRoot)
        {

            if (_baseRoot == null)
            {
               
                    _baseRoot = AppDomain.CurrentDomain.BaseDirectory;
                
                if (!string.IsNullOrEmpty(_baseRoot))
                {
                    _baseRoot = FormatPath(_baseRoot);
                }
            }
            if (Path.IsPathRooted(configRoot))
            {
                return configRoot;
            }
            string retRoot = _baseRoot + configRoot;
            return retRoot;
        }
        public static string FormatPath(string path)
        {
            path = path.Trim();
            if (path[path.Length - 1] != '\\')
            {
                path = path + "\\";
            }
            return path;
        }

        /// <summary>
        /// 获取应用程序的基目录
        /// </summary>
        /// <returns></returns>
        public static string GetBaseRoot()
        {

            return GetBaseRoot("");
        }
    }
}
