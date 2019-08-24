using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WebShare
{
    public partial class FrmAddShare : Form
    {
        
        public FrmAddShare()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ����
        /// </summary>
        public string Name 
        {
            get 
            {
                return txtName.Text;
            }
        }

        /// <summary>
        /// �ļ���
        /// </summary>
        public string Path 
        {
            get 
            {
                return txtPath.Text;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text.Trim())) 
            {
                MessageBox.Show("����������" , "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtPath.Text.Trim()))
            {
                MessageBox.Show("��ѡ���ļ���", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Program.Config.ShareInfos.FindItem(txtName.Text) != null) 
            {
                MessageBox.Show("�Ѿ���������:" + txtName.Text, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Program.Config.ShareInfos.FindItemByPath(txtPath.Text) != null)
            {
                MessageBox.Show("�Ѿ������ļ���:" + txtPath.Text, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void FrmAddShare_Load(object sender, EventArgs e)
        {

        }

        private void btnDic_Click(object sender, EventArgs e)
        {
            if (fbd.ShowDialog() == DialogResult.OK) 
            {
                txtPath.Text = fbd.SelectedPath;
            }
        }
    }
}