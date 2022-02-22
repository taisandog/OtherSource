using Buffalo.Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordFilter
{
    public class Base64Unit
    {
        /// <summary>
        /// 获取Base64字符串
        /// </summary>
        /// <returns></returns>
        public string GetBaseString(string str)
        {
            string retString = null;
            if (string.IsNullOrWhiteSpace(str)) 
            {
                return null;
            }
            str = str.Trim();
            bool isEncry = false;
            if (str.StartsWith(QRCodeUnit.EncryHead))
            {
                str = str.Substring(QRCodeUnit.EncryHead.Length);
                isEncry = true;
            }
            try
            {
                
                byte[] resByte=Convert.FromBase64String(str);

                if (isEncry) 
                {
                    ConfigSave config = Program.MainForm.Config;
                    byte[] pwd = config.EncryPassword;
                    resByte = PasswordHash.AESDecrypt(resByte, pwd);
                    
                }
                retString=QRCodeUnit.DefaultEncode.GetString(resByte);
            }
            catch (Exception ex)
            {
                FrmQRResault.ShowError("解析错误，请检查字符串或密码是否正确");
                return null;
            }

            return retString;
        }

        /// <summary>
        /// 把字符串打成Base64字符串
        /// </summary>
        /// <returns></returns>
        public string ToBaseString(string str, bool isEncry)
        {
            string retString = null;
            try
            {
                byte[] resByte = QRCodeUnit.DefaultEncode.GetBytes(str);
                if (isEncry)
                {
                    ConfigSave config = Program.MainForm.Config;
                    byte[] pwd = config.EncryPassword;
                    resByte = PasswordHash.AESEncrypt(resByte, pwd);
                    return QRCodeUnit.EncryHead + Convert.ToBase64String(resByte);
                }
                return Convert.ToBase64String(resByte);
            }
            catch (Exception ex)
            {
                FrmQRResault.ShowError("解密错误，请检查密码是否正确");
                return null;
            }

            return retString;
        }
    }
}
