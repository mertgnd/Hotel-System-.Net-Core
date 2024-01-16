using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.LoginDtos
{
    public class LoginUserDto
    {
        [Required(ErrorMessage = "This field is required.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public string Password { get; set; }
    }
}
