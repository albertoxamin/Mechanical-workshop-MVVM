using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Meccanici.DAL
{
    public class DBConnection
    {
        public static DBConnection instance;

        private MySqlConnection connection;

        private const string DB_NAME = "officina";
        private const string SERVER_IP = "127.0.0.1";
        private const string DB_USER = "root";
        private const string DB_PASSWORD = "";

        public DBConnection()
        {
            instance = this;
        }

        public void Connect()
        {
            if (connection == null)
            {
                string StringaConnessione =
                    "Server=" + SERVER_IP +
                    ";Database=" + DB_NAME +
                    ";Uid=" + DB_USER +
                    ";Password=" + DB_PASSWORD + ";";
                connection = new MySqlConnection(StringaConnessione);
            }
            else
                connection.Close();
            connection.Open();
        }

        public async Task<DbDataReader> ExecuteQuery(string query)
        {
            Connect();
            MySqlCommand command = new MySqlCommand(query, connection);
            return await command.ExecuteReaderAsync();
        }

        public async void InsertInto(string table, string names, string values)
        {
            string query = string.Format("insert into {0}.{1}({2}) values ({3})", DB_NAME, table, names, values);
            await ExecuteQuery(query);
        }

        public void Close()
        {
            connection.Close();
        }
    }
}
