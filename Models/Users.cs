using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace FYP_API.Models
{
    public class Users
    {
        public int userid { get; set; }
        public string username { get; set; }

        public string password { get; set; }

        public string user_role { get; set; }

        public string inserted_date { get; set; }

        public string email { get; set; }
        public string phone { get; set; }
        public string address { get; set; }


    }
}
