using Buffalo.DBTools;
using DumpQMC.Unit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unit;

namespace DumpQMC
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private AppSave _save = new AppSave();

        

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string[] fileNames = ofd.FileNames;
                if (fileNames==null || fileNames.Length <=0)
                {
                    return;
                }
                AddToList(fileNames);
                FileInfo finfo = new FileInfo(fileNames[0]);
                _save.LastLoad = finfo.DirectoryName;
                _save.Save();
            }
        }

        private void AddToList(IEnumerable<string> files)
        {
            string exName = null;
            foreach (string fileName in files)
            {
                FileInfo finfo = new FileInfo(fileName);
                exName = finfo.Extension;
                if (string.IsNullOrWhiteSpace(exName))
                {
                    continue;
                }
                exName = exName.Trim('.');
                if (DecoderManager.HasDecode(exName))
                {
                    lstFiles.Items.Add(fileName);
                }
            }
        }
        Thread _thdDecode = null;
        
        private void btnDecode_Click(object sender, EventArgs e)
        {
            if (_thdDecode != null)
            {
                EnableDecode(false);
                return;
            }

            if (string.IsNullOrWhiteSpace(cmbTarget.Text))
            {
                MessageBox.Show("请填入输出目录","提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (lstFiles.Items.Count<=0)
            {
                MessageBox.Show("请选择要输出的文件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string targetPath = cmbTarget.Text;
            if (cmbTarget.Text == "<歌曲同目录>")
            {
                targetPath = null;
            }
            if (targetPath != null)
            {
                targetPath = AppSave.FormatPath(targetPath);
                if (!Directory.Exists(targetPath))
                {
                    try
                    {
                        Directory.CreateDirectory(targetPath);
                    }catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                
            }
            _save.OutputPath = targetPath;
            _save.Save();

            pb.Maximum = lstFiles.Items.Count;
            EnableDecode(true);
            _thdDecode = new Thread(new ThreadStart(ToDecode));
            _thdDecode.Start();
        }

        private void EnableDecode(bool enable)
        {
            
            if (!enable)
            {
                
                _thdDecode = null;
                SetProcess(0);
            }
            this.Invoke((EventHandler)delegate
            {
                btnDecode.Text = enable ? "停止转换" : "开始转换";
            });
        }

        private void ToDecode()
        {
            string targetPath = _save.OutputPath;
            string tFile = null;

            for (int i = 0; i < lstFiles.Items.Count; i++)
            {

                string sourceFile = lstFiles.Items[i].ToString();
                msg.Log("正在转换:" + sourceFile);
                try
                {
                    using (FileStream stmSource = File.Open(sourceFile, FileMode.Open))
                    {
                        FileInfo finfo = new FileInfo(sourceFile);
                        string sourceEx = finfo.Extension.Trim('.');
                        IMusicDecode decode = DecoderManager.CreateDecode(sourceEx);
                        if (decode == null)
                        {
                            msg.LogError(sourceEx + "文件不存在解码");
                            return;
                        }
                        decode.Load(stmSource, sourceEx);

                        tFile = GetTargetPath(targetPath, sourceFile, decode);



                        decode.Dump(tFile);

                    }
                } catch (Exception ex)
                {
                    msg.LogError(ex.ToString());
                }
                msg.Log(sourceFile + " 转换完毕");
                SetProcess(i);
            }
            SetProcess(0);
            MessageBox.Show("转换完毕", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            msg.Log("转换完毕");
            EnableDecode(false);
            this.Invoke((EventHandler)delegate
            {
                lstFiles.Items.Clear();
            });
        }

        private string GetTargetPath(string targetPath, string sourceFile, IMusicDecode decode)
        {
            FileInfo finfo = new FileInfo(sourceFile);
            if (string.IsNullOrWhiteSpace(targetPath))
            {
                targetPath = AppSave.FormatPath(finfo.DirectoryName);

            }
            StringBuilder retName = new StringBuilder();
            string fName = finfo.Name.Substring(0, finfo.Name.Length - finfo.Extension.Length);
            string newExName = decode.Format;
            int index = 0;
            do
            {
                retName.Clear();
                retName.Append(targetPath);
                retName.Append(fName);
                if (index > 0)
                {
                    retName.Append("(");
                    retName.Append(index.ToString());
                    retName.Append(")");
                }
                retName.Append(".");
                retName.Append(newExName);
                index++;
            } while (File.Exists(retName.ToString()));

            return retName.ToString();

        }

        private void SetProcess(int current)
        {
            this.Invoke((EventHandler)delegate
            {
                pb.Value = current;
            });
        }

        private void FrmMain_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }

        }

        private void FrmMain_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                string[] files = e.Data.GetData(DataFormats.FileDrop, false) as string[];
                AddToList(files);
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, " Error ",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 设置标题
        /// </summary>
        private void SetTitle()
        {
            this.Text = ToolVersionInfo.GetTitle("音乐文件解密（网易音乐、QQ音乐）", this.GetType().Assembly);
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            _save.Load();
            if (string.IsNullOrWhiteSpace(_save.LastLoad))
            {
                _save.LastLoad = AppSave.GetBaseRoot();
            }
            ofd.InitialDirectory = _save.LastLoad;

            if (!string.IsNullOrWhiteSpace(_save.OutputPath))
            {
                cmbTarget.Text = _save.OutputPath;
            }

            EnableDecode(false);
            SetTitle();
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                cmbTarget.Text = fbd.SelectedPath;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lstFiles.Items.Clear();
        }
    }
}
