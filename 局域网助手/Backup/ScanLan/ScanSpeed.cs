using System;
using System.Collections.Generic;
using System.Text;

namespace ScanLan
{
    /// <summary>
    /// 速度
    /// </summary>
    public class ScanSpeed
    {
        /// <summary>
        /// 扫描速度
        /// </summary>
        /// <param name="name"></param>
        /// <param name="text"></param>
        /// <param name="sleepTime"></param>
        public ScanSpeed(string name, string text, int sleepTime,int timeOut) 
        {
            _name = name;
            _sleepTime = sleepTime;
            _text = text;
            _timeout = timeOut;
        }

        private string _name;
        /// <summary>
        /// 名称
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _text;
        /// <summary>
        /// 文本
        /// </summary>
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }
        private int _sleepTime;
        /// <summary>
        /// 时间
        /// </summary>
        public int SleepTime
        {
            get { return _sleepTime; }
            set { _sleepTime = value; }
        }
        private int _timeout;
        /// <summary>
        /// 超时时间
        /// </summary>
        public int Timeout
        {
            get { return _timeout; }
            set { _timeout = value; }
        }
    }
}
