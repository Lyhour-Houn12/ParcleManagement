using System;
using System.Collections.Generic;
using System.Text;

namespace ParcleManagement.Data.Models
{
    public class DeliveryAssignment
    {
        public int ID { get; set; }
        public int parcel_id { get; set; }
        public int user_id { get; set; }
        public int assigned_by { get; set; }
        public DateTime assigned_at { get; set; }
        public DeliveryAssignmentStatus status { get; set; }
    }

    public enum DeliveryAssignmentStatus
    {
        Assigned = 0,
        Accepted = 1,
        Completed = 2,
        Cancelled = 3
    }
}
