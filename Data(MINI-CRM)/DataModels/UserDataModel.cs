using System;
using System.Collections.Generic;
using System.Text;

namespace Data_MINI_CRM_.DataModels
{
    public class UserDataModel : IDataModels
    {
        public int Id { get; set; }
        public string Login { get; set; } 
        public string Role { get; set; }
    }
}
