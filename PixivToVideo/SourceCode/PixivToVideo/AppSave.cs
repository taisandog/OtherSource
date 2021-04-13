using Buffalo.Kernel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixivToVideo
{
    /// <summary>
    /// 上次操作记录
    /// </summary>
    public class AppSave
    {
        private static Encoding DefaultEncoding = Encoding.UTF8;
        public string CmbOutput { get; set; }
        public string CmbOutFPS { get; set; }
        public string TxtPath { get; set; }
        public string TxtOutPath { get; set; }
        public string CmbBit { get; set; }
        public int Nuploop { get; set; }
        /// <summary>
        /// 保存
        /// </summary>
        public void Save()
        {
            string path = CommonMethods.GetBaseRoot() + "\\last.sav";
            File.WriteAllText(path,JsonConvert.SerializeObject(this), DefaultEncoding);
        }
        public void Load()
        {
            string path = CommonMethods.GetBaseRoot() + "\\last.sav";
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                JsonConvert.PopulateObject(json, this);
            }

        }
    }
}
