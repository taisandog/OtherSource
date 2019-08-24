using System;
using System.Collections.Generic;
using System.Text;

namespace WebShare
{
    /// <summary>
    /// ������Ϣ����
    /// </summary>
    public class ShareInfoCollection:List<ShareInfo>
    {
        public ShareInfoCollection() 
        {
            
        }

        /// <summary>
        /// ��ӹ�����Ϣ
        /// </summary>
        /// <param name="name"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public string AddShareInfo(string name, string path) 
        {
            if (FindItem(name)!=null) 
            {
                return "�Ѿ���������:" + name;
            }
            this.Add(new ShareInfo(name, path));
            return null;
        }
        /// <summary>
        /// ����·��������Ϣ
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ShareInfo FindItemByPath(string path)
        {
            foreach (ShareInfo info in this)
            {
                if (info.Path.Equals(path, StringComparison.CurrentCultureIgnoreCase))
                {
                    return info;
                }
            }
            return null;
        }
        /// <summary>
        /// �������Ʋ�����Ϣ
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ShareInfo FindItem(string name) 
        {
            foreach (ShareInfo info in this) 
            {
                if (info.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase)) 
                {
                    return info;
                }
            }
            return null;
        }

    }
}
