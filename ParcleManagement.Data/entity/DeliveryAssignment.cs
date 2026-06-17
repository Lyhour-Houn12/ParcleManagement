using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParcleManagement.Data.entity
{
    [Table("DeliveryAssignments")]
    public class DeliveryAssignment
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Parcel))]
        public int ParcelId { get; set; }

        [ForeignKey(nameof(Driver))]
        public int DriverId { get; set; }

        [ForeignKey(nameof(AssignedByUser))]
        public int AssignedBy { get; set; }

        public DateTime AssignedAt { get; set; } = DateTime.UtcNow;

        [Required, MaxLength(50)]
        public string Status { get; set; } = "assigned"; // assigned / accepted / completed / cancelled

        // Navigation
        public Parcel Parcel { get; set; } = null!;
        public Driver Driver { get; set; } = null!;
        public User AssignedByUser { get; set; } = null!;
    }
}
