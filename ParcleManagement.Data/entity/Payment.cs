using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ParcleManagement.Data.entity
{
    [Table("Payments")]
    public class Payment
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Parcel))]
        public int ParcelId { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Amount { get; set; }

        [ForeignKey(nameof(PaymentMethod))]
        public int PaymentMethodId { get; set; }

        [Required, MaxLength(50)]
        public string Status { get; set; } = "pending"; // paid / pending / failed

        [ForeignKey(nameof(ProcessedByUser))]
        public int? ProcessedBy { get; set; }

        public DateTime? PaidAt { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        public Parcel Parcel { get; set; } = null!;
        public PaymentMethod PaymentMethod { get; set; } = null!;
        public User? ProcessedByUser { get; set; }
    }

}
