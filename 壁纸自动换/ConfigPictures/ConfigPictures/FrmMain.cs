using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ConfigPictures
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void chkAutoRun_CheckedChanged(object sender, System.EventArgs e)
        {
            RegConfig.IsAutoRun = chkAutoRun.Checked;
        }

        /// <summary>
        /// 刷新文件列表
        /// </summary>
        private void RefreashList()
        {
            lstFiles.SelectedIndex = -1;
            lstFiles.Items.Clear();
            if (!Directory.Exists(PictureManager.PicPath))
            {
                Directory.CreateDirectory(PictureManager.PicPath);
            }
            string[] files = Directory.GetFiles(PictureManager.PicPath, "*.png");
            for (int q = 0; q < files.Length; q++)
            {
                char[] cha = { '\\' };

                string[] picn = files[q].Split(cha);
                lstFiles.Items.Add(picn[picn.Length - 1]);
            }
        }

        /// <summary>
        /// 获取桌面分辨率
        /// </summary>
        private void LoadDeskTopSize()
        {
            txtWidth.Value = Screen.PrimaryScreen.Bounds.Width;
            txtHeight.Value = Screen.PrimaryScreen.Bounds.Height;
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            if (ofdImg.ShowDialog() == DialogResult.OK)
            {
                string[] files = ofdImg.FileNames;
                Size targetSize = Size.Empty;
                if (cbConvert.Checked)
                {
                    targetSize = PicSize;
                }
                PictureManager.CopyPicture(files, targetSize);
                RefreashList();
            }
        }

        private void lstFiles_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (lstFiles.SelectedIndex >= 0)
            {
                string root = lstFiles.Items[lstFiles.SelectedIndex].ToString();

                ClearPicture();
                pbPic.Image = PictureManager.LoadPicture(root);
            }
        }

        private void btnDelete_Click(object sender, System.EventArgs e)
        {
            if (lstFiles.SelectedIndex >= 0)
            {
                if (MessageBox.Show("是否删除选定的图片？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ClearPicture();
                    foreach (int index in lstFiles.SelectedIndices)
                    {
                        PictureManager.DeletePicture(lstFiles.Items[index].ToString());
                    }
                    MessageBox.Show("删除完毕", "提示", MessageBoxButtons.OK);
                    RefreashList();
                }
            }
        }

        /// <summary>
        /// 清空预览框的图片
        /// </summary>
        private void ClearPicture()
        {
            if (pbPic.Image != null)
            {
                Image img = pbPic.Image;
                pbPic.Image = null;
                img.Dispose();
            }
        }

        private void cbConvert_CheckedChanged(object sender, System.EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            EnSize(cb.Checked);
        }

        /// <summary>
        /// 开启设置图片大小的框
        /// </summary>
        /// <param name="isEnable"></param>
        private void EnSize(bool isEnable)
        {
            txtWidth.Enabled = isEnable;
            txtHeight.Enabled = isEnable;
        }

        /// <summary>
        /// 获取用户设置的分辨率
        /// </summary>
        private Size PicSize
        {
            get
            {
                Size objSize = new Size((int)txtWidth.Value, (int)txtHeight.Value);
                return objSize;
            }
        }

        private void lstFiles_DragDrop(object sender, DragEventArgs e)
        {
            Size targetSize = Size.Empty;
            if (cbConvert.Checked)
            {
                targetSize = PicSize;
            }
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                string[] files = e.Data.GetData(DataFormats.FileDrop) as string[];
                PictureManager.CopyPicture(files, targetSize);
                RefreashList();
            }
        }

        private void lstFiles_DragEnter(object sender, DragEventArgs e)
        {

            e.Effect = DragDropEffects.All;

        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            try
            {
                chkAutoRun.Checked = RegConfig.IsAutoRun;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            RefreashList();
            LoadDeskTopSize();
        }
    }
}
