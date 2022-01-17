using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace DevelopmentExercise.API.Models
{
    public class Invoice
    {
        public Invoice()
        {
            Created = DateTime.Now;
        }

        // Concretes

        [Key]
        [NotNull]
        [Required]
        public int ID { get; set; }

        [NotNull]
        [Required]
        [DataType(DataType.Text)]
        [StringLength(8, MinimumLength = 8)]
        public string InvoiceNumber { get; set; } = null!;

        [NotNull]
        [Required]
        [ForeignKey(nameof(Order))]
        public int OrderID { get; set; }

        [NotNull]
        [Required]
        [Column(TypeName = "decimal(19, 2)")]
        public decimal InvoiceTotalPrice { get; set; }

        [NotNull]
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Created { get; set; }


        // Foreigns

        public Order Order { get; set; } = null!;
    }
}