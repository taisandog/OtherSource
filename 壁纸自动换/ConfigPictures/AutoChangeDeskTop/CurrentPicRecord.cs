using System;
using System.Windows.Forms;
using System.IO;
namespace AutoChangeDeskTop
{
	/// <summary>
	/// 当前图片记录
	/// </summary>
	public class CurrentPicRecord
	{
		private static string RecordRoot
		{
			get
			{
				return picPath+"save";
			}
		}
		private static string picPath=Application.StartupPath+"\\pics\\";
		
		/// <summary>
		/// 图片的文件夹
		/// </summary>
		public static string PicPath
		{
			get
			{
				return picPath;
			}
		}
		public CurrentPicRecord()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		
		/// <summary>
		/// 当前图片的索引
		/// </summary>
		public static int CurrentIndex
		{
			get
			{
				int ret=0;
				if(File.Exists(RecordRoot))
				{
					FileStream stmSave=new FileStream(RecordRoot,FileMode.Open,FileAccess.Read);
					BinaryReader reader=new BinaryReader(stmSave);
					try
					{
						ret=reader.ReadInt32();
					}
					finally
					{
						reader.Close();
						stmSave.Close();
					}
				}
				return ret;
			}
			set
			{
				FileStream stmSave=new FileStream(RecordRoot,FileMode.Create,FileAccess.Write);
				BinaryWriter writer=new BinaryWriter(stmSave);
				try
				{
					writer.Write(value);
				}
				finally
				{
					writer.Close();
					stmSave.Close();
				}
			}


		}
	}
}
