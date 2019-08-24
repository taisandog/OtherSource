using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

using Buffalo.Win32Kernel.Win32;
using System.Security.Cryptography;
using Newtonsoft.Json;
using System.Drawing;

namespace WordFilter
{
    /// <summary>
    /// ����
    /// </summary>
    public class ConfigSave
    {
        private MD5 _md5Hash = null;
        private static readonly Encoding DefaultEncoding = Encoding.UTF8;
        /// <summary>
        /// ����
        /// </summary>
        public ConfigSave() 
        {
            _outItem = 0;
            _hotKey = Keys.F6;
            _modifiers = KeyModifiers.None;
            _readHotKey = Keys.F7;
            _readModifiers = KeyModifiers.None;
            _formHotKey = Keys.F8;
            _formModifiers = KeyModifiers.None;
            _showTime = 0;
            _side = 300;
            _password = "123456--";
            _hasPointLine = false;
            _md5Hash=MD5CryptoServiceProvider.Create();
        }

        private int _outItem;
        /// <summary>
        /// �������
        /// </summary>
        public int OutItem
        {
            get { return _outItem; }
            set { _outItem = value; }
        }
        private Keys _hotKey;
        /// <summary>
        /// �ȼ�
        /// </summary>
        public Keys HotKey
        {
            get { return _hotKey; }
            set { _hotKey = value; }
        }
        private KeyModifiers _modifiers;
        /// <summary>
        /// �ȼ���ϼ�
        /// </summary>
        public KeyModifiers Modifiers
        {
            get { return _modifiers; }
            set { _modifiers = value; }
        }

        private Keys _readHotKey;
        /// <summary>
        /// ����ά���ȼ�
        /// </summary>
        public Keys ReadHotKey
        {
            get { return _readHotKey; }
            set { _readHotKey = value; }
        }
        private KeyModifiers _readModifiers;
        /// <summary>
        /// ����ά��ϼ�
        /// </summary>
        public KeyModifiers ReadModifiers
        {
            get { return _readModifiers; }
            set { _readModifiers = value; }
        }

        private Keys _formHotKey;
        /// <summary>
        /// ��ȡ������ά��
        /// </summary>
        public Keys FormHotKey
        {
            get { return _formHotKey; }
            set { _formHotKey = value; }
        }
        private KeyModifiers _formModifiers;
        /// <summary>
        /// ��������ά��ϼ�
        /// </summary>
        public KeyModifiers FormModifiers
        {
            get { return _formModifiers; }
            set { _formModifiers = value; }
        }

        private int _side;

        /// <summary>
        /// �ߴ�
        /// </summary>
        public int Side
        {
            get { return _side; }
            set 
            {
                if (value > 50)
                {
                    _side = value;
                }
            }
        }
        private uint _textColor = 0x000000FF;
        /// <summary>
        /// ������ɫ
        /// </summary>
        public uint TextColor
        {
            get { return _textColor; }
            set 
            { 
                _textColor = value;
                _textSetColor = Color.Empty;
            }
        }

        private Color _textSetColor = Color.Empty;
        /// <summary>
        /// �ı���ɫ
        /// </summary>
        [JsonIgnore]
        public Color TextSetColor
        {
            get 
            {
                if (_textSetColor == Color.Empty) 
                {
                    _textSetColor=IntToColor(_textColor);
                }
                return _textSetColor;
            }
            set
            {
                TextColor = ColorToInt(value);
            }
        }

        private uint _backColor = 0xFFFFFFFF;
        /// <summary>
        /// ������ɫ
        /// </summary>
        public uint BackColor
        {
            get { return _backColor; }
            set 
            { 
                _backColor = value;
                _backSetColor = Color.Empty;
            }
        }
        int _twist = 3;
        /// <summary>
        /// Ť���̶�
        /// </summary>
        public int Twist
        {
            get { return _twist; }
            set { _twist = value; }
        }
        private Font _textFont = new Font("����", 12, FontStyle.Bold);
        /// <summary>
        /// ����
        /// </summary>
        public Font TextFont
        {
            get { return _textFont; }
            set { _textFont = value; }
        }

        private Color _backSetColor = Color.Empty;
        /// <summary>
        /// �ı���ɫ
        /// </summary>
        [JsonIgnore]
        public Color BackSetColor
        {
            get
            {
                if (_backSetColor == Color.Empty)
                {
                    _backSetColor = IntToColor(_backColor);
                }
                return _backSetColor;
            }
            set 
            {
                BackColor = ColorToInt(value);
            }
        }


        private uint _qrTextColor = 0x000000FF;
        /// <summary>
        /// ��ά����ɫ
        /// </summary>
        public uint QRTextColor
        {
            get { return _qrTextColor; }
            set
            {
                _qrTextColor = value;
                _qrSetColor = Color.Empty;
            }
        }

        private Color _qrSetColor = Color.Empty;
        /// <summary>
        /// �ı���ɫ
        /// </summary>
        [JsonIgnore]
        public Color QRSetColor
        {
            get
            {
                if (_qrSetColor == Color.Empty)
                {
                    _qrSetColor = IntToColor(_qrTextColor);
                }
                return _qrSetColor;
            }
            set
            {
                QRTextColor = ColorToInt(value);
            }
        }

        private uint _qrBackColor = 0xFFFFFFFF;
        /// <summary>
        /// ������ɫ
        /// </summary>
        public uint QRBackColor
        {
            get { return _qrBackColor; }
            set
            {
                _qrBackColor = value;
                _qrBackSetColor = Color.Empty;
            }
        }
        private Color _qrBackSetColor = Color.Empty;
        /// <summary>
        /// �ı���ɫ
        /// </summary>
        [JsonIgnore]
        public Color QRBackSetColor
        {
            get
            {
                if (_qrBackSetColor == Color.Empty)
                {
                    _qrBackSetColor = IntToColor(_qrBackColor);
                }
                return _qrBackSetColor;
            }
            set
            {
                QRBackColor = ColorToInt(value);
            }
        }
        /// <summary>
        /// ����ת����ɫ
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public Color IntToColor(uint color) 
        {
            uint a = 0xFF & color;

            uint r = 0xFF00 & color;
            r >>= 8;

            uint g = 0xFF0000 & color;
            g >>= 16;

            uint b = 0xFF000000 & color;
            b >>= 24;

            return Color.FromArgb((int)a, (int)r, (int)g, (int)b);
        }
        /// <summary>
        /// ����ת����ɫ
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public uint ColorToInt(Color color)
        {
            uint res = (uint)color.A + (uint)(color.R << 8) + (uint)(color.G <<16) + (uint)(color.B <<24);

            return res;
        }


        private int _showTime;
        /// <summary>
        /// ��ʾ���ֵı���
        /// </summary>
        public int ShowTime
        {
            get { return _showTime; }
            set { _showTime = value; }
        }

        //private bool _listenClipboard=true;
        ///// <summary>
        ///// ����������
        ///// </summary>
        //public bool ListenClipboard
        //{
        //    get { return _listenClipboard; }
        //    set { _listenClipboard = value; }
        //}
        private string _password;
        /// <summary>
        /// ����
        /// </summary>
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        private bool _hasPointLine;
        /// <summary>
        /// ���͸�����
        /// </summary>

        public bool HasPointLine
        {
            get { return _hasPointLine; }
            set { _hasPointLine = value; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        [JsonIgnore()]
        public byte[] EncryPassword
        {
            get 
            {
                if (string.IsNullOrEmpty(_password)) 
                {
                    return null;
                }
                byte[] pwd=DefaultEncoding.GetBytes(_password);
                return _md5Hash.ComputeHash(pwd);
            }
        }
        private static readonly string ConfigPath = AppDomain.CurrentDomain.BaseDirectory + "\\config.cfg";
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="outItem">�������������</param>
        /// <returns></returns>
        public void SaveConfig() 
        {
            //using (FileStream file = new FileStream(ConfigPath, FileMode.Create, FileAccess.Write))
            //{
            //    using (BinaryWriter writer = new BinaryWriter(file))
            //    {
            //        try
            //        {
            //            writer.Write(_outItem);
            //            writer.Write((int)_hotKey);
            //            writer.Write((int)_modifiers);

            //            writer.Write(_side);
            //            writer.Write(_showTime);
            //            writer.Write(_listenClipboard);
            //            writer.Write((int)_readHotKey);
            //            writer.Write((int)_readModifiers);
                        
            //            if (_password != null)
            //            {
            //                writer.Write(_password.Trim());
            //            }
            //            writer.Write(_hasPointLine ? 1 : 0);
            //        }
            //        catch { }
            //    }
            //}
            string json = JsonConvert.SerializeObject(this);
            try
            {
                File.WriteAllText(ConfigPath, json, Encoding.UTF8);
            }
            catch { }
        }
        
        /// <summary>
        /// ��ȡ����
        /// </summary>
        /// <returns></returns>
        public static ConfigSave ReadConfig()
        {
            ConfigSave config = new ConfigSave();

            if (!File.Exists(ConfigPath)) 
            {
                return config;
            }
            //using (FileStream file = new FileStream(ConfigPath, FileMode.Open, FileAccess.Read))
            //{
            //    using (BinaryReader reader = new BinaryReader(file))
            //    {
            //        try
            //        {
            //            config._outItem = reader.ReadInt32();
            //            config._hotKey = (Keys)reader.ReadInt32();
            //            config._modifiers = (KeyModifiers)reader.ReadInt32();
            //            config._side = reader.ReadInt32(); 
            //            config._showTime = reader.ReadInt32();
            //            config._listenClipboard = reader.ReadBoolean();
            //            config._readHotKey = (Keys)reader.ReadInt32();
            //            config._readModifiers = (KeyModifiers)reader.ReadInt32();
            //            config._password = reader.ReadString();
            //            config._hasPointLine = reader.ReadInt32() == 1;
                        
            //        }
            //        catch { }
            //    }
            //}
            try
            {
                string json = File.ReadAllText(ConfigPath, Encoding.UTF8);
                JsonConvert.PopulateObject(json, config);
            }
            catch { }
            return config;
        }
    }
}
