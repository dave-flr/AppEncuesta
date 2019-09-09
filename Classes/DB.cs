using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace DXApplication1.Classes
{
    public class DB
    {
        private DB()
        {
        }

        private string databaseName = string.Empty;
        private string serverName = string.Empty;
        private string userName = string.Empty;
        private string password = string.Empty;

        public string DatabaseName
        {
            get { return databaseName; }
            set { databaseName = value; }
        }

        public string Password { get; set; }
        private MySqlConnection connection = null;
        public MySqlConnection Connection
        {
            get { return connection; }
        }

        public string ServerName { get => serverName; set => serverName = value; }
        public string UserName { get => userName; set => userName = value; }
        public string Password1 { get => password; set => password = value; }

        private static DB _instance = null;
        public static DB Instance()
        {
            if (_instance == null)
                _instance = new DB();
            return _instance;
        }

        public bool IsConnect()
        {
            try
            {
                if (Connection == null)
                {
                    if (String.IsNullOrEmpty(databaseName) || String.IsNullOrEmpty(serverName) || String.IsNullOrEmpty(userName) || String.IsNullOrEmpty(password))
                        return false;
                    string connstring = string.Format("Server={0}; database={1}; UID={2}; password={3}", serverName, databaseName, userName, password);
                    connection = new MySqlConnection(connstring);
                    connection.Open();
                }

                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "Hay un error con la base de datos", MessageBoxButtons.OK , MessageBoxIcon.Exclamation);
                connection.Close();
                connection.Dispose();
                connection = null;
                return false;
            }
            
        }

        public void Close()
        {
            connection.Close();
        }
    }
}
