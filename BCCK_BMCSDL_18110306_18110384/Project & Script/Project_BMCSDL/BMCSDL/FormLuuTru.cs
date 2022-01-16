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
    public partial class FormLuuTru : Form
    {
        public FormLuuTru()
        {
            InitializeComponent();
        }
        My_DB mydb=new My_DB();
        private void FormLuuTru_Load(object sender, EventArgs e)
        {
            OracleDataAdapter adapter = new OracleDataAdapter("select id, TTXACTHUC, TTXETDUYET from truong.PASSPORTDATA where TTXACTHUC='Đã xác thực' and TTXETDUYET!='Chưa duyệt' and TTTHONGBAO!='Đã thông báo'", mydb.getConnectionNV());
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridViewPassPort.DataSource = dt;
            mydb.closeConnectionNV();
            if (textBoxHoten.Text == "")
            {
                buttonGuiTT.Enabled = false;
               
            }
            dataGridViewPassPort.Columns[0].HeaderText = "Mã hồ sơ";
            dataGridViewPassPort.Columns[1].HeaderText = "Tình trạng xác thực";
            dataGridViewPassPort.Columns[2].HeaderText = "Tình trạng xét duyệt";

            //Ten NV
            DataTable table = new DataTable();
            OracleCommand command = new OracleCommand("SELECT * FROM TAIKHOAN WHERE id=:id", mydb.getConnection);
            command.Parameters.Add("id", OracleDbType.Int32).Value = GlobalVariables.GlobalUserID;
            OracleDataAdapter adaptertenNV = new OracleDataAdapter(command);
            adaptertenNV.Fill(table);
            if (table.Rows.Count > 0)
            {

                labelTenNV.Text = "Xin chào " + table.Rows[0]["HOTEN"].ToString().Trim() + "";
            }

        }

        private void dataGridViewPassPort_Click(object sender, EventArgs e)
        {
            textBoxHoten.Text = dataGridViewPassPort.CurrentRow.Cells[0].Value.ToString();
            buttonGuiTT.Enabled = true;
            
        }

        private void buttonGuiTT_Click(object sender, EventArgs e)
        {
            OracleCommand command = new OracleCommand("update truong.PASSPORTDATA set TTTHONGBAO = :xacthuc,IDUSERTT=:iduser where ID=:id", mydb.getConnectionNV());
            command.Parameters.Add("xacthuc", OracleDbType.NVarchar2, 50).Value = "Đã thông báo";
            command.Parameters.Add("iduser", OracleDbType.NVarchar2, 50).Value = GlobalVariables.GlobalUserID.ToString();
            command.Parameters.Add("id",OracleDbType.Int32).Value=Int32.Parse(textBoxHoten.Text);
            mydb.openConnectionNV();
            if ((command.ExecuteNonQuery() == 1))
            {
                mydb.closeConnectionNV();
                MessageBox.Show("Gửi thông báo thành công", "Thông báo được duyệt PASSPORT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.FormLuuTru_Load(sender, e);
                dataGridViewPassPort.Update();
                dataGridViewPassPort.Refresh();

            }
            else
            {
                mydb.closeConnectionNV();

            }
        }
    }
}
