using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Runtime.InteropServices;
using System.Net.NetworkInformation;
using System.Xml;
using System.IO;
using System.Net.Sockets;

namespace ScanLan
{
    /// <summary>
    /// 局域网机器信息
    /// </summary>
    public class LanMachine
    {
        private IPAddress _ip;

        /// <summary>
        /// IP地址
        /// </summary>
        public IPAddress IP
        {
            get { return _ip; }
            set { _ip = value; }
        }

        private MacInfo _mac;

        /// <summary>
        /// MAC地址
        /// </summary>
        public MacInfo Mac
        {
            get { return _mac; }
            set { _mac = value; }
        }

        private string _hostName;

        /// <summary>
        /// 主机名
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
        /// 创建唤醒的快捷方式
        /// </summary>
        public void CreateWakeOnSnapshot()
        {
            string fileName = "\\wakeon" + _ip.ToString() + ".bat";
            
            string dir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string path = dir + fileName;
            StringBuilder sbContent = new StringBuilder(512);

            sbContent.Append("\"");
            sbContent.Append(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            sbContent.Append("\" -wakeon");
            sbContent.Append(" ");
            sbContent.Append(_mac.Mac);
            using (StreamWriter file = new StreamWriter(path, false,Encoding.Default))
            {
                file.Write(sbContent.ToString());
            }
                
        }
        /// <summary>
        ///  Ping的错误信息表
        /// </summary>
        private static Dictionary<string, string> _dicErr = InitErr();

        /// <summary>
        /// 初始化Ping的错误信息表
        /// </summary>
        /// <returns></returns>
        private static Dictionary<string, string> InitErr() 
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic[((int)IPStatus.Unknown).ToString()] = "由于未知原因，ICMP 回送请求失败。";
            dic[((int)IPStatus.DestinationNetworkUnreachable).ToString()] = "由于无法访问包含目标计算机的网络，ICMP 回送请求失败。";
            dic[((int)IPStatus.DestinationHostUnreachable).ToString()] = "由于无法访问目标计算机，ICMP 回送请求失败。";
            dic[((int)IPStatus.DestinationProhibited).ToString()] = "由于管理员禁止联系目标计算机，ICMP 回送请求失败。";
            dic[((int)IPStatus.DestinationProtocolUnreachable).ToString()] = "由于无法访问 ICMP 回送消息中指定的目标计算机，ICMP 回送请求失败，这是因为目标计算机不支持数据包的协议。";
            dic[((int)IPStatus.DestinationPortUnreachable).ToString()] = "由于目标计算机上的端口不可用，ICMP 回送请求失败。";
            dic[((int)IPStatus.NoResources).ToString()] = "由于网络资源不足，ICMP 回送请求失败。";
            dic[((int)IPStatus.BadOption).ToString()] = "由于包含无效选项，ICMP 回送请求失败。";
            dic[((int)IPStatus.HardwareError).ToString()] = "由于硬件错误，ICMP 回送请求失败。";
            dic[((int)IPStatus.PacketTooBig).ToString()] = "由于包含请求的数据包的大小超过了位于源和目标之间的节点（路由器或网关）的最大传输单位 (MTU)，ICMP 回送请求失败。MTU 定义可传送数据包的最大大小。";
            dic[((int)IPStatus.TimedOut).ToString()] = "在所分配的时间内未收到 ICMP 回送答复。";
            dic[((int)IPStatus.BadRoute).ToString()] = "由于在源计算机和目标计算机之间没有有效的路由，ICMP 回送请求失败。";
            dic[((int)IPStatus.TtlExpired).ToString()] = "由于数据包的生存时间 (TTL) 值达到零，导致转发节点（路由器或网关）将数据包丢弃，ICMP 回送请求失败。";
            dic[((int)IPStatus.TtlReassemblyTimeExceeded).ToString()] = "由于数据包被分割为片段以便传输，但在分配的时间内未收到所有片段以进行重组，ICMP 回送请求失败。";
            dic[((int)IPStatus.ParameterProblem).ToString()] = "由于节点（路由器或网关）在处理数据包标头时遇到问题，ICMP 回送请求失败。";
            dic[((int)IPStatus.SourceQuench).ToString()] = "由于已丢弃数据包，ICMP 回送请求失败。";
            dic[((int)IPStatus.BadDestination).ToString()] = "由于目标 IP 地址无法收到 ICMP 回送请求或者永远都不应当出现在任何 IP 数据报的目标地址字段中，ICMP 回送请求失败。";
            dic[((int)IPStatus.DestinationUnreachable).ToString()] = "由于无法访问 ICMP 回送消息中指定的目标计算机，ICMP 回送请求失败；此问题的确切原因未知。";
            dic[((int)IPStatus.TimeExceeded).ToString()] = "由于数据包的生存时间 (TTL) 值达到零，导致转发节点（路由器或网关）将数据包丢弃，ICMP 回送请求失败。";
            dic[((int)IPStatus.BadHeader).ToString()] = "由于标头无效，ICMP 回送请求失败。";
            dic[((int)IPStatus.UnrecognizedNextHeader).ToString()] = "由于“下一标头”字段中没有可识别的值，ICMP 回送请求失败。";
            dic[((int)IPStatus.IcmpError).ToString()] = "由于 ICMP 协议错误，ICMP 回送请求失败。";
            dic[((int)IPStatus.DestinationScopeMismatch).ToString()] = "由于 ICMP 回送消息中指定的源地址和目标地址不在同一范围内，ICMP 回送请求失败。";
            return dic;
        }
        public override bool Equals(object obj)
        {
            LanMachine machine = obj as LanMachine;
            if (machine == null)
            {
                return false;
            }
            byte[] ip1 = this.IP.GetAddressBytes();
            byte[] ip2 = machine.IP.GetAddressBytes();
            if (ip1.Length != ip2.Length)
            {
                return false;
            }
            for (int i = 0; i < ip1.Length; i++)
            {
                if (ip1[i] != ip2[i])
                {
                    return false;
                }
            }

            return this.Mac.Mac == machine.Mac.Mac;
        }
        /// <summary>
        /// 获取ping的错误结果
        /// </summary>
        /// <param name="status">结果信息</param>
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
        /// 获取所有网卡信息
        /// </summary>
        /// <returns></returns>
        public static List<LanMachine> GetLocalInfos() 
        {
            List<LanMachine> lstMachine = new List<LanMachine>();
            string hostName = Dns.GetHostName(); //得到本机的主机名
            System.Net.IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(hostName); ; //取得本机IP

            foreach (IPAddress ip in ipEntry.AddressList)
            {
                try
                {
                    LanMachine machine = new LanMachine();
                    //获取IP

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
        /// Ping一个IP
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
        /// 唤醒
        /// </summary>
        public void WakeOnLan()
        {
            byte[] mac = _mac.ToBytes();
            DoWakeOnLan(mac);
        }
        /// <summary>
        /// 实现网络唤醒
        /// </summary>
        /// <param name="mac"></param>
        public static void DoWakeOnLan(byte[] mac)
        {
            
            using (UdpClient client = new UdpClient())
            {
                client.Connect(IPAddress.Broadcast, 9090);
                byte[] packet = new byte[17 * 6];
                for (int i = 0; i < 6; i++)
                    packet[i] = 0xFF;
                for (int i = 1; i <= 16; i++)
                    for (int j = 0; j < 6; j++)
                        packet[i * 6 + j] = mac[j];
                int result = client.Send(packet, packet.Length);
            }
        }

        ///// <summary>
        ///// 唤醒
        ///// </summary>
        //public void WakeOnLan2()
        //{
        //    byte[] mac = _mac.ToBytes();

        //    UdpClient client = new UdpClient();
        //    client.Connect(new IPAddress(0xffffffff),0x2fff);

        //    if (IsClientInBrodcastMode(client))
        //    {
        //        int byteCount = 0;
        //        byte[] bytes = new byte[102];
        //        for (int trailer = 0; trailer < 6; trailer++)
        //        {
        //            bytes[byteCount++] = 0xFF;
        //        }
        //        for (int macPackets = 0; macPackets < 16; macPackets++)
        //        {
        //            int i = 0;
        //            for (int macBytes = 0; macBytes < 6; macBytes++)
        //            {

        //                bytes[byteCount++] = mac[macBytes];

        //            }
        //        }

        //        int returnValue = client.Send(bytes, byteCount);
        //    }
        //}
        /// <summary>
        /// Sets up the UDP client to broadcast packets.
        /// </summary>
        /// <returns><see langword="true"/> if the UDP client is set in
        /// broadcast mode.</returns>
        public bool IsClientInBrodcastMode(UdpClient client)
        {
            bool broadcast = false;

            try
            {
                client.Client.SetSocketOption(SocketOptionLevel.Socket,
                     SocketOptionName.Broadcast, 0);
                broadcast = true;
            }
            catch
            {
                broadcast = false;
            }

            return broadcast;
        }

        /// <summary>
        /// ping当前IP
        /// </summary>
        /// <returns></returns>
        public PingReply Ping()
        {
            return Ping(1000);
        }
        /// <summary>
        /// ping当前IP
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
        /// 是否XP
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
        /// 获取主机名
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
        /// 保存到文件
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
        /// 保存成txt
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
        /// 保存成XML
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
        /// 保存到文件
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
