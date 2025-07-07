using System.ComponentModel.DataAnnotations;

namespace UserManagement.Web.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string Name { get; set; } = "";

        [Required]
        [Display(Name = "Fecha de nacimiento")]
        public DateTime Birthdate { get; set; }

        [Required]
        [Display(Name = "Sexo")]
        [MaxLength(1)]
        [MinLength(1)]
        public string Gender { get; set; } = "";
    }
}
