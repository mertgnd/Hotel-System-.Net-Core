using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.ServiceDtos
{
    public class UpdateServiceDto
    {
        [Required(ErrorMessage = "Please add service id.")]
        public int ServiceID { get; set; }

        [Required(ErrorMessage = "Please add service icon link.")]
        public string Icon { get; set; }

        [Required(ErrorMessage = "Please add service title.")]
        [StringLength(100, ErrorMessage = "Must be less than 100 char.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please add service description.")]
        [StringLength(350, ErrorMessage = "Must be less than 350 char.")]
        public string Description { get; set; }
    }
}
