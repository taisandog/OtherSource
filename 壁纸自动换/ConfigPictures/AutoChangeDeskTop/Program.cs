using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using Buffalo.Win32Kernel.Win32;

namespace AutoChangeDeskTop
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string pic = GetCurrentPictureRoot();
            if (pic != null)
            {
                WindowsApplication.SetWallPaper(pic);
            }
            //Application.Run(new Form1());
        }

        private static readonly string[] AllowFileTypes = { ".png", ".bmp",".jpg",".jpeg" };

        /// <summary>
        /// 获取图片
        /// </summary>
        /// <returns></returns>
        private static List<string> GetPictures()
        {
            List<string> retfile = new List<string>();
            if (!Directory.Exists(CurrentPicRecord.PicPath))
            {
                Directory.CreateDirectory(CurrentPicRecord.PicPath);
            }
            string[] files = Directory.GetFiles(CurrentPicRecord.PicPath, "*.*", SearchOption.TopDirectoryOnly);
            foreach (string fName in files)
            {
                foreach (string allowType in AllowFileTypes)
                {
                    int index = fName.LastIndexOf(allowType);
                    if (index >= 0 && index == fName.Length - allowType.Length)
                    {
                        retfile.Add(fName);
                        break;
                    }
                }
            }
            return retfile;
        }

        /// <summary>
        /// 获取当前的图片路径，并且索引递增1
        /// </summary>
        /// <returns></returns>
        private static string GetCurrentPictureRoot()
        {
            List<string> files = GetPictures();
            if (files.Count <= 0)
            {
                return null;
            }
            int index = CurrentPicRecord.CurrentIndex;

            if (index >= files.Count)
            {
                index = 0;
            }
            string ret = files[index];
            CurrentPicRecord.CurrentIndex = index + 1;
            return ret;
        }
    }
}
