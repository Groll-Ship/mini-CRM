using System;
using System.Collections.Generic;
using System.Text;

namespace Data_MINI_CRM_.DatabaseConnection
{
    public class Connection
    {
        public string _server { get; set; }
        public string _dataBase { get; set; }
        public string _userId { get; set; }
        public string _password { get; set; }
        public string _connectTimeout { get; set; }
        public string _encrypt { get; set; }
        public string _trustServerCertificate { get; set; }
        public string _applicationIntent { get; set; }
        public string _multiSubnetFailover { get; set; }
        private string StringConnection { get; set; }
        public string SetString()
        {
            StringConnection = $"Data Source={_server};" +
                $"Initial Catalog={_dataBase};" +
                $"User ID={_userId};" +
                $"Password={_password};" +
                $"Connect Timeout={_connectTimeout};" +
                $"Encrypt={_encrypt};" +
                $"TrustServerCertificate={_trustServerCertificate};" +
                $"ApplicationIntent={_applicationIntent};" +
                $"MultiSubnetFailover={_multiSubnetFailover}";
            return StringConnection;
        }
    }
}
