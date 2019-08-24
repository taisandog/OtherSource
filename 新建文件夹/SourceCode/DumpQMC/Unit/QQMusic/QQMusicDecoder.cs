using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumpQMC.Unit.QQMusic
{
    /// <summary>
    /// QQ音乐解码器
    /// </summary>
    public class QQMusicDecoder : IMusicDecode
    {
        private string _format;
        private Stream _input =null;
        public string Format
        {
            get
            {
                return _format;
            }
        }

        public void Dump(string filePath)
        {
            using (Stream output = File.Open(filePath, FileMode.Create))
            {
                QMCDecode.Decode(_input, output);
            }
        }

        public void Load(Stream input, string exName)
        {
            exName = exName.Trim('.', ' ');
            if (!MusicExtendName.QQMusicExName.TryGetValue(exName, out _format))
            {
                _format = exName;
            }
            _input = input;
        }

        
    }
}
