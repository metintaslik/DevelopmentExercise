using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DevelopmentExercise.API.Models
{
    public class User
    {
        public User()
        {
            Role = (Role)Enum.Parse(typeof(Role), RoleID.ToString());
        }

        // Concretes

        [Key]
        [NotNull]
        [Required]
        public int ID { get; set; }

        [NotNull]
        [Required]
        [DataType(DataType.Text)]
        [StringLength(25, MinimumLength = 3)]
        public string FirstName { get; set; } = null!;

        [NotNull]
        [Required]
        [StringLength(25, MinimumLength = 2)]
        [DataType(DataType.Text)]
        public string LastName { get; set; } = null!;

        [NotNull]
        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

        [NotNull]
        [Required]
        public int RoleID { get; set; }

        [NotNull]
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Created { get; set; }


        // Foreigns

        public Role Role { get; set; }
        public virtual ICollection<Order> Orders { get; set; } = null!;
    }
}