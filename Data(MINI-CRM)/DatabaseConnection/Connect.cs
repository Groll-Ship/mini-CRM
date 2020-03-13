using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Data_MINI_CRM_.DatabaseConnection
{
    public class Connect
    {
        private static string StringConnection;
        private static Connect connect = null;
        private Connect()
        {
        }
        public static Connect GetConnect(string _stringConnection)
        {
            if (connect == null)
            {
                connect = new Connect();
                StringConnection = _stringConnection;
            }
            else
                return connect;
            return connect;
        }

        public async Task<SqlConnection> ConnectionOpen()
        {

            SqlConnection connection = new SqlConnection(StringConnection);
            try
            {
                await connection.OpenAsync();
                return connection;
            }
            catch
            {
                return null;
            }
        }
        public bool ConnectionClose(SqlConnection connection)
        {
            try
            {
                connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
