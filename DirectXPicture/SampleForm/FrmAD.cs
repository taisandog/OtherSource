using Buffalo.D2DTools;
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
    public partial class FrmAD : Form
    {
        private int _fps = 60;
        public FrmAD(int fps=60)
        {
            _fps = fps;
            InitializeComponent();
        }
        PictureScroll picAD = null;
        private void FrmAD_Load(object sender, EventArgs e)
        {
            picAD = new PictureScroll(1000, 2000, pbImage.Size, pbImage, _fps);
            string[] paths = System.IO.Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + "\\images\\");
            picAD.LoadImages(paths);
            picAD.StartAD();
        }

        private void FrmAD_FormClosing(object sender, FormClosingEventArgs e)
        {
            picAD.Dispose();
        }
    }
}
