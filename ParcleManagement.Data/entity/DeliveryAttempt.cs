using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParcleManagement.Data.entity
{
    [Table("DeliveryAttempts")]
    public class DeliveryAttempt
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Parcel))]
        public int ParcelId { get; set; }

        [ForeignKey(nameof(Driver))]
        public int DriverId { get; set; }

        public int AttemptNo { get; set; }

        public DateTime AttemptTime { get; set; } = DateTime.UtcNow;

        [Required, MaxLength(50)]
        public string Status { get; set; } = string.Empty; // failed / success

        public string? Reason { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        public Parcel Parcel { get; set; } = null!;
        public Driver Driver { get; set; } = null!;
    }
}
