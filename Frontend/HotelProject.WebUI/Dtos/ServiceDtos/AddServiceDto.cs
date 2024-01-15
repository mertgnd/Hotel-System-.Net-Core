using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.ServiceDtos
{
    public class AddServiceDto
    {
        [Required(ErrorMessage = "Please add service icon link.")]
        public string Icon { get; set; }

        [Required(ErrorMessage = "Please add service title.")]
        [StringLength(100, ErrorMessage = "Must be less than 100 char.")]
        public string Title { get; set; }

        public string Description { get; set; }
    }
}
