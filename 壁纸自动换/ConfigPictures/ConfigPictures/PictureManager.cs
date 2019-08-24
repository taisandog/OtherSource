using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using Buffalo.Kernel;
namespace ConfigPictures
{
	/// <summary>
	/// PictureManager 的摘要说明。
	/// </summary>
	public class PictureManager
	{
		public PictureManager()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		private static string picPath=Application.StartupPath+"\\pics\\";
		public static string PicPath
		{
			get
			{
				return picPath;
			}
		}
		/// <summary>
		/// 获取图片
		/// </summary>
		/// <param name="root"></param>
		/// <returns></returns>
		public static Image LoadPicture(string root)
		{
            
			return Image.FromFile(PicPath+root);
		}

		/// <summary>
		/// 拷贝图片
		/// </summary>
		/// <param name="sourceRoot">源路径</param>
        /// <param name="targetRoot">目标路径</param>
		/// <param name="objSize">图片大小</param>
		public static void CopyPicture(string sourceRoot,string targetRoot,Size objSize)
		{
            

            Image sourcePicture = Image.FromFile(sourceRoot);
            Image targetPicture = null;
            if (!objSize.IsEmpty)
            {
                targetPicture = Picture.ReSizePictureInScope(sourcePicture, objSize.Width, objSize.Height);
            }
            else 
            {
                targetPicture = sourcePicture;
            }
            targetPicture.Save(targetRoot, ImageFormat.Png);
		}

        /// <summary>
        /// 获取文件名
        /// </summary>
        /// <returns></returns>
        private static string GetFileName(string sourceName) 
        {
            int index = sourceName.LastIndexOf('\\');
            string name = sourceName.Substring(index);
            int dotIndex = name.LastIndexOf('.');
            if (dotIndex > 0) 
            {
                name = name.Substring(0, dotIndex);
            }
            return name;
        }
        private const string OutPutType = "png";
		/// <summary>
		/// 批量拷贝图片
		/// </summary>
		/// <param name="sourceRoots">源路径</param>
		/// <param name="objSize">图片大小</param>
		public static void CopyPicture(string[] sourceRoots,Size objSize)
		{
			DateTime dtNow=DateTime.Now;
			
			for(int i=0;i<sourceRoots.Length;i++)
			{
                string sourceName = sourceRoots[i];
                FileInfo sourceFileInfo=new FileInfo(sourceName);
                string fileName = GetFileName(sourceName);
				string targetRoot=picPath+fileName+"."+OutPutType;

                if (File.Exists(targetRoot))
                {
                    if (MessageBox.Show("文件:" + targetRoot + "已经存在，是否覆盖？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    {
                        continue;
                    }
                }

                try
                {
                    
                    CopyPicture(sourceName, targetRoot, objSize);
                }
                catch { }
			}
		}
		/// <summary>
		/// 删除图片
		/// </summary>
		/// <param name="root">要删除的图片路径</param>
		public static void DeletePicture(string root)
		{
			File.Delete(PicPath+root);
		}

		/// <summary>
		/// 批量删除图片
		/// </summary>
		/// <param name="roots">要删除的图片路径</param>
		public static void DeletePicture(string[] roots)
		{
			foreach(string root in roots)
			{
				File.Delete(PicPath+root);
			}
		}

	}
}
