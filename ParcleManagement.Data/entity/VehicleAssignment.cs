using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ParcleManagement.Data.entity
{
    [Table("VehicleAssignments")]
    public class VehicleAssignment
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Vehicle))]
        public int VehicleId { get; set; }

        [ForeignKey(nameof(Driver))]
        public int DriverId { get; set; }

        [MaxLength(50)]
        public string Status { get; set; } = "active";

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        public Vehicle Vehicle { get; set; } = null!;
        public Driver Driver { get; set; } = null!;
    }
}
