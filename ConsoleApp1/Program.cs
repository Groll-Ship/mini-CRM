using Data_MINI_CRM_.DatabaseConnection;
using Data_MINI_CRM_.DataModels;
using Data_MINI_CRM_.Storage;
using Statuses.ModelStatus;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Mini_CRM
{
    class Program
    {
        static void Main(string[] args)
        {
            Connection connection = new Connection()
            {
                _server = @"DESKTOP-RH8CH3N",
                _dataBase = @"CRM",
                _userId = @"admin",
                _password = @"123456",
                _connectTimeout = @"30",
                _encrypt = @"False",
                _trustServerCertificate = @"False",
                _applicationIntent = @"ReadWrite",
                _multiSubnetFailover = @"False"
            };
            Connect connect = Connect.GetConnect(connection.SetString());
            Task<SqlConnection> sql = connect.ConnectionOpen();
            Console.WriteLine(sql.Result.State);
            UserStorage storage = new UserStorage(sql.Result);
            UserDataModel model = new UserDataModel()
            {
                Id = 21,
                Login = "TestUpdate_1",
                Password = "123QWE",
                Role = "Admin",
                UserId = 1
            };
            ModelStatusUpdate status = storage.UpdateUser(model);


           //ModelStatusDelete status = storage.DeleteUser(2);
            //List<IDataModels> models = storage.GetUsers();
            //foreach (UserDataModel item in models)
            //{
            //    Console.WriteLine(item.Id + item.Login + item.Role + item.UserId + item.Password);
            //}

            Console.WriteLine(status.IdModel.ToString() + " " + status.Status + " " + status.Description);
            //Console.WriteLine(status.Status);
            connect.ConnectionClose(sql.Result);
        }

        
    }
}
