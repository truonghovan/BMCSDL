using Oracle.ManagedDataAccess.Client;
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
    public partial class FormTraThongTin : Form
    {
        public FormTraThongTin()
        {
            InitializeComponent();
        }
        My_DB mydb=new My_DB();
        private void FormTraThongTin_Load(object sender, EventArgs e)
        {
            OracleDataAdapter adapter = new OracleDataAdapter("select CMND,HOTEN,NGAYSINH,GIOITINH,QUOCTICH,DIACHI,PHUONG,QUANHUYEN,TINH,NGAYCAP from truong.Resident", mydb.getConnectionNV());
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridViewPassPort.DataSource = dt;
            mydb.closeConnectionNV();
        }

        private void dataGridViewPassPort_Click(object sender, EventArgs e)
        {
            textBoxCMND.Text = dataGridViewPassPort.CurrentRow.Cells[0].Value.ToString();
            textBoxHoten.Text = dataGridViewPassPort.CurrentRow.Cells[1].Value.ToString();
            
            dateTimeNgaySinh.Value = (DateTime)dataGridViewPassPort.CurrentRow.Cells[2].Value;
            string gender = dataGridViewPassPort.CurrentRow.Cells[3].Value.ToString();
            if (gender == "Nam")
            {
                radioButtonNam.Checked = true;
            }
            else
            {
                radioButtonNu.Checked = true;
            }
            textBoxQuocTich.Text = dataGridViewPassPort.CurrentRow.Cells[4].Value.ToString();
            textBoxDiachi.Text= dataGridViewPassPort.CurrentRow.Cells[5].Value.ToString();
            textBoxPhuongxa.Text = dataGridViewPassPort.CurrentRow.Cells[6].Value.ToString();
            textBoxQuanHuyen.Text = dataGridViewPassPort.CurrentRow.Cells[7].Value.ToString();
            textBoxTinh.Text = dataGridViewPassPort.CurrentRow.Cells[8].Value.ToString();
            dateTimeNgayCap.Value = (DateTime)dataGridViewPassPort.CurrentRow.Cells[9].Value;
        }

        private void buttonTimCMND_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBoxCMND.Text);
            OracleCommand comnand = new OracleCommand("SELECT CMND,HOTEN,NGAYSINH,GIOITINH,QUOCTICH,DIACHI,PHUONG,QUANHUYEN,TINH,NGAYCAP from truong.Resident WHERE CMND = " + id);
            comnand.Connection = mydb.getConnectionNV();
            OracleDataAdapter adapter = new OracleDataAdapter(comnand);
            DataTable table = new DataTable();
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                textBoxCMND.Text = table.Rows[0]["CMND"].ToString();
                textBoxHoten.Text = table.Rows[0]["HOTEN"].ToString();

                dateTimeNgaySinh.Value = (DateTime)table.Rows[0]["NGAYSINH"]; ;
                string gender = table.Rows[0]["GIOITINH"].ToString(); ;
                if (gender == "Nam")
                {
                    radioButtonNam.Checked = true;
                }
                else
                {
                    radioButtonNu.Checked = true;
                }
                textBoxQuocTich.Text = table.Rows[0]["QUOCTICH"].ToString();
                textBoxDiachi.Text = table.Rows[0]["DIACHI"].ToString();
                textBoxPhuongxa.Text = table.Rows[0]["PHUONG"].ToString();
                textBoxQuanHuyen.Text = table.Rows[0]["QUANHUYEN"].ToString();
                textBoxTinh.Text = table.Rows[0]["TINH"].ToString();
                dateTimeNgayCap.Value = (DateTime)table.Rows[0]["NGAYCAP"];
            }
            else
            {
                MessageBox.Show("Số CMND không tồn tại", "Find CMND", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
