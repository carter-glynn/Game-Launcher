using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLauncher {
    public static class UserInfoDb {
        public static SqlConnection Get_DB_Connection() {
            string cn_String = Properties.Settings.Default.connection_string;
            SqlConnection cn_connection = new SqlConnection(cn_String);
            if(cn_connection.State != ConnectionState.Open) cn_connection.Open();
            return cn_connection;
        }

        public static DataTable Get_DataTable(string SQL_Text) {
            SqlConnection cn_connection = Get_DB_Connection();
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(SQL_Text, cn_connection);
            adapter.Fill(table);
            return table;
        }
        public static void Execute_SQL(string SQL_Text) {
            SqlConnection cn_connection = Get_DB_Connection();
            SqlCommand cmd_Command = new SqlCommand(SQL_Text, cn_connection);
            cmd_Command.ExecuteNonQuery();
            Close_DB_Connection();
        }
        public static void Close_DB_Connection() {
            string cn_String = Properties.Settings.Default.connection_string;
            SqlConnection cn_connection = new SqlConnection(cn_String);
            if(cn_connection.State != ConnectionState.Closed) cn_connection.Close();
        }
    }
}
