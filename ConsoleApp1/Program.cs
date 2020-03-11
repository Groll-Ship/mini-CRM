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
            Connect connect = new Connect() { String = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CRM;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False" };
            Task<SqlConnection> sql = connect.ConnectionOpen(connect.String);
            Console.WriteLine(sql.Result.State);
            Console.WriteLine(GetUser(sql.Result)); 
            connect.ConnectionClose(sql.Result);
        }

        
    }
}
