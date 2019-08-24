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
    public partial class FrmGif : Form
    {
        public FrmGif()
        {
            InitializeComponent();
        }
        GifPlayer _gif = null;
        private void FrmGif_Load(object sender, EventArgs e)
        {
            _gif = new GifPlayer(pbImg);
            _gif.Play(AppDomain.CurrentDomain.BaseDirectory + "\\gif\\ScanQRInfo.gif", 3);
        }

        private void FrmGif_FormClosing(object sender, FormClosingEventArgs e)
        {
            _gif.Dispose();
        }
    }
}
