using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumpQMC.Unit.QQMusic
{
    public class MusicExtendName
    {
        public static Dictionary<string, string> QQMusicExName = InitExName();

        private static Dictionary<string, string> InitExName()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>(StringComparer.CurrentCultureIgnoreCase);
            dic["qmc3"] = "mp3";
            dic["qmcflac"] = "flac";
            dic["qmc0"] = "mp3";
            return dic;
        }
    }
}
