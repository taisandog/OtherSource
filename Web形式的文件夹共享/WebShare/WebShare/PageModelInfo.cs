using System;
using System.Collections.Generic;
using System.Text;

namespace WebShare
{
    public class PageModelInfo
    {
        private string _curLoaction;
        /// <summary>
        /// ��ǰ��ַ
        /// </summary>
        public string CurLoaction
        {
            get { return _curLoaction; }
            set { _curLoaction = value; }
        }

        private List<DirInfo> _lstDirectory=new List<DirInfo>();
        /// <summary>
        /// �ļ��м���
        /// </summary>
        public List<DirInfo> Directorys
        {
            get { return _lstDirectory; }
        }

        private List<DirInfo> _lstFiles = new List<DirInfo>();
        /// <summary>
        /// �ļ�����
        /// </summary>
        public List<DirInfo> Files
        {
            get { return _lstFiles; }
        }
    }
}
