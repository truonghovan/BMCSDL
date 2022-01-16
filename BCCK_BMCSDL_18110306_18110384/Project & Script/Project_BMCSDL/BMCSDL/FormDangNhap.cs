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
    public partial class FormDangNhap : Form
    {
        public FormDangNhap()
        {
            InitializeComponent();
        }
        My_DB mydb = new My_DB();
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonDangNhap_Click(object sender, EventArgs e)
        {
            OracleDataAdapter adapter = new OracleDataAdapter();
            DataTable table = new DataTable();
            OracleCommand command = new OracleCommand("SELECT * FROM TAIKHOAN WHERE TAIKHOAN=:taikhoan AND MATKHAU =:Pass", mydb.getConnection);
            command.Parameters.Add("taikhoan", OracleDbType.Varchar2).Value = textBoxTK.Text;
            command.Parameters.Add("Pass", OracleDbType.Varchar2).Value = textBoxPW.Text;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {

                int userid = Convert.ToInt16(table.Rows[0][0].ToString());
                GlobalVariables.SetGlobalInt(userid);
                GlobalVariables.setGlobalUserName(textBoxTK.Text);
                GlobalVariables.setGlobalPassword(textBoxPW.Text);
                
                if (Convert.ToInt16(table.Rows[0][3].ToString())==0) // role 0 là xác thực
                {
                    
                    FormXacThuc formXacThuc = new FormXacThuc();
                    formXacThuc.ShowDialog();
                    this.Close();
                }
                else if(Convert.ToInt16(table.Rows[0][3].ToString()) == 1)// role 1 là xét duyệt
                {
                    FormXetDuyet frmXetduyet = new FormXetDuyet();
                    frmXetduyet.ShowDialog();
                    this.Close();
                }
                else if (Convert.ToInt16(table.Rows[0][3].ToString()) == 2)// role 2 là lưu trữ
                {
                    FormLuuTru frmLuuTru = new FormLuuTru();
                    frmLuuTru.ShowDialog();
                    this.Close();
                }
                else
                {
                    FormGS frmGS= new FormGS();
                    frmGS.ShowDialog();
                    this.Close();
                }



            }
            else
            {
                MessageBox.Show("Invalid UserName or PassWord", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
