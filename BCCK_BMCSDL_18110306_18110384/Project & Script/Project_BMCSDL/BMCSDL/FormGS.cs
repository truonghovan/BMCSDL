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
    public partial class FormGS : Form
    {
        public FormGS()
        {
            InitializeComponent();
        }
        My_DB mydb = new My_DB();
        private void FormGS_Load(object sender, EventArgs e)
        {
            // datagrid bộ phận xác thực
            OracleDataAdapter adapter = new OracleDataAdapter("select IDUSERXT,ID from truong.PASSPORTDATA where TTXACTHUC='Đã xác thực'", mydb.getConnectionNV());
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            
            dataGridViewXT.DataSource = dt;
            try
            {
                if(dt.Rows.Count > 0)
                {
                    for (int i = 1; i <= dt.Rows.Count; i++)
                    {
                        int id = Convert.ToInt16(dt.Rows[i-1][0].ToString());
                       
                        OracleCommand comnand = new OracleCommand("SELECT * from TAIKHOAN WHERE id =:id", mydb.getConnection);
                        comnand.Parameters.Add("id", OracleDbType.Int32).Value = id;
                        
                        OracleDataAdapter adapter2 = new OracleDataAdapter(comnand);
                        DataTable table = new DataTable();
                        adapter2.Fill(table);
                        dataGridViewXT.Rows[i-1].Cells[0].Value = table.Rows[0]["HOTEN"].ToString();
                        mydb.closeConnection();
                     
                    }
                    
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
             
            }
            mydb.closeConnection();
            dataGridViewXT.Columns[0].HeaderText = "Nhân viên";
            dataGridViewXT.Columns[1].HeaderText = "Mã hồ sơ";


            // datagrid bộ phận xét duyệt
            OracleDataAdapter adapterXD = new OracleDataAdapter("select IDUSERXD,ID from truong.PASSPORTDATA where TTXETDUYET!='Chưa duyệt'", mydb.getConnectionNV());
            DataTable dtXD = new DataTable();
            adapterXD.Fill(dtXD);

            dataGridViewXD.DataSource = dtXD;
            try
            {
                if (dtXD.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtXD.Rows.Count; i++)
                    {
                        int id = Convert.ToInt16(dtXD.Rows[i - 1][0].ToString());
                       
                        OracleCommand comnand = new OracleCommand("SELECT * from TAIKHOAN WHERE id =:id", mydb.getConnection);
                        comnand.Parameters.Add("id", OracleDbType.Int32).Value = id;

                        OracleDataAdapter adapterXD2 = new OracleDataAdapter(comnand);
                        DataTable tableXD = new DataTable();
                        adapterXD2.Fill(tableXD);
                        dataGridViewXD.Rows[i - 1].Cells[0].Value = tableXD.Rows[0]["HOTEN"].ToString();
                        mydb.closeConnection();

                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            mydb.closeConnection();
            dataGridViewXD.Columns[0].HeaderText = "Nhân viên";
            dataGridViewXD.Columns[1].HeaderText = "Mã hồ sơ";

            // datagrid lưu trữ


            OracleDataAdapter adapterLT = new OracleDataAdapter("select IDUSERTT,ID from truong.PASSPORTDATA where TTThongBao='Đã thông báo'", mydb.getConnectionNV());
            DataTable dtLT = new DataTable();
            adapterLT.Fill(dtLT);

            dataGridViewLT.DataSource = dtLT;
            try
            {
                if (dtLT.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtLT.Rows.Count; i++)
                    {
                        int id = Convert.ToInt16(dtLT.Rows[i - 1][0].ToString());
                        
                        OracleCommand comnand = new OracleCommand("SELECT * from TAIKHOAN WHERE id =:id", mydb.getConnection);
                        comnand.Parameters.Add("id", OracleDbType.Int32).Value = id;

                        OracleDataAdapter adapterLT2 = new OracleDataAdapter(comnand);
                        DataTable tableLT2 = new DataTable();
                        adapterLT2.Fill(tableLT2);
                        dataGridViewLT.Rows[i - 1].Cells[0].Value = tableLT2.Rows[0]["HOTEN"].ToString();
                        mydb.closeConnection();

                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            mydb.closeConnection();
            dataGridViewLT.Columns[0].HeaderText = "Nhân viên";
            dataGridViewLT.Columns[1].HeaderText = "Mã hồ sơ";

            //Tên NV
            DataTable tableTENNV = new DataTable();
            OracleCommand commandTenNV = new OracleCommand("SELECT * FROM TAIKHOAN WHERE id=:id", mydb.getConnection);
            commandTenNV.Parameters.Add("id", OracleDbType.Int32).Value = GlobalVariables.GlobalUserID;
            OracleDataAdapter adaptertenNV = new OracleDataAdapter(commandTenNV);
            adaptertenNV.Fill(tableTENNV);
            if (tableTENNV.Rows.Count > 0)
            {

                labelTenNV.Text = "Xin chào " + tableTENNV.Rows[0]["HOTEN"].ToString().Trim() + "";
            }
        }

        private void dataGridViewXT_DoubleClick(object sender, EventArgs e)
        {
            int id = Int32.Parse(dataGridViewXT.CurrentRow.Cells[1].Value.ToString());
            FormThongTinPassPort frmTTPP= new FormThongTinPassPort();
            OracleCommand command = new OracleCommand("select HOTEN,NGAYSINH,DIACHI,PHAI,CMND,NGAYCAPCMND,DIENTHOAI,EMAIL,TTXACTHUC,TTXETDUYET,TTTHONGBAO from truong.PASSPORTDATA where id=:id", mydb.getConnectionNV());
            command.Parameters.Add("id", OracleDbType.Int32, 50).Value = id;
            
            OracleDataAdapter adapterLT2 = new OracleDataAdapter(command);
            DataTable tableLT2 = new DataTable();
            adapterLT2.Fill(tableLT2);
            

            frmTTPP.dataGridViewPP.DataSource = tableLT2;
            frmTTPP.ShowDialog();
        }

        private void dataGridViewXD_DoubleClick(object sender, EventArgs e)
        {
            int id = Int32.Parse(dataGridViewXD.CurrentRow.Cells[1].Value.ToString());
            FormThongTinPassPort frmTTPP = new FormThongTinPassPort();
            OracleCommand command = new OracleCommand("select HOTEN,NGAYSINH,DIACHI,PHAI,CMND,NGAYCAPCMND,DIENTHOAI,EMAIL,TTXACTHUC,TTXETDUYET,TTTHONGBAO from PASSPORTDATA where id=:id", mydb.getConnection);
            command.Parameters.Add("id", OracleDbType.Int32, 50).Value = id;

            OracleDataAdapter adapterLT2 = new OracleDataAdapter(command);
            DataTable tableLT2 = new DataTable();
            adapterLT2.Fill(tableLT2);


            frmTTPP.dataGridViewPP.DataSource = tableLT2;
            frmTTPP.ShowDialog();
        }

        private void dataGridViewLT_DoubleClick(object sender, EventArgs e)
        {
            int id = Int32.Parse(dataGridViewLT.CurrentRow.Cells[1].Value.ToString());
            FormThongTinPassPort frmTTPP = new FormThongTinPassPort();
            OracleCommand command = new OracleCommand("select HOTEN,NGAYSINH,DIACHI,PHAI,CMND,NGAYCAPCMND,DIENTHOAI,EMAIL,TTXACTHUC,TTXETDUYET,TTTHONGBAO from truong.PASSPORTDATA where id=:id", mydb.getConnection);
            command.Parameters.Add("id", OracleDbType.Int32, 50).Value = id;

            OracleDataAdapter adapterLT2 = new OracleDataAdapter(command);
            DataTable tableLT2 = new DataTable();
            adapterLT2.Fill(tableLT2);


            frmTTPP.dataGridViewPP.DataSource = tableLT2;
            frmTTPP.ShowDialog();
        }
    }
}
