using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Data_MINI_CRM_.sp.Get
{
    public class sp_Users
    {
        private static string GetUser(SqlConnection connection)
        {
            string sqlExpression = "sp_GetUsers";
            string result = "";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            var reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string login = reader.GetString(1);
                    string role = reader.GetString(2);
                    result += id + login + role;
                }
            }
            return result;
        }
    }
}
