﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TagLib.Id3v2;

namespace DumpQMC.Unit.NetesatMusic
{
    class NotNeteaseFileException : IOException
    {
        public NotNeteaseFileException(string name)
            : base(string.Format(@"""{0}"" not netease music file", name))
        {

        }
    }

    public class NeteaseCrypto : IComparable<NeteaseCrypto>
    {
        private static byte[] _flag = new byte[8] { 0x43, 0x54, 0x45, 0x4e, 0x46, 0x44, 0x41, 0x4d };

        private static byte[] _id3Flag = new byte[3] { 0x49, 0x44, 0x33 };
        private static byte[] _pngFlag = new byte[8] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A };

        private static byte[] _coreBoxKey = new byte[16] { 0x68, 0x7A, 0x48, 0x52, 0x41, 0x6D, 0x73, 0x6F, 0x35, 0x6B, 0x49, 0x6E, 0x62, 0x61, 0x78, 0x57 };
        private static byte[] _modifyBoxKey = new byte[16] { 0x23, 0x31, 0x34, 0x6C, 0x6A, 0x6B, 0x5F, 0x21, 0x5C, 0x5D, 0x26, 0x30, 0x55, 0x3C, 0x27, 0x28 };

        private NeteaseCopyrightData _cdata = null;

        private byte[] _imageCover;
        private Bitmap _cover = null;
        public Bitmap Cover { get => _cover; }

        private double _progress;
        public double Progress { get => _progress; }

        List<string> artist = null;
        public string[] Artist
        {
            get
            {
                if (_cdata != null && artist == null)
                {
                    if (_cdata.Artist != null)
                    {
                        artist = new List<string>();
                        foreach (var item in _cdata.Artist)
                        {
                            artist.Add(item[0].ToString());
                        }
                    }
                }

                if (artist != null)
                    return artist.ToArray();
                return null;
            }
        }

        public string Format
        {
            get
            {
                if (_cdata != null)
                {
                    return _cdata.Format;
                }
                return null;
            }
        }

        public int Bitrate
        {
            get
            {
                if (_cdata != null)
                {
                    return _cdata.Bitrate;
                }
                return 0;
            }
        }

        public int Duration
        {
            get
            {
                if (_cdata != null)
                {
                    return _cdata.Duration;
                }
                return 0;
            }
        }

        public string Name
        {
            get
            {
                if (_cdata != null)
                {
                    return _cdata.MusicName;
                }
                return null;
            }
        }

       

        private byte[] _keyBox;

        private readonly Stream _file;

        public NeteaseCrypto(Stream file)
        {
            _file = file;

            byte[] flag = new byte[8];
            file.Read(flag, 0, flag.Length);

            if (!flag.SequenceEqual(_flag))
            {
                throw new NotNeteaseFileException("不存在文件");
            }

            // not use less
            file.Seek(2, SeekOrigin.Current);

            byte[] coreKeyChunk = ReadChunk(file);
            for (int i = 0; i < coreKeyChunk.Length; i++)
            {
                coreKeyChunk[i] ^= 0x64;
            }
            int ckcLen = AesDecrypt(coreKeyChunk, _coreBoxKey);

            byte[] finalKey = new byte[ckcLen - 17];
            Array.Copy(coreKeyChunk, 17, finalKey, 0, finalKey.Length);

            _keyBox = new byte[256];
            for (int i = 0; i < _keyBox.Length; i++)
            {
                _keyBox[i] = (byte)i;
            }

            byte swap = 0;
            byte c = 0;
            byte last_byte = 0;
            byte key_offset = 0;

            for (int i = 0; i < _keyBox.Length; i++)
            {
                swap = _keyBox[i];
                c = (byte)((swap + last_byte + finalKey[key_offset++]) & 0xff);
                if (key_offset >= finalKey.Length) key_offset = 0;
                _keyBox[i] = _keyBox[c];
                _keyBox[c] = swap;
                last_byte = c;
            }

            byte[] dontModifyChunk = ReadChunk(file);

            if (dontModifyChunk != null)
            {

                int startIndex = 0;
                for (int i = 0; i < dontModifyChunk.Length; i++)
                {
                    dontModifyChunk[i] ^= 0x63;
                    if (dontModifyChunk[i] == 58 && startIndex == 0)
                    {
                        startIndex = i + 1;
                    }
                }

                byte[] dontModifyDecryptChunk = Convert.FromBase64String(Encoding.UTF8.GetString(dontModifyChunk, startIndex, dontModifyChunk.Length - startIndex));
                int mdcLen = AesDecrypt(dontModifyDecryptChunk, _modifyBoxKey);

                DataContractJsonSerializer d = new DataContractJsonSerializer(typeof(NeteaseCopyrightData));
                // skip `music:`
                using (MemoryStream reader = new MemoryStream(dontModifyDecryptChunk, 6, mdcLen - 6))
                {
                    _cdata = d.ReadObject(reader) as NeteaseCopyrightData;
                }
            }

            // skip crc & some use less chunk
            file.Seek(9, SeekOrigin.Current);

            _imageCover = ReadChunk(file);

            if (_imageCover != null)
            {
                using (MemoryStream imageStream = new MemoryStream(_imageCover))
                {
                    _cover = Image.FromStream(imageStream) as Bitmap;
                }
            }
        }
        public static uint ReadUInt32(Stream fs)
        {
            byte[] raw = new byte[4];
            int ret = fs.Read(raw, 0, raw.Length);

            if (ret != raw.Length)
            {
                throw new IOException("out of stream");
            }

            return BitConverter.ToUInt32(raw, 0);
        }

        private byte[] ReadChunk(Stream fs)
        {
            uint len = ReadUInt32(fs);

            if (len > 0)
            {

                byte[] chunk = new byte[len];

                // unsafe
                fs.Read(chunk, 0, (int)len);

                return chunk;
            }

            return null;
        }

        private int AesDecrypt(byte[] data, byte[] key)
        {
            var aes = Aes.Create();
            aes.Mode = CipherMode.ECB;
            aes.Key = key;
            aes.Padding = PaddingMode.PKCS7;

            using (MemoryStream stream = new MemoryStream(data))
            {
                using (CryptoStream cs = new CryptoStream(stream, aes.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    return cs.Read(data, 0, data.Length);
                }
            }
        }

        private bool byteCompare(byte[] src, byte[] dst)
        {
            if (src.Length > dst.Length)
                return false;

            for (int i = 0; i < src.Length; i++)
            {
                if (dst[i] != src[i])
                    return false;
            }

            return true;
        }

        private string getMime(byte[] imgData)
        {
            if (byteCompare(_pngFlag, imgData))
            {
                return "image/png";
            }

            return "image/jpeg";
        }

        public void Dump(string filePath)
        {
            int n = 0x8000;
            double totalLen = _file.Length - _file.Position;
            double alreadyProcess = 0;

           

            using (Stream stream = File.Open(filePath, FileMode.Create))
            {
                while (n > 1)
                {
                    byte[] chunk = new byte[n];
                    n = _file.Read(chunk, 0, n);

                    for (int i = 0; i < n; i++)
                    {
                        int j = (i + 1) & 0xff;
                        chunk[i] ^= _keyBox[(_keyBox[j] + _keyBox[(_keyBox[j] + j) & 0xff]) & 0xff];
                    }
                    
                    
                        stream.Write(chunk, 0, n);
                   

                    alreadyProcess += n;

                    _progress = (alreadyProcess / totalLen) * 100d;
                }
            }

            TagLib.File f = null;
            TagLib.Tag tag = null;
            TagLib.ByteVector imgCoverData = null;
            if (_imageCover != null)
            {
                imgCoverData = new TagLib.ByteVector(_imageCover, _imageCover.Length);
            }
            if (Format.ToLower() == "mp3")
            {
                f = TagLib.Mpeg.File.Create(filePath);
                tag = f.GetTag(TagLib.TagTypes.Id3v2);
                if (imgCoverData != null)
                {
                    AttachedPictureFrame frame = new AttachedPictureFrame();
                    frame.MimeType = getMime(_imageCover);
                    frame.Data = imgCoverData;
                    ((TagLib.Id3v2.Tag)tag).AddFrame(frame);
                }
            }
            else if (Format.ToLower() == "flac")
            {
                f = TagLib.Flac.File.Create(filePath);
                tag = f.Tag;

                if (imgCoverData != null)
                {
                    TagLib.Picture picture = new TagLib.Picture(imgCoverData);
                    picture.MimeType = getMime(_imageCover);
                    picture.Type = TagLib.PictureType.FrontCover;

                    TagLib.IPicture[] pics = new TagLib.IPicture[tag.Pictures.Length + 1];
                    for (int i = 0; i < tag.Pictures.Length; i++)
                    {
                        pics[i] = tag.Pictures[i];
                    }
                    pics[pics.Length - 1] = picture;

                    tag.Pictures = pics;
                }
            }
            tag.Title = Name;
            tag.Performers = Artist;
            tag.Album = _cdata.Album;
            tag.Comment = "Create by netease copyright protected dump tool gui. author 5L";

            f.Save();

        }

        public int CompareTo(NeteaseCrypto other)
        {
            if (Progress == 100) return -1;
            if (Progress > other.Progress) return 0;
            return 1;
        }

        public void CloseFile()
        {
            if (_file != null)
                _file.Dispose();
        }
    }
}
