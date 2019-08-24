using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Runtime.InteropServices;
using System.Net.NetworkInformation;
using System.Xml;
using System.IO;

namespace ScanLan
{
    /// <summary>
    /// ������������Ϣ
    /// </summary>
    public class LanMachine
    {
        private IPAddress _ip;

        /// <summary>
        /// IP��ַ
        /// </summary>
        public IPAddress IP
        {
            get { return _ip; }
            set { _ip = value; }
        }

        private MacInfo _mac;

        /// <summary>
        /// MAC��ַ
        /// </summary>
        public MacInfo Mac
        {
            get { return _mac; }
            set { _mac = value; }
        }

        private string _hostName;

        /// <summary>
        /// ������
        /// </summary>
        public string HostName
        {
            get { return _hostName; }
            set { _hostName = value; }
        }

        public override string ToString()
        {
            return HostName+":"+IP.ToString();
        }

        /// <summary>
        ///  Ping�Ĵ�����Ϣ��
        /// </summary>
        private static Dictionary<string, string> _dicErr = InitErr();

        /// <summary>
        /// ��ʼ��Ping�Ĵ�����Ϣ��
        /// </summary>
        /// <returns></returns>
        private static Dictionary<string, string> InitErr() 
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic[((int)IPStatus.Unknown).ToString()] = "����δ֪ԭ��ICMP ��������ʧ�ܡ�";
            dic[((int)IPStatus.DestinationNetworkUnreachable).ToString()] = "�����޷����ʰ���Ŀ�����������磬ICMP ��������ʧ�ܡ�";
            dic[((int)IPStatus.DestinationHostUnreachable).ToString()] = "�����޷�����Ŀ��������ICMP ��������ʧ�ܡ�";
            dic[((int)IPStatus.DestinationProhibited).ToString()] = "���ڹ���Ա��ֹ��ϵĿ��������ICMP ��������ʧ�ܡ�";
            dic[((int)IPStatus.DestinationProtocolUnreachable).ToString()] = "�����޷����� ICMP ������Ϣ��ָ����Ŀ��������ICMP ��������ʧ�ܣ�������ΪĿ��������֧�����ݰ���Э�顣";
            dic[((int)IPStatus.DestinationPortUnreachable).ToString()] = "����Ŀ�������ϵĶ˿ڲ����ã�ICMP ��������ʧ�ܡ�";
            dic[((int)IPStatus.NoResources).ToString()] = "����������Դ���㣬ICMP ��������ʧ�ܡ�";
            dic[((int)IPStatus.BadOption).ToString()] = "���ڰ�����Чѡ�ICMP ��������ʧ�ܡ�";
            dic[((int)IPStatus.HardwareError).ToString()] = "����Ӳ������ICMP ��������ʧ�ܡ�";
            dic[((int)IPStatus.PacketTooBig).ToString()] = "���ڰ�����������ݰ��Ĵ�С������λ��Դ��Ŀ��֮��Ľڵ㣨·���������أ�������䵥λ (MTU)��ICMP ��������ʧ�ܡ�MTU ����ɴ������ݰ�������С��";
            dic[((int)IPStatus.TimedOut).ToString()] = "���������ʱ����δ�յ� ICMP ���ʹ𸴡�";
            dic[((int)IPStatus.BadRoute).ToString()] = "������Դ�������Ŀ������֮��û����Ч��·�ɣ�ICMP ��������ʧ�ܡ�";
            dic[((int)IPStatus.TtlExpired).ToString()] = "�������ݰ�������ʱ�� (TTL) ֵ�ﵽ�㣬����ת���ڵ㣨·���������أ������ݰ�������ICMP ��������ʧ�ܡ�";
            dic[((int)IPStatus.TtlReassemblyTimeExceeded).ToString()] = "�������ݰ����ָ�ΪƬ���Ա㴫�䣬���ڷ����ʱ����δ�յ�����Ƭ���Խ������飬ICMP ��������ʧ�ܡ�";
            dic[((int)IPStatus.ParameterProblem).ToString()] = "���ڽڵ㣨·���������أ��ڴ������ݰ���ͷʱ�������⣬ICMP ��������ʧ�ܡ�";
            dic[((int)IPStatus.SourceQuench).ToString()] = "�����Ѷ������ݰ���ICMP ��������ʧ�ܡ�";
            dic[((int)IPStatus.BadDestination).ToString()] = "����Ŀ�� IP ��ַ�޷��յ� ICMP �������������Զ����Ӧ���������κ� IP ���ݱ���Ŀ���ַ�ֶ��У�ICMP ��������ʧ�ܡ�";
            dic[((int)IPStatus.DestinationUnreachable).ToString()] = "�����޷����� ICMP ������Ϣ��ָ����Ŀ��������ICMP ��������ʧ�ܣ��������ȷ��ԭ��δ֪��";
            dic[((int)IPStatus.TimeExceeded).ToString()] = "�������ݰ�������ʱ�� (TTL) ֵ�ﵽ�㣬����ת���ڵ㣨·���������أ������ݰ�������ICMP ��������ʧ�ܡ�";
            dic[((int)IPStatus.BadHeader).ToString()] = "���ڱ�ͷ��Ч��ICMP ��������ʧ�ܡ�";
            dic[((int)IPStatus.UnrecognizedNextHeader).ToString()] = "���ڡ���һ��ͷ���ֶ���û�п�ʶ���ֵ��ICMP ��������ʧ�ܡ�";
            dic[((int)IPStatus.IcmpError).ToString()] = "���� ICMP Э�����ICMP ��������ʧ�ܡ�";
            dic[((int)IPStatus.DestinationScopeMismatch).ToString()] = "���� ICMP ������Ϣ��ָ����Դ��ַ��Ŀ���ַ����ͬһ��Χ�ڣ�ICMP ��������ʧ�ܡ�";
            return dic;
        }

        /// <summary>
        /// ��ȡping�Ĵ�����
        /// </summary>
        /// <param name="status">�����Ϣ</param>
        /// <returns></returns>
        public static string GetPingError(IPStatus status) 
        {
            string key = ((int)status).ToString();
            string err=null;
            if (_dicErr.TryGetValue(key, out err)) 
            {
                return err;
            }
            return _dicErr[((int)IPStatus.Unknown).ToString()];
        }

        /// <summary>
        /// ��ȡ����������Ϣ
        /// </summary>
        /// <returns></returns>
        public static List<LanMachine> GetLocalInfos() 
        {
            List<LanMachine> lstMachine = new List<LanMachine>();
            string hostName = Dns.GetHostName(); //�õ�������������
            System.Net.IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(hostName); ; //ȡ�ñ���IP

            foreach (IPAddress ip in ipEntry.AddressList)
            {
                try
                {
                    LanMachine machine = new LanMachine();
                    //��ȡIP

                    machine.IP = ip;
                    machine.HostName = hostName;

                    //machine.Mac = GetRemoteMac(machine.IP.ToString(), machine.IP.ToString());
                    lstMachine.Add(machine);
                }
                catch { }
            }
            return lstMachine;
        }

        private static byte[] _arrData ={
            1,2,3,4,5,6,7,8,9,0,
            1,2,3,4,5,6,7,8,9,0,
            1,2,3,4,5,6,7,8,9,0,
            1,2
        };
       
        /// <summary>
        /// Pingһ��IP
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static PingReply Ping(string ip,int timeOut)
        {
            Ping p = new System.Net.NetworkInformation.Ping();
            PingOptions options = new PingOptions();
            options.DontFragment = true;
            //Wait seconds for a reply.


            PingReply reply = p.Send(ip, timeOut, _arrData, options);
            
            return reply;
        }

        /// <summary>
        /// ping��ǰIP
        /// </summary>
        /// <returns></returns>
        public PingReply Ping()
        {
            return Ping(1000);
        }
        /// <summary>
        /// ping��ǰIP
        /// </summary>
        /// <returns></returns>
        public PingReply Ping(int timeOut) 
        {
            return Ping(IP.ToString(), timeOut);
        }

        

        [DllImport("ws2_32.dll", SetLastError = true)]
        private static extern int gethostname(StringBuilder name, int length);


        private static bool _isXP = GetIsWindowsXP();
        /// <summary>
        /// �Ƿ�XP
        /// </summary>
        public static bool IsXP
        {
            get { return LanMachine._isXP; }
        }

        /// <summary>
        /// Gets a value indicating if the operating system is a Windows XP or a newer one.
        /// </summary>
        private static bool GetIsWindowsXP()
        {
            Version _ver = System.Environment.OSVersion.Version;
            return _ver.Major == 5 && _ver.Minor >= 1;
        }

        /// <summary>
        /// ��ȡ������
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static string GetHostName(IPAddress ip)
        {
            if (_isXP) 
            {
                return Dns.GetHostByAddress(ip).HostName;
            }
            return Dns.GetHostEntry(ip).HostName;
        }

        

        

        



        public void WriteTo(XmlNode node)
        {
            XmlDocument doc = node.OwnerDocument;

            XmlNode cnode = doc.CreateElement("LanMachine");
            node.AppendChild(cnode);

            XmlAttribute att = doc.CreateAttribute("IP");
            att.InnerText = IP.ToString();
            cnode.Attributes.Append(att);

            att = doc.CreateAttribute("Mac");
            att.InnerText = Mac.Mac.ToString();
            cnode.Attributes.Append(att);

            att = doc.CreateAttribute("HostName");
            att.InnerText =HostName;
            cnode.Attributes.Append(att);

        }

        public void Load(XmlNode node)
        {

            XmlAttribute att = node.Attributes["IP"];
            if (att != null)
            {
                IP = IPAddress.Parse(att.InnerText);
            }


            att = node.Attributes["Mac"];
            if (att != null)
            {
                Mac = new MacInfo(long.Parse(att.InnerText));
            }

            att = node.Attributes["HostName"];
            if (att != null)
            {
                HostName = att.InnerText;
            }
        }

        /// <summary>
        /// ���浽�ļ�
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="lst"></param>
        public static void SaveTo(string filePath, List<LanMachine> lst) 
        {
            FileInfo finfo=new FileInfo(filePath);
            string exName = finfo.Extension.Trim('.',' ');
            if (exName.Equals("txt", StringComparison.CurrentCultureIgnoreCase))
            {
                SaveText(filePath, lst);
            }
            else 
            {
                SaveXML(filePath, lst);
            }
        }
        /// <summary>
        /// �����txt
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="lst"></param>
        private static void SaveText(string filePath, List<LanMachine> lst)
        {
            using (StreamWriter sw = new StreamWriter(filePath,false, Encoding.Default))
            {
                foreach (LanMachine machine in lst)
                {
                    string line= machine.IP.ToString() + "   " + machine.HostName+"   "+machine.Mac;
                    sw.WriteLine(line);
                }
            }
        }

        /// <summary>
        /// �����XML
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="lst"></param>
        private static void SaveXML(string filePath, List<LanMachine> lst) 
        {
            XmlDocument xml = new XmlDocument();
            XmlNode root = xml.CreateElement("root");
            xml.AppendChild(root);
            foreach (LanMachine machine in lst)
            {
                machine.WriteTo(root);
            }
            xml.Save(filePath);
        }

        /// <summary>
        /// ���浽�ļ�
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="lst"></param>
        public static List<LanMachine> LoadList(string filePath)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(filePath);
            List<LanMachine> lst = new List<LanMachine>();
            XmlNodeList nodes = xml.GetElementsByTagName("LanMachine");
            foreach (XmlNode node in nodes) 
            {
                LanMachine machine = new LanMachine();
                machine.Load(node);
                lst.Add(machine);
            }
            return lst;
        }
    }

    
}
