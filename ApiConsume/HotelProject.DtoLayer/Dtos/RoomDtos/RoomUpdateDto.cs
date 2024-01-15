using System.ComponentModel.DataAnnotations;

namespace HotelProject.DtoLayer.Dtos.RoomDtos
{
    public class RoomUpdateDto
    {
        [Required(ErrorMessage = "Please enter room Id.")]
        public int RoomID { get; set; }

        [Required(ErrorMessage = "Please enter room photo.")]
        public string CoverImg { get; set; }

        [Required(ErrorMessage = "Please enter room number.")]
        public string RoomNumber { get; set; }

        [Required(ErrorMessage = "Please enter room price.")]
        public int Price { get; set; }
        
        [Required(ErrorMessage = "Please enter room title.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter bed count.")]
        public string BedCount { get; set; }

        [Required(ErrorMessage = "Please enter room photo.")]
        public string BathCount { get; set; }

        [Required]
        public string Wifi { get; set; }

        [Required(ErrorMessage = "Please enter room photo.")]
        public string Description { get; set; }
    }
}
