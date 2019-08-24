using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using Buffalo.Kernel;
namespace ConfigPictures
{
	/// <summary>
	/// PictureManager ��ժҪ˵����
	/// </summary>
	public class PictureManager
	{
		public PictureManager()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
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
		/// ��ȡͼƬ
		/// </summary>
		/// <param name="root"></param>
		/// <returns></returns>
		public static Image LoadPicture(string root)
		{
            
			return Image.FromFile(PicPath+root);
		}

		/// <summary>
		/// ����ͼƬ
		/// </summary>
		/// <param name="sourceRoot">Դ·��</param>
        /// <param name="targetRoot">Ŀ��·��</param>
		/// <param name="objSize">ͼƬ��С</param>
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
        /// ��ȡ�ļ���
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
		/// ��������ͼƬ
		/// </summary>
		/// <param name="sourceRoots">Դ·��</param>
		/// <param name="objSize">ͼƬ��С</param>
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
                    if (MessageBox.Show("�ļ�:" + targetRoot + "�Ѿ����ڣ��Ƿ񸲸ǣ�", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
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
		/// ɾ��ͼƬ
		/// </summary>
		/// <param name="root">Ҫɾ����ͼƬ·��</param>
		public static void DeletePicture(string root)
		{
			File.Delete(PicPath+root);
		}

		/// <summary>
		/// ����ɾ��ͼƬ
		/// </summary>
		/// <param name="roots">Ҫɾ����ͼƬ·��</param>
		public static void DeletePicture(string[] roots)
		{
			foreach(string root in roots)
			{
				File.Delete(PicPath+root);
			}
		}

	}
}
