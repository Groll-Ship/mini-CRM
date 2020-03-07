using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Data_MINI_CRM_.DatabaseConnection
{
    public class Connect
    {
        public async Task<SqlConnection> ConnectionOpen(string connectionString)
        {
            SqlConnection connection = new SqlConnection(connectionString);
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
