using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.RegisterDtos
{
    public class CreateUserDto
    {
        [Required(ErrorMessage = "Name field is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname field is required.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "UserName field is required.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Mail field is required.")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Password field is required.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password field is required.")]
        [Compare("Password", ErrorMessage = "Passwords didnt match.")]
        public string ConfirmPassword { get; set; }
    }
}
