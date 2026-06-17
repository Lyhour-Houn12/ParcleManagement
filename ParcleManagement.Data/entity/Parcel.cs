using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ParcleManagement.Data.entity
{
    [Table("Parcels")]
    public class Parcel
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string TrackingNumber { get; set; } = string.Empty;

        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }

        [ForeignKey(nameof(Driver))]
        public int? DriverId { get; set; }

        // FK to Warehouse (current_location)
        [ForeignKey(nameof(CurrentWarehouse))]
        public int? CurrentLocationId { get; set; }

        [ForeignKey(nameof(ServiceType))]
        public int ServiceTypeId { get; set; }

        [Column(TypeName = "decimal(10,3)")]
        public decimal Weight { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal CodAmount { get; set; }

        [MaxLength(50)]
        public string Status { get; set; } = "pending";

        public string? Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        public User Customer { get; set; } = null!;
        public Driver? Driver { get; set; }
        public Warehouse? CurrentWarehouse { get; set; }
        public ServiceType ServiceType { get; set; } = null!;
        public ICollection<ParcelStatusHistory> StatusHistories { get; set; } = new List<ParcelStatusHistory>();
        public ICollection<DeliveryAssignment> DeliveryAssignments { get; set; } = new List<DeliveryAssignment>();
        public ICollection<DeliveryAttempt> DeliveryAttempts { get; set; } = new List<DeliveryAttempt>();
        public ICollection<ParcelTracking> Trackings { get; set; } = new List<ParcelTracking>();
        public Payment? Payment { get; set; }
    }

}
