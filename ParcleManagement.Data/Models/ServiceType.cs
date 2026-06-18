using System;
using System.Collections.Generic;

namespace ParcleManagement.Data.Models
{
    public class ServiceType
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string code { get; set; }          // e.g. "standard", "express", "overnight"
        public string description { get; set; }
        public decimal base_rate_per_kg { get; set; }  // price per kg
        public decimal minimum_charge { get; set; }     // minimum fee
        public decimal volumetric_divisor { get; set; } // default 5000
        public bool is_active { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }

        // Navigation
        public List<Parcel> Parcels { get; set; }
    }
}