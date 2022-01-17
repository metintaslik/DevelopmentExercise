using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace DevelopmentExercise.API.Models
{
    public class Order
    {
        // Concretes

        [Key]
        [NotNull]
        [Required]
        public int ID { get; set; }

        [NotNull]
        [Required]
        [DataType(DataType.Text)]
        [StringLength(8, MinimumLength = 8)]
        public string OrderNumber { get; set; } = null!;

        [NotNull]
        [Required]
        [ForeignKey(nameof(User))]
        public int UserID { get; set; }

        [NotNull]
        [Required]
        public int QuantityCount { get; set; }

        [NotNull]
        [Required]
        [Column(TypeName = "decimal(19, 2)")]
        public decimal OrderCost { get; set; }

        [NotNull]
        [Required]
        [Column(TypeName = "decimal(19, 2)")]
        public decimal DiscountCost { get; set; } = 0.00m;

        [NotNull]
        [Required]
        [Column(TypeName = "decimal(19, 2)")]
        public decimal TotalCost { get; set; }

        [NotNull]
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Created { get; set; }

        //Foreigns

        public virtual User User { get; set; } = null!;
    }
}