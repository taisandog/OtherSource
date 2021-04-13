using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixivToVideo
{
    /// <summary>
    /// 帧信息
    /// </summary>
    public class FrameItem
    {
        /// <summary>
        /// 文件
        /// </summary>
        [JsonProperty("file")]
        public string File { get; set; }

        /// <summary>
        /// 延迟
        /// </summary>
        [JsonProperty("delay")]
        public int Delay { get; set; }
    }
}
