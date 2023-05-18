using System;
using System.Collections.Generic;
using System.Text;

namespace MoveDataLink
{
    /// <summary>
    /// �����ļ���
    /// </summary>
    public class SpecialPath
    {
        /// <summary>
        /// �����ļ���
        /// </summary>
        /// <param name="path">�ļ���·��</param>
        /// <param name="summary">�ļ���˵��</param>
        private SpecialPath(string path,string summary) 
        {
            _path = path;
            _summary = summary;
        }
        /// <summary>
        /// �����ļ���
        /// </summary>
        private SpecialPath() { }

        private string _path;
        /// <summary>
        /// �ļ���·��
        /// </summary>
        public string Path
        {
            get { return _path; }
        }

        private string _summary;
        /// <summary>
        /// �ļ���˵��
        /// </summary>
        public string Summary
        {
            get { return _summary; }
        }

        public override string ToString()
        {
            return Summary;
        }


        private static List<SpecialPath> _defaultPath = GetSpecialPaths();

        /// <summary>
        /// Ĭ�Ͽ�ѡ�ļ���
        /// </summary>
        public static List<SpecialPath> DefaultPath
        {
            get { return SpecialPath._defaultPath; }
        }
        /// <summary>
        /// ��ȡ�����ļ���
        /// </summary>
        /// <returns></returns>
        public static List<SpecialPath> GetSpecialPaths() 
        {
            List<SpecialPath> lstPath = new List<SpecialPath>();
            SpecialPath path = new SpecialPath();
            path._path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            path._summary = "�����ļ���";
            lstPath.Add(path);

            path = new SpecialPath();
            path._path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)+"\\Google\\Chrome\\User Data\\Default\\Cache\\";
            path._summary = "google����";
            lstPath.Add(path);
            path = new SpecialPath();
            path._path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Google\\Chrome\\User Data\\Default\\Cache\\";
            path._summary = "google����";
            lstPath.Add(path);

            return lstPath;
        }

    }
}
