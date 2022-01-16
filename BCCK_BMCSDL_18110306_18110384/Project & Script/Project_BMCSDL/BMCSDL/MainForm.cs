using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMCSDL
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonDangKy_Click(object sender, EventArgs e)
        {
            FormDangKyPP frmdangky=new FormDangKyPP();
            frmdangky.ShowDialog();
        }

        private void buttonNhanVien_Click(object sender, EventArgs e)
        {
            FormDangNhap frmDangNhap=new FormDangNhap();
            frmDangNhap.ShowDialog();
        }
    }
}
