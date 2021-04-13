using Buffalo.Kernel;
using Buffalo.Kernel.ZipUnit;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PixivToVideo
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }
        private AppSave _config;

        private void FrmMain_Load(object sender, EventArgs e)
        {
            _config = new AppSave();
            _config.Load();

            FillFPS();
            FillBit();
            FillType();
            FillConfig();
        }
        // <summary>
        /// 填充信息
        /// </summary>
        private void FillConfig()
        {

            
            if (_config.Nuploop > nuploop.Minimum)
            {
                nuploop.Value = _config.Nuploop;
            }
            txtZip.Text = _config.TxtPath;
            txtOut.Text = _config.TxtOutPath;
            if (!string.IsNullOrWhiteSpace(_config.CmbOutput))
            {
                cmbOutput.SelectedValue = _config.CmbOutput;
            }
            else
            {
                cmbOutput.SelectedIndex = 0;
            }

            if (!string.IsNullOrWhiteSpace(_config.CmbBit))
            {
                cmbbit.SelectedValue = _config.CmbBit;
            }
            else
            {
                cmbbit.SelectedIndex = 0;
            }
            if (!string.IsNullOrWhiteSpace(_config.CmbOutFPS))
            {
                cmbOutFPS.SelectedValue = _config.CmbOutFPS;
            }
            else
            {
                cmbOutFPS.SelectedIndex = 0;
            }
        }
        private void SaveConfig()
        {
           
            _config.TxtPath = txtZip.Text;
            _config.TxtOutPath = txtOut.Text;
            _config.CmbOutput = cmbOutput.SelectedValue as string;
            _config.Nuploop = (int)nuploop.Value;
            _config.CmbBit = cmbbit.SelectedValue as string;
            _config.CmbOutFPS = cmbOutFPS.SelectedValue as string;
            _config.Save();
        }
        private void FillType()
        {
            List<ComboBoxItem> lst = new List<ComboBoxItem>();
            ComboBoxItem item = new ComboBoxItem();
            item.Text = "MP4(文件小，清晰，不循环)";
            item.Value = "mp4";
            lst.Add(item);
            item = new ComboBoxItem();
            item.Text = "GIF(文件大，比较模糊，可循环)";
            item.Value = "gif";
            lst.Add(item);
            cmbOutput.DataSource = lst;
            cmbOutput.DisplayMember = "Text";
            cmbOutput.ValueMember = "Value";
        }
        private void FillFPS()
        {
            List<ComboBoxItem> lst = new List<ComboBoxItem>();
            ComboBoxItem item = new ComboBoxItem();
            item.Text = "24帧(常用)";
            item.Value = "24";
            lst.Add(item);
            item = new ComboBoxItem();
            item.Text = "30帧";
            item.Value = "30";
            lst.Add(item);
            item = new ComboBoxItem();
            item.Text = "60帧";
            item.Value = "60";
            lst.Add(item);
            item = new ComboBoxItem();
            item.Text = "120帧(慎用)";
            item.Value = "120";
            lst.Add(item);
            item = new ComboBoxItem();
            item.Text = "12帧(GIF常用)";
            item.Value = "12";
            lst.Add(item);
            cmbOutFPS.DataSource = lst;
            cmbOutFPS.DisplayMember = "Text";
            cmbOutFPS.ValueMember = "Value";
        }
        private void FillBit()
        {
            List<ComboBoxItem> lst = new List<ComboBoxItem>();
            ComboBoxItem item = new ComboBoxItem();
            item.Text = "默认";
            item.Value = "";
            lst.Add(item);

            item = new ComboBoxItem();
            item.Text = "大码率(3.5M)";
            item.Value = "3.5M";
            lst.Add(item);

            item = new ComboBoxItem();
            item.Text = "中码率(1M)";
            item.Value = "1M";
            lst.Add(item);

            item = new ComboBoxItem();
            item.Text = "小码率(600K)";
            item.Value = "600K";
            lst.Add(item);

            cmbbit.DataSource = lst;
            cmbbit.DisplayMember = "Text";
            cmbbit.ValueMember = "Value";
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (ofdZip.ShowDialog() == DialogResult.OK) 
            {
                txtZip.Text = ofdZip.FileName;
                FileInfo finfo = new FileInfo(ofdZip.FileName);
                txtOut.Text = finfo.DirectoryName;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                SaveConfig();
                Application.DoEvents();
                //_cookies = new CookieContainer();
                string zipPath = txtZip.Text;
                string savePath = txtOut.Text;
                if (string.IsNullOrWhiteSpace(savePath))
                {
                    MessageBox.Show("请输入保存路径", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtZip.Focus();
                    return;
                }
                
               

                EncodeZip(zipPath, savePath);
                Process.Start(savePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "转换失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                
                btnSubmit.Text = "保存";
            }
        }

        private void EncodeZip(string fileName, string savePath)
        {
            string tempPath = savePath + "\\temp\\";
            //FileInfo efinfo = new FileInfo(fileName);
            ShowMessage("正在预编码");
            string unzipPath = tempPath + "\\unzip\\" + Path.GetFileNameWithoutExtension(fileName) + "\\";
            unzipPath = unzipPath.Replace("\\\\", "\\");
            using (FileStream file = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                SharpUnZipFile zip = new SharpUnZipFile(file);
                zip.UnZipFiles(unzipPath);
            }

            string jsonPath = unzipPath + "animation.json";
            string json = File.ReadAllText(jsonPath);
            FramePackInfos info = new FramePackInfos();
            info.PixivID = Path.GetFileNameWithoutExtension(fileName);
            List<FrameItem> lstFrame = JsonConvert.DeserializeObject<List<FrameItem>>(json);
            info.Frames = lstFrame;
            string[] files = Directory.GetFiles(unzipPath);
            if (files.Length > 0)
            {
                FileInfo finfo = new FileInfo(files[0]);


                using (Image bmp = Bitmap.FromFile(files[0]))
                {
                    info.PicSize = bmp.Size;
                }
            }

            string perPack = tempPath + "\\pack\\" + Path.GetFileNameWithoutExtension(fileName) + "\\";
            perPack = perPack.Replace("\\\\", "\\");
            if (!Directory.Exists(perPack))
            {
                Directory.CreateDirectory(perPack);
            }




            SavePerPack(perPack, unzipPath, info);

            ShowMessage("正在转码");
            try
            {
                RunEncode(perPack, savePath, info, 8);
            }
            finally
            {
                Directory.Delete(unzipPath, true);
                Directory.Delete(perPack, true);
            }
        }
        /// <summary>
        /// 运行编码
        /// </summary>
        private void RunEncode(string tmppath, string savePath, FramePackInfos info, int fileLen)
        {
            string outType = _config.CmbOutput;
            if (string.IsNullOrWhiteSpace(outType))
            {
                outType = "mp4";
            }
            int loop = (int)nuploop.Value;

            string outVideo = savePath + "\\" + info.PixivID + "." + outType;
            string mpegPath = CommonMethods.GetBaseRoot() + "ffmpg\\";
            if (IntPtr.Size == 8)
            {
                mpegPath = mpegPath + "ffmpegx64.exe";
            }
            else
            {
                mpegPath = mpegPath + "ffmpeg.exe";
            }

            string prm = null;
            string bit = _config.CmbBit;
            string outfps = _config.CmbOutFPS;
            int fps = 1000 / info.MinDelayPer;
            if (string.Equals(outType, "mp4"))
            {
                //prm = "-threads 2 -f image2 -i \"" + tmppath + "%" + fileLen.ToString("D2") + "d.jpg\"  -r " + fps + " -y -c:v libx264 -b 1M -c:a libfaac-ab -ar 44100 -pix_fmt yuv420p -f mp4 \"" + outVideo + "\"";
                StringBuilder sb = new StringBuilder();
                sb.Append("-threads 4 -f image2 -r " + fps);

                if (loop > 0)
                {
                    sb.Append(" -stream_loop ");
                    sb.Append(loop.ToString());
                    sb.Append(" ");
                }
                sb.Append(" -i \"");
                sb.Append(tmppath.Replace("\\\\", "\\"));
                sb.Append("%");
                sb.Append(fileLen.ToString("D2"));
                sb.Append("d.jpg\"  -r ");
                sb.Append(outfps);
                sb.Append(" -y -c:v libx264");
                if (!string.IsNullOrWhiteSpace(bit))
                {
                    sb.Append(" -b ");
                    sb.Append(bit);
                }
                if (!info.PicSize.IsEmpty)
                {
                    sb.Append(" -s ");
                    int value = info.PicSize.Width;
                    if (value % 2 > 0)
                    {
                        value = value + 1;
                    }
                    sb.Append(value);
                    sb.Append("x");
                    value = info.PicSize.Height;
                    if (value % 2 > 0)
                    {
                        value = value + 1;
                    }
                    sb.Append(value);
                }
                sb.Append(" -c:a libfaac-ab -ar 44100 -pix_fmt yuv420p -f mp4 \"");
                sb.Append(outVideo.Replace("\\\\", "\\"));
                sb.Append("\"");
                prm = sb.ToString();
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("-threads 2 -f image2 -r " + fps);
                sb.Append(" -i \"");
                sb.Append(tmppath.Replace("\\\\", "\\"));
                sb.Append("%");
                sb.Append(fileLen.ToString("D2"));
                sb.Append("d.jpg\" -loop 0 -r " + outfps);

                if (!string.IsNullOrWhiteSpace(bit))
                {
                    sb.Append(" -b ");
                    sb.Append(bit);
                }
                sb.Append(" -y \"");
                sb.Append(outVideo);
                sb.Append("\"");
                prm = sb.ToString();
                //prm = "-threads 2 -f image2 -i \""+ tmppath + "%" + fileLen.ToString("D2") + "d.jpg\" -b 2048k -loop 0 -y \"" + outVideo+"\"";
            }
            Process.Start(mpegPath, prm).WaitForExit();

        }
        /// <summary>
        /// 保存要打包的图片
        /// </summary>
        /// <param name="perPackPath"></param>
        /// <param name="unzip"></param>
        /// <param name="info"></param>
        private void SavePerPack(string perPackPath, string unzip, FramePackInfos info)
        {
            string[] files = Directory.GetFiles(unzip);
            Dictionary<string, string> dic = new Dictionary<string, string>(StringComparer.CurrentCultureIgnoreCase);
            string exName = null;

            string json = perPackPath + "\\animation.json";


            foreach (string str in files)
            {
                if (str.EndsWith("animation.json", StringComparison.CurrentCultureIgnoreCase))
                {
                    continue;
                }
                FileInfo finfo = new FileInfo(str);
                if (!finfo.Exists)
                {
                    continue;
                }
                dic[finfo.Name] = str.Trim();
                if (string.IsNullOrWhiteSpace(exName))
                {
                    exName = finfo.Extension;
                }
            }
            string curFile = null;
            int curIndex = 0;
            int perFrm = info.MinDelayPer;
            foreach (FrameItem item in info.Frames)
            {
                string fileKey = item.File;
                if (!dic.TryGetValue(fileKey, out curFile))
                {
                    continue;
                }
                int count = (int)Math.Ceiling((decimal)item.Delay / (decimal)perFrm);
                if (count <= 0)
                {
                    count = 1;
                }
                for (int i = 0; i < count; i++)
                {
                    string newFileName = perPackPath + curIndex.ToString("D8") + exName;
                    File.Copy(curFile, newFileName, true);
                    curIndex++;
                }
            }
        }

        /// <summary>
        /// 显示消息
        /// </summary>
        /// <param name="message"></param>
        private void ShowMessage(string message)
        {
            btnSubmit.Text = message;
            Application.DoEvents();
        }
    }
}
