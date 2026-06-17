using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ParcleManagement.Data.entity
{
    [Table("ParcelTrackings")]
    public class ParcelTracking
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Parcel))]
        public int ParcelId { get; set; }

        [ForeignKey(nameof(Driver))]
        public int DriverId { get; set; }

        [Column(TypeName = "decimal(10,7)")]
        public decimal Latitude { get; set; }

        [Column(TypeName = "decimal(10,7)")]
        public decimal Longitude { get; set; }

        [MaxLength(255)]
        public string? Location { get; set; }

        public DateTime RecordedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        public Parcel Parcel { get; set; } = null!;
        public Driver Driver { get; set; } = null!;
    }

}
