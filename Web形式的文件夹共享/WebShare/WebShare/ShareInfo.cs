using System;
using System.Collections.Generic;
using System.Text;

namespace WebShare
{
    /// <summary>
    /// ������Ϣ
    /// </summary>
    public class ShareInfo
    {
        /// <summary>
        /// ������Ϣ
        /// </summary>
        public ShareInfo()
        {
        }
        /// <summary>
        /// ������Ϣ
        /// </summary>
        /// <param name="name">����</param>
        /// <param name="path">·��</param>
        public ShareInfo(string name, string path) 
        {
            _name = name;
            _path = path;
        }

        private string _name;

        /// <summary>
        /// ����
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _path;
        /// <summary>
        /// ·��
        /// </summary>
        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }
    }
}
