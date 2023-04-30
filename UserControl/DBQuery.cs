using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WpfFramePasCore.UserControl
{
    class DBQuery : IDisposable //IDisposable for the "using" instruction which allows to use multiple DBQueries 
    {
        private string server = "localhost";
        private string database = "cookies";
        private string user = "root";
        private string password = "ABCD1234";
        //string port = "3306";
        MySqlConnection conn;


        public DBQuery()
        {        
            string connectionString = $"server={server};uid={user};pwd={password};database={database};";
            conn = new MySqlConnection(connectionString);
            conn.Open();

        }

        public MySqlDataReader ExecuteQuery(string command)
        {
            MySqlCommand cmd = new MySqlCommand(command, conn);
            return cmd.ExecuteReader();
        }
        public void Dispose() => conn.Close();
    }
}
