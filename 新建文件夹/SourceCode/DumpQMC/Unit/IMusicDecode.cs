using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumpQMC.Unit
{
    /// <summary>
    /// 音乐文件解码器
    /// </summary>
    public interface IMusicDecode
    {
        /// <summary>
        /// 加载输入文件
        /// </summary>
        /// <param name="input">输出流</param>
        /// <param name="exName">文件扩展名</param>
        void Load(Stream input, string exName);
        /// <summary>
        /// 输出文件
        /// </summary>
        /// <param name="output"></param>
        void Dump(string filePath);
        /// <summary>
        /// 文件格式
        /// </summary>
        string Format
        {
            get;
        }
    }
}
