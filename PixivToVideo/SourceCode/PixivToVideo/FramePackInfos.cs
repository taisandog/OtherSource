using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PixivToVideo
{
    public class FramePackInfos
    {
        private string _url = null;

        private int _minPer = -1;
        
        private string _pixivID;

        private List<FrameItem> _frames;
        public Size PicSize { get; set; }
        public string Url { get => _url; set => _url = value; }
        public string PixivID { get => _pixivID; set => _pixivID = value; }
        public List<FrameItem> Frames
        {
            get
            {
                return _frames;
            }
            set
            {
                _frames = value;
                _minPer = GetMinPer();
            }
        }
        private static int[] _defaultFrms = { 1000, 500, 100, 50, 10 };
        /// <summary>
        /// 获取最小帧数单位
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        private int GetMinPer()
        {
            int minDelay = -1;
            foreach (FrameItem item in _frames)
            {
                if (minDelay < 0)
                {
                    minDelay = item.Delay;
                    continue;
                }
                if (minDelay > item.Delay)
                {
                    minDelay = item.Delay;
                }
            }
            foreach (int per in _defaultFrms)
            {
                if (minDelay / per <= 0)
                {
                    continue;
                }
                if (minDelay % per == 0)
                {
                    return per;
                }
            }
            return 10;
        }
        /// <summary>
        /// 最小的延迟单位
        /// </summary>
        public int MinDelayPer { get => _minPer; set => _minPer = value; }
    }
}
