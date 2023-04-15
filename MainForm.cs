using KutuphaneOtomasyon.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KutuphaneOtomasyon
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnKitaplar_Click(object sender, EventArgs e)
        {
            new formKitap().ShowDialog();
        }

        private void btnKitapTurleri_Click(object sender, EventArgs e)
        {
            new formKitapTur().ShowDialog();
        }

        private void btnOgrenciler_Click(object sender, EventArgs e)
        {
            new frmOgrenci().ShowDialog();
        }

        private void btnOduncKitaplar_Click(object sender, EventArgs e)
        {
            new formOduncKitap().ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
