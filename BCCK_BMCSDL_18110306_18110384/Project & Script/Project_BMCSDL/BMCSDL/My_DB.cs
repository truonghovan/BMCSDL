using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMCSDL
{
    public class My_DB
    {
        
        public OracleConnection getConnection
        {
            get
            {
                String x = "Data Source=(DESCRIPTION =" + "(ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))" + "(CONNECT_DATA =" + "(SERVER = DEDICATED)" + "(SERVICE_NAME = ORCLPDB.mshome.net)));" + "User Id=truong;Password=truong;";
                OracleConnection conn = new OracleConnection(x);
                conn.Open();
                return conn;
            }
        }
        public OracleConnection getConnectionNV()
        {
            String x = "Data Source=(DESCRIPTION =" + "(ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))" + "(CONNECT_DATA =" + "(SERVER = DEDICATED)" + "(SERVICE_NAME = ORCLPDB.mshome.net)));" + "User Id="+GlobalVariables.GlobalUserName+";Password="+GlobalVariables.GlobalPassword+";";
            OracleConnection conn = new OracleConnection(x);
            conn.Open();
          
           
                return conn;
         
        }
        public void openConnectionNV()
        {
            String x = "Data Source=(DESCRIPTION =" + "(ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))" + "(CONNECT_DATA =" + "(SERVER = DEDICATED)" + "(SERVICE_NAME = ORCLPDB.mshome.net)));" + "User Id=" + GlobalVariables.GlobalUserName + ";Password=" + GlobalVariables.GlobalPassword + ";";
            OracleConnection conn = new OracleConnection(x);

            conn.Open();

        }

        public void closeConnectionNV()
        {
            String x = "Data Source=(DESCRIPTION =" + "(ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))" + "(CONNECT_DATA =" + "(SERVER = DEDICATED)" + "(SERVICE_NAME = ORCLPDB.mshome.net)));" + "User Id=" + GlobalVariables.GlobalUserName + ";Password=" + GlobalVariables.GlobalPassword + ";";
            OracleConnection conn = new OracleConnection(x);


            conn.Close();
            conn.Dispose();

        }
        public void openConnection()
        {
            String x = "Data Source=(DESCRIPTION =" + "(ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))" + "(CONNECT_DATA =" + "(SERVER = DEDICATED)" + "(SERVICE_NAME = ORCLPDB.mshome.net)));" + "User Id=truong;Password=truong;";
            OracleConnection conn = new OracleConnection(x);
            
                conn.Open();
            
        }
        public void closeConnection()
        {
            String x = "Data Source=(DESCRIPTION =" + "(ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))" + "(CONNECT_DATA =" + "(SERVER = DEDICATED)" + "(SERVICE_NAME = ORCLPDB.mshome.net)));" + "User Id=truong;Password=truong;";
            OracleConnection conn = new OracleConnection(x);
           
            
                conn.Close();
                conn.Dispose();
            
        }
    }
}
