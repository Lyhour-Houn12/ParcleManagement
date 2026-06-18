using System;
using System.Collections.Generic;
using System.Text;

namespace ParcleManagement.Data.Models
{
    public class RoleType
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public double salary { get; set; }
        public int manager_id { get; set; } = 0;
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }

        public List<UserRole> UserRoles { get; set; }
    }
}
