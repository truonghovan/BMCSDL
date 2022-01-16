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
    public partial class Form1 : Form
    {
        My_DB mydb = new My_DB();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            OracleDataAdapter adapter = new OracleDataAdapter("select * from PASSPORTDATA", mydb.getConnection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            MessageBox.Show("connect ok");
            mydb.closeConnection();
        }
    }
}
