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
    public partial class FormThongTinPassPort : Form
    {
        public FormThongTinPassPort()
        {
            InitializeComponent();
          
            
        }

        private void FormThongTinPassPort_Load(object sender, EventArgs e)
        {
            dataGridViewPP.Columns[0].HeaderText = "Họ Tên";
            dataGridViewPP.Columns[1].HeaderText = "Ngày sinh";
            dataGridViewPP.Columns[2].HeaderText = "Địa chỉ";
            dataGridViewPP.Columns[3].HeaderText = "Giới tính";
            dataGridViewPP.Columns[4].HeaderText = "CMND";
            dataGridViewPP.Columns[5].HeaderText = "Ngày cấp";
            dataGridViewPP.Columns[6].HeaderText = "Điện thoại";
            dataGridViewPP.Columns[7].HeaderText = "Email";
            dataGridViewPP.Columns[8].HeaderText = "Tình trạng xác thực";
            dataGridViewPP.Columns[9].HeaderText = "Tình trạng xét duyệt";
            dataGridViewPP.Columns[10].HeaderText = "Tình trạng thông báo";
        }
    }
}
