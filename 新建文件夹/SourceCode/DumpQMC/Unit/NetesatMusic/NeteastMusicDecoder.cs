using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumpQMC.Unit.NetesatMusic
{
    public class NeteastMusicDecoder : IMusicDecode
    {
        private NeteaseCrypto _input = null;
        public string Format
        {
            get
            {
                return _input.Format;
            }
        }

        public void Dump(string filePath)
        {
            _input.Dump(filePath);
        }

        public void Load(Stream input, string exName)
        {
            
            _input = new NeteaseCrypto(input);
        }


    }
}
