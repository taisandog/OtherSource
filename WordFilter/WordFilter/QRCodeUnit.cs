using System;
using System.Collections.Generic;
using System.Text;
using ZXing.QrCode;
using ZXing;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using ZXing.Common;
using Buffalo.Kernel;


namespace WordFilter
{
    /// <summary>
    /// 二维码工具
    /// </summary>
    public class QRCodeUnit
    {
        DecodingOptions _decodeOption;
        
        BarcodeReader _qrRead = null;
        Size _qrSize = new Size(300,300);
        public Size QRSize 
        {
            get 
            {
                return _qrSize;
            }
            set 
            {
                _qrSize = value;
                
            }
        }

        public readonly static Encoding DefaultEncode = Encoding.UTF8;
        public QRCodeUnit() 
        {

            _qrRead = new BarcodeReader();
            _qrRead.Options.CharacterSet = "UTF-8";
        }
        public static string EncryHead = "<?ep";


        /// <summary>
        /// 获取剪贴板的文件
        /// </summary>
        /// <returns></returns>
        public static Bitmap GetClipboardBitmap()
        {
            Bitmap bmp = null;
            if (Clipboard.ContainsImage())
            {
                bmp = Clipboard.GetData(DataFormats.Bitmap) as Bitmap;
                if (bmp != null)
                {
                    return bmp;
                }
            }
            if (Clipboard.ContainsFileDropList())
            {
                string[] strs = Clipboard.GetData(DataFormats.FileDrop) as string[];
                if (strs != null && strs.Length > 0)
                {
                    string path = strs[0];
                    try
                    {
                        if (File.Exists(path))
                        {
                            bmp = Bitmap.FromFile(path) as Bitmap;
                            return bmp;
                        }
                    }
                    catch { }
                }
            }
            return null;
        }

        /// <summary>
        /// 获取二维码字符串
        /// </summary>
        /// <returns></returns>
        public string GetQRCodeString(Bitmap bmap)
        {

           

            if (bmap == null)
            {
                return null;
            }

            string retString = null;
            try
            {
                Result results = _qrRead.Decode(bmap);
                if (results != null)
                {
                    retString = DeEncryString(results.Text);
                }
            }
            catch (Exception ex)
            {
                FrmQRResault.ShowError("解密错误，请检查密码是否正确");
                //MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            return retString;
        }

        /// <summary>
        /// 解密字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private string DeEncryString(string str) 
        {
            if (str.IndexOf(EncryHead)==0) 
            {
                string content = str.Substring(EncryHead.Length);
                byte[] arrStr = CommonMethods.HexStringToBytes(content);
                ConfigSave config = Program.MainForm.Config;
                byte[] pwd = config.EncryPassword;
                byte[] enStr = PasswordHash.AESDecrypt(arrStr, pwd);

                return DefaultEncode.GetString(enStr);
            }else
            {
                return str;
            }
            return str;
        }

        /// <summary>
        /// 根据字符串生成二维码
        /// </summary>
        /// <param name="content">字符串</param>
        /// <returns></returns>
        public Bitmap GetQRCode(string content) 
        {
            StringBuilder sbCode = new StringBuilder(content.Length +3);
            //sbCode.Append("0");
            sbCode.Append(content);
            Bitmap bmp = CreateQRCode(sbCode.ToString());
            return bmp;
        }

        /// <summary>
        /// 根据字符串生成加密二维码
        /// </summary>
        /// <param name="content">字符串</param>
        /// <returns></returns>
        public Bitmap GetEncryQRCode(string content)
        {
            StringBuilder sbCode = new StringBuilder(content.Length * 2);
            sbCode.Append(EncryHead);
            sbCode.Append(EncryString(content));
            Bitmap bmp = CreateQRCode(sbCode.ToString());
            return bmp;
        }

        

        /// <summary>
        /// 加密字符串
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        private string EncryString(string content) 
        {
            ConfigSave config = Program.MainForm.Config;
            byte[] arrStr = DefaultEncode.GetBytes(content);
            byte[] pwd=config.EncryPassword;
            byte[] enStr = PasswordHash.AESEncrypt(arrStr, pwd);
            return CommonMethods.BytesToHexString(enStr,false);
        }



        /// <summary>
        /// 根据字符串生成二维码
        /// </summary>
        /// <param name="content">字符串</param>
        /// <returns></returns>
        public Bitmap CreateQRCode(string content)
        {
            //StringBuilder sbCode = new StringBuilder(content.Length + 3);
            //sbCode.Append(content);
            Dictionary<EncodeHintType, object> hints = new Dictionary<EncodeHintType, object>();
            hints[EncodeHintType.CHARACTER_SET] = "UTF-8";
            BitMatrix matrix = new MultiFormatWriter().encode(content, BarcodeFormat.QR_CODE, _qrSize.Width, _qrSize.Height,hints);
            matrix = CutWhiteBorder(matrix);
            QrCodeEncodingOptions options = new QrCodeEncodingOptions();
            options.CharacterSet = "UTF-8";
            options.DisableECI = true;
            options.ErrorCorrection = ZXing.QrCode.Internal.ErrorCorrectionLevel.H;
            options.Margin = 1;

            ConfigSave config = Program.MainForm.Config;
            BarcodeWriter writer = new BarcodeWriter();
            writer.Renderer = new ZXing.Rendering.BitmapRenderer { Foreground = config.QRSetColor, Background = config.QRBackSetColor };
            writer.Format = BarcodeFormat.QR_CODE;
            writer.Options = options;
            
            writer.Options.Width = matrix.Width;
            writer.Options.Height = matrix.Height;


            Bitmap bmp = writer.Write(matrix);
            if (bmp.Size == _qrSize)
            {
                return bmp;
            }
            Bitmap ret = Picture.ReSizePicturee(bmp, _qrSize.Width, _qrSize.Height);
            bmp.Dispose();
            return ret;

        }
        /// <summary>
        /// 切除白边
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        private static BitMatrix CutWhiteBorder(BitMatrix matrix)
        {
            int border = 3;//边框宽度
            int[] rec = matrix.getEnclosingRectangle();
            int resWidth = rec[2] + (border * 2);
            int resHeight = rec[3] + (border * 2);
            BitMatrix resMatrix = new BitMatrix(resWidth + 1, resHeight + 1);
            resMatrix.clear();
            for (int i = 0; i < resWidth; i++)
            {
                for (int j = 0; j < resHeight; j++)
                {
                    if (matrix[i + rec[0], j + rec[1]])
                    {
                        resMatrix.flip(i + border, j + border);
                    }
                }
            }
            return resMatrix;
        }


    }
}
