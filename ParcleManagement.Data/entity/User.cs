using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ParcleManagement.Data.entity
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(150)]
        public string FullName { get; set; } = string.Empty;

        [Required, MaxLength(200)]
        public string Email { get; set; } = string.Empty;

        [MaxLength(20)]
        public string? Phone { get; set; }

        [Required]
        public string Password { get; set; } = string.Empty;

        [ForeignKey(nameof(RoleType))]
        public int RoleTypeId { get; set; }

        [MaxLength(50)]
        public string Status { get; set; } = "active";

        public string? Address { get; set; }

        public DateTime? HiredAt { get; set; }

        public string? Work { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        public RoleType RoleType { get; set; } = null!;
        public UserDetail? UserDetail { get; set; }
        public ICollection<Parcel> CustomerParcels { get; set; } = new List<Parcel>();
        public ICollection<ParcelStatusHistory> UpdatedStatusHistories { get; set; } = new List<ParcelStatusHistory>();
        public ICollection<Payment> ProcessedPayments { get; set; } = new List<Payment>();
        public ICollection<DeliveryAssignment> AssignedByAssignments { get; set; } = new List<DeliveryAssignment>();
    }

}
