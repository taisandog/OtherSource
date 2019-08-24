using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.IO;

namespace ScanLan
{
    /// <summary>
    /// MAC��ַ��Ϣ
    /// </summary>
    public class MacInfo
    {
        [DllImport("iphlpapi.dll")]
        private static extern int SendARP(Int32 dest, Int32 host, ref Int64 mac, ref Int32 length);
        [DllImport("Ws2_32.dll")]
        private static extern Int32 inet_addr(string ip);

        /// <summary>
        /// MAC��ַ��Ϣ
        /// </summary>
        /// <param name="mac">MACֵ</param>
        public MacInfo(long mac)
        {
            _mac = mac;
        }

        private long _mac;

        /// <summary>
        /// MAC��ַ
        /// </summary>
        public long Mac
        {
            get { return _mac; }
            set { _mac = value; }
        }

        public override string ToString()
        {
            StringBuilder sbMac = new StringBuilder();
            long mac = _mac;
            for (int i = 0; i < 6; i++)
            {
                string val = (mac % 256).ToString("X");
                if (val.Length < 2)
                {
                    val = "0" + val;
                }
                sbMac.Append(val);

                mac = mac / 256;
                if (i < 5)
                {
                    sbMac.Append("-");
                }
            }
            return sbMac.ToString();
        }

        /// <summary>
        /// ��ַת���ַ���
        /// </summary>
        /// <returns></returns>
        private static long MACStringToLong(string mac) 
        {
            string[] nums = mac.Split('-');
            long ret = 0;
            string curStr = null;
            for (int i = 0; i < nums.Length;i++ )
            {
                curStr = nums[i].Trim();
                long cur = Convert.ToInt64(curStr, 16);
                cur *= (long)Math.Pow(256, i);
                ret += cur;
            }
            return ret;
        }
        /// <summary>
        /// ��nbtstat��ʽ��ȡMAC
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static MacInfo GetRemoteMacXP(string ip) 
        {
            using (Process p = new Process())
            {
                p.StartInfo.FileName = "nbtstat";//Ҫִ�еĳ������� 
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.Arguments = " -A " + ip;
                p.StartInfo.RedirectStandardInput = true;//���ܽ������Ե��ó����������Ϣ 
                p.StartInfo.RedirectStandardOutput = true;//�ɵ��ó����ȡ�����Ϣ 
                p.StartInfo.CreateNoWindow = true;//����ʾ���򴰿� 
                p.Start();//�������� 
                //��ȡCMD���ڵ������Ϣ�� 
                string sOutput =null;
                string resault=p.StandardOutput.ReadToEnd();
                StringReader reader = new StringReader(resault);
                while ((sOutput = reader.ReadLine()) != null) 
                {
                    int index = sOutput.IndexOf("MAC", StringComparison.CurrentCultureIgnoreCase);
                    if (index >= 0) 
                    {
                        index = sOutput.IndexOf("=");
                        if (index >= 0)
                        {
                            string mac = sOutput.Substring(index + 1);
                            return new MacInfo(MACStringToLong(mac));
                        }
                    }
                }

            }
            return new MacInfo(0);
        }

        /// <summary>
        /// ��ȡԶ��MAC
        /// </summary>
        /// <param name="remoteIP"></param>
        /// <returns></returns>
        public static MacInfo GetRemoteMac(string remoteIP) 
        {
            MacInfo info = GetRemoteMacOther(remoteIP);
            if (info.Mac == 0) 
            {
                info = GetRemoteMacXP(remoteIP);
            }
            return info;
        }

        /// <summary>
        /// ��ȡԶ������MAC
        /// </summary>
        /// <param name="localIP">����IP</param>
        /// <param name="remoteIP">Զ��IP</param>
        /// <returns></returns>
        public static MacInfo GetRemoteMacOther(string remoteIP)
        {
            Int32 ldest = inet_addr(remoteIP); //Ŀ��ip 
            //Int32 lhost = inet_addr(localIP); //����ip 
            Int64 mac = new Int64();
            Int32 len = 6;
            int res = SendARP(ldest, 0, ref mac, ref len);
            return new MacInfo(mac);
        }
    }
}
