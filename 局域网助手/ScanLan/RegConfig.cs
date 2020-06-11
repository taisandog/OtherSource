using System;
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
