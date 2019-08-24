using DumpQMC.Unit.NetesatMusic;
using DumpQMC.Unit.QQMusic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumpQMC.Unit
{
    public class DecoderManager
    {
        private static Dictionary<string, Type> _dic= Load();

        private static Dictionary<string, Type> Load()
        {
            Dictionary<string, Type> dic = new Dictionary<string, Type>(StringComparer.CurrentCultureIgnoreCase);
            dic["qmc3"] = typeof(QQMusicDecoder);
            dic["qmcflac"] = typeof(QQMusicDecoder);
            dic["qmc0"] = typeof(QQMusicDecoder);
            dic["ncm"] = typeof(NeteastMusicDecoder);
            return dic;
        }
        /// <summary>
        /// 获取解码类型
        /// </summary>
        /// <param name="exName">扩展名</param>
        /// <returns></returns>
        public static Type GetDecoderType(string exName)
        {
            Type objType = null;
            if (!_dic.TryGetValue(exName, out objType))
            {
                return null;
            }
            return objType;
        }
        /// <summary>
        /// 是否存在解码
        /// </summary>
        /// <param name="exName"></param>
        /// <returns></returns>
        public static bool HasDecode(string exName)
        {
            return _dic.ContainsKey(exName);
        }

        /// <summary>
        /// 获取解码类型
        /// </summary>
        /// <param name="exName">扩展名</param>
        /// <returns></returns>
        public static IMusicDecode CreateDecode(string exName)
        {
            Type objType = GetDecoderType(exName);
            if (objType == null)
            {
                return null;
            }
            return Activator.CreateInstance(objType) as IMusicDecode;
        }
    }
}
