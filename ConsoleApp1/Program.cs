using Data_MINI_CRM_.DatabaseConnection;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Connection connection = new Connection() { String = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CRM;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False" };
            Connect connect = new Connect();
            Task<SqlConnection> sql = connect.ConnectionOpen(connection.String);
            Console.WriteLine(sql.Result.State);
            connect.ConnectionClose(sql.Result);
        }
    }
}
