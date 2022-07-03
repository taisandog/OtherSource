using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordFilter
{
    public partial class FrmWaterMark : Form
    {
        public FrmWaterMark()
        {
            InitializeComponent();
        }

        private void FrmWaterMark_Load(object sender, EventArgs e)
        {

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
           

        }

        private string _openFileName = null;

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            string path = null;
            if (ofd.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            path = ofd.FileName;
            if (string.IsNullOrWhiteSpace(path))
            {

                return;
            }
            if (!File.Exists(path))
            {
                MessageBox.Show(path + " 文件不存在");
                return;
            }
            try
            {
                using (Image img = Image.FromFile(path))
                {
                    SetImage(img);
                }
                _openFileName = path;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLoadClipboard_Click(object sender, EventArgs e)
        {
            try
            {
                using (Image cImage = QRCodeUnit.GetClipboardBitmap())
                {
                    if (cImage == null)
                    {
                        return;
                    }
                    SetImage(cImage);
                }
                _openFileName = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetImage(Image img) 
        {
            Image old = pbImage.Image;
            pbImage.Image = null;
            if (old != null) 
            {
                old.Dispose();
            }
            pbImage.Image = img.Clone() as Image;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            string dic = BlindWaterMarkUnit.GetBaseRoot("tmpImage");
            string tmppath = Path.Combine(dic, "targetWaterMark.jpg");
            try
            {
                string path = GetOpenPath(dic);
                if (File.Exists(tmppath))
                {
                    File.Delete(tmppath);
                }
                BlindWaterMarkUnit.OutputWatermark(path, tmppath);
                OpenImage(tmppath);
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.ToString(),"错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private string GetOpenPath(string directory) 
        {
            Image cImage = pbImage.Image;

            if (cImage == null)
            {
                return null;
            }
           
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            string path = _openFileName;
            if (string.IsNullOrWhiteSpace(path))
            {
                path = Path.Combine(directory, "sourceFileImage.jpg");
                if (File.Exists(path)) 
                {
                    File.Delete(path);
                }
                cImage.Save(path, ImageFormat.Png);
            }
            return path;
        }

        private void OpenImage(string fileName)
        {
            try
            {
                Process.Start(fileName);
            }
            catch (Exception ex)
            {
                // LogHelper.WriteLog("调用默认看图软件打开失败", ex);
                try
                {
                    string arg =
                        string.Format(
                            "\"{0}\\Windows Photo Viewer\\PhotoViewer.dll\", ImageView_Fullscreen  {1} ",
                            Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)
                            , fileName);
                    var dllExe = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System),
                        "rundll32.exe");
                    // LogHelper.WriteLog(string.Format("调用系统默认的图片查看器打开图片，参数为：{0} {1}", dllExe, arg));
                    System.Diagnostics.Process.Start(dllExe, arg);
                }
                catch (Exception e)
                {
                    //打开文件夹并选中文件
                    var argment = string.Format(@"/select,""{0}""", fileName);
                    System.Diagnostics.Process.Start("Explorer", argment);
                }
            }
        }

        private void btnPutFile_Click(object sender, EventArgs e)
        {

           
            
            string waterMark = txtWaterMark.Text;
            if (string.IsNullOrWhiteSpace(waterMark)) 
            {
                MessageBox.Show("请填入水印");
                return;
            }

            if (sfd.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            string outpath = sfd.FileName;

            waterMark = waterMark.Trim();
            string dic = BlindWaterMarkUnit.GetBaseRoot("tmpImage");
            
            try
            {
                string path = GetOpenPath(dic);
                if (File.Exists(outpath))
                {
                    File.Delete(outpath);
                }
                BlindWaterMarkUnit.WriteWatermark(path, outpath, waterMark);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void btnPutToClipboard_Click(object sender, EventArgs e)
        {
            string waterMark = txtWaterMark.Text;
            if (string.IsNullOrWhiteSpace(waterMark))
            {
                MessageBox.Show("请填入水印");
                return;
            }

            waterMark = waterMark.Trim();
            string directory = BlindWaterMarkUnit.GetBaseRoot("tmpImage");

            string outpath = Path.Combine(directory, "outImage.jpg");
            try
            {
                string path = GetOpenPath(directory);
                if (File.Exists(outpath))
                {
                    File.Delete(outpath);
                }
                BlindWaterMarkUnit.WriteWatermark(path, outpath, waterMark);
                using (Image image = Image.FromFile(outpath))
                {
                    Clipboard.SetData(DataFormats.Bitmap, image);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
