using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ParcleManagement.Data.entity
{
    [Table("VehicleTypes")]
    public class VehicleType
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string? TypesAs { get; set; }

        // Navigation
        public ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
    }
}
