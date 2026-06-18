using System;
using System.Collections.Generic;
using System.Text;

namespace ParcleManagement.Data.Models
{
    public class Manager
    {
        public int ID { get; set; }
        public string full_name { get; set; }
        public GStatus gender { get; set; }
        public string bio { get; set; }
        public string email { get; set; }
        public string phone_number { get; set; }
        public DateTime hire_date { get; set; }
        public DateTime last_login { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }

    //public enum GStatus
    //{
    //    MALE = 0,
    //    FEMALE = 1,
    //    OTHER = 2,
    //}
}
