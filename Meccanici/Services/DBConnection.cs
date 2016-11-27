using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Meccanici.Services
{
    public class DBConnection
    {
        public static DBConnection instance;

        private MySqlConnection connection;

        public DBConnection()
        {
            instance = this;
        }

        public void Connect()
        {
            string StringaConnessione = "Server=127.0.0.1;Database=mydb;Uid=root;Password=root;";
            connection = new MySqlConnection(StringaConnessione);
            connection.Open();
        }

        public MySqlDataReader ExecuteQuery(string query)
        {
            MySqlCommand command = new MySqlCommand(query, connection);
            return command.ExecuteReader();
        }

        public void Close()
        {
            connection.Close();
        }
    }
}
