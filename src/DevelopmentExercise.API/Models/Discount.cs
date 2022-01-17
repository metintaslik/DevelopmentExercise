using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace DevelopmentExercise.API.Models
{
    public class Discount
    {
        // Concretes

        [Key]
        [NotNull]
        [Required]
        public int ID { get; set; }

        [NotNull]
        [Required]
        [DataType(DataType.Text)]
        [StringLength(25, MinimumLength = 5)]
        public string DiscountDescription { get; set; } = null!;

        [AllowNull]
        public int? RoleID { get; set; }

        [NotNull]
        [Required]
        [Column(TypeName = "decimal(19, 2)")]
        public decimal Value { get; set; }

        [NotNull]
        [Required]
        public bool Percentage { get; set; }
    }
}