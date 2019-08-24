using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumpQMC.Unit.QQMusic
{
    /** 
 * @原作者:presburger
 * @创建时间:2019-07-08
 * @链接:https://github.com/Presburger/qmc-decoder
 * @说明:QMC文件解码
*/
    /// <summary>
    /// QMC解码
    /// </summary>
    public class QMCDecode
    {
        /// <summary>
        /// 解码
        /// </summary>
        /// <param name="stmSource"></param>
        /// <param name="stmTarget"></param>
        public static void Decode(Stream stmSource,Stream stmTarget)
        {
            byte[] buffer = new byte[1024 * 32];
            byte[] writeBuff= new byte[buffer.Length];
            QMCSeed seed = new QMCSeed();
            int readed = 0;
            do
            {
                readed = stmSource.Read(buffer, 0, buffer.Length);
                if (readed <= 0)
                {
                    break;
                }
                for (int i = 0; i < readed; i++)
                {
                    writeBuff[i] = (byte)(seed.NextMask() ^ (int)buffer[i]);
                }
                stmTarget.Write(writeBuff, 0, readed);
            } while (readed > 0);

        }
    }
}
