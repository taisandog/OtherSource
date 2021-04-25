using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;
namespace ScanLan
{
	/// <summary>
	/// RegConfig ��ժҪ˵����
	/// </summary>
	public class RegConfig
	{
		public RegConfig()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

		private static string autoRoot=Application.StartupPath+ "\\ScanLan.exe";
		private const string keyName= "ScanLan";//ע������

        //private static RegistryKey _key= Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
        /// <summary>
        /// �����Ƿ�������
        /// </summary>
        public static bool IsAutoRun
		{
			get
			{

                using (RegistryKey autoKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", false))
                {
                    return FindValue(autoKey, keyName);
                }
			}
			set
			{
                using (RegistryKey autoKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true))
                {
                    if (value)
                    {
                        if (string.Equals(autoKey.GetValue(keyName) as string, autoRoot))
                        {
                            return;
                        }
                        autoKey.DeleteValue(keyName, false);
                        autoKey.SetValue(keyName, autoRoot, RegistryValueKind.String);
                    }
                    else
                    {
                        autoKey.DeleteValue(keyName, false);
                    }
                }
			}
		}
		private static readonly string LastListenStateFile = AppDomain.CurrentDomain.BaseDirectory + "\\LastListenState.sav";
		/// <summary>
		/// �������״̬
		/// </summary>
		/// <param name="state"></param>
		public static void SaveLastListenState(bool state) 
		{
			int content = state ? 1 : 0;
			using (StreamWriter sw = new StreamWriter(LastListenStateFile, false)) 
			{
				sw.Write(content);
			}
		}
		/// <summary>
		/// �������״̬
		/// </summary>
		/// <param name="state"></param>
		public static bool LoadLastListenState(bool state)
		{
			using (FileStream sr = new FileStream(LastListenStateFile,FileMode.Open,FileAccess.Read))
			{
				using (BinaryReader br = new BinaryReader(sr)) 
				{
					int content = br.ReadInt32();
					return content != 0;
				}
			}
		}
		/// <summary>
		/// ע�����в���ָ������
		/// </summary>
		/// <param name="key">ע����</param>
		/// <param name="val">����</param>
		/// <returns></returns>
		private static bool FindValue(RegistryKey key,string val)
		{
			string[] subkeys=key.GetValueNames();
			for(int i=0;i<subkeys.Length;i++)
			{
				if(val==subkeys[i])
				{
					return true;
				}
				
			}
			return false;
		}
	}
}
