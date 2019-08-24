using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleForm
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnAD_Click(object sender, EventArgs e)
        {
            FrmAD frm = new FrmAD((int)txtFps.Value);
            frm.Show();
        }

        private void btnGif_Click(object sender, EventArgs e)
        {
            FrmGif frm = new FrmGif();
            frm.Show();
        }
    }
}
