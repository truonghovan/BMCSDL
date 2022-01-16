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
    public partial class FormDangKyPP : Form
    {
        My_DB mydb = new My_DB();
        public FormDangKyPP()
        {
            InitializeComponent();
        }

        private void buttonDangky_Click(object sender, EventArgs e)
        {
            string gender = "Nam";
            if (radioButtonNu.Checked)
            {
                gender = "Nữ";
            }
            mydb.openConnection();
            OracleCommand command = new OracleCommand("INSERT INTO PASSPORTDATA (HOTEN,DIACHI,PHAI,CMND,DIENTHOAI,EMAIL,TTXACTHUC,TTXETDUYET,TTTHONGBAO,NGAYSINH,NGAYCAPCMND)" + "VALUES (:hoten,:diachi,:phai,:cmnd,:dienthoai,:email,:ttxacthuc,:ttxetduyet,:ttthongbao,:ngaysinh,:ngaycapcmnd)", mydb.getConnection);
            command.Parameters.Add("hoten", OracleDbType.NVarchar2,50).Value = textBoxHoten.Text;
            command.Parameters.Add("diachi", OracleDbType.NVarchar2,200).Value = textBoxDiachi.Text;
            command.Parameters.Add("phai", OracleDbType.NVarchar2,20).Value = gender;
            command.Parameters.Add("cmnd", OracleDbType.NVarchar2,15).Value = textBoxCMND.Text;
            command.Parameters.Add("dienthoai", OracleDbType.NVarchar2,20).Value = textBoxDienthoai.Text;
            command.Parameters.Add("email", OracleDbType.NVarchar2,30).Value = textBoxEmail.Text;
            command.Parameters.Add("ttxacthuc", OracleDbType.NVarchar2, 30).Value = "Chưa duyệt";
            command.Parameters.Add("ttxetduyet", OracleDbType.NVarchar2, 30).Value = "Chưa duyệt";
            command.Parameters.Add("ttthongbao", OracleDbType.NVarchar2, 30).Value = "Chưa thông báo";
            command.Parameters.Add("ngaysinh",OracleDbType.Date).Value=dateTimeNgaySinh.Value;
            command.Parameters.Add(":ngaycapcmnd", OracleDbType.Date).Value = dateTimeNgayCap.Value;
            command.Connection = mydb.getConnection;
            command.CommandType=CommandType.Text;

            if ((command.ExecuteNonQuery() == 1))
            {
                mydb.closeConnection();
                MessageBox.Show("Thông tin của bạn đã được gửi, vui lòng chờ phản hồi sau 5 - 7 ngày", "Đăng ký cung cấp PassPort", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
               
            }
            else
            {
                mydb.closeConnection();

            }
            

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
