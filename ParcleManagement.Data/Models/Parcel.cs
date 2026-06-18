using System;

namespace ParcleManagement.Data.Models
{
    public class Parcel
    {
        public int ID { get; set; }
        public string tracking_id { get; set; }
        public string sender_name { get; set; }
        public string sender_phone { get; set; }
        public string sender_address { get; set; }
        public string recipient_name { get; set; }
        public string recipient_phone { get; set; }
        public string destination { get; set; }
        public double weight { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public int length { get; set; }
        public double volumetric_weight { get; set; }
        public double chargeable_weight { get; set; }
        public decimal price { get; set; }
        public string status { get; set; }         // pending, in_transit, delivered, failed
        public string notes { get; set; }
        public int service_type_id { get; set; }
        public int? driver_id { get; set; }
        public int? warehouse_id { get; set; }
        public int created_by { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }

        // Navigation
        public ServiceType ServiceType { get; set; }
        public User CreatedBy { get; set; }
    }
}