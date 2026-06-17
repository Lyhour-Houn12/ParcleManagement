using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ParcleManagement.Data.entity
{
    [Table("ParcelStatusHistories")]
    public class ParcelStatusHistory
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Parcel))]
        public int ParcelId { get; set; }

        [Required, MaxLength(50)]
        public string Status { get; set; } = string.Empty;

        public string? Description { get; set; }

        [ForeignKey(nameof(UpdatedByUser))]
        public int UpdatedBy { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        public Parcel Parcel { get; set; } = null!;
        public User UpdatedByUser { get; set; } = null!;
    }

}
