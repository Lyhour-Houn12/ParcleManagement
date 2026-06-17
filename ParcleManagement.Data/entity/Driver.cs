using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParcleManagement.Data.entity
{
    [Table("Drivers")]
    public class Driver
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(150)]
        public string Name { get; set; } = string.Empty;

        public string? Destination { get; set; }

        [MaxLength(50)]
        public string? LicenseNumber { get; set; }

        [MaxLength(50)]
        public string? NationalId { get; set; }

        public int? ExperienceYear { get; set; }

        public DateTime? HireDate { get; set; }

        [MaxLength(50)]
        public string Status { get; set; } = "active";

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        public ICollection<Parcel> Parcels { get; set; } = new List<Parcel>();
        public ICollection<DeliveryAssignment> DeliveryAssignments { get; set; } = new List<DeliveryAssignment>();
        public ICollection<DeliveryAttempt> DeliveryAttempts { get; set; } = new List<DeliveryAttempt>();
        public ICollection<ParcelTracking> ParcelTrackings { get; set; } = new List<ParcelTracking>();
        public ICollection<VehicleAssignment> VehicleAssignments { get; set; } = new List<VehicleAssignment>();
    }

}
