using System.ComponentModel.DataAnnotations;

namespace DevelopmentExercise.API.Models
{
    public enum Role
    {
        [Display(Name = "Employee")]
        Employee = 1,
        [Display(Name = "Affiliate")]
        Affiliate = 2,
        [Display(Name = "Customer")]
        Customer = 3,
    }
}