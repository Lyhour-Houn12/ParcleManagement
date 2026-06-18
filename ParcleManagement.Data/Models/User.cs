using System;
using System.Collections.Generic;
using System.Text;

namespace ParcleManagement.Data.Models
{
    public class User
    {
        public int ID { get; set; }
        public string full_name { get; set; }
        public GStatus gender { get; set; }
        public string email { get; set; } 
        public string phone_number { get; set; }
        public string password { get; set; }
        public DateTime hire_date { get; set; }
        public int manager_id { get; set; }
        public  string status { get; set; }
        public string address { get; set; }
        public DateTime last_login { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }

        public List<UserRole> UserRoles { get; set; }

    }

    public enum GStatus
    {
        MALE = 0,
        FEMALE = 1,
        OTHER = 2,
    }
}
