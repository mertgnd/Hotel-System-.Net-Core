using HotelProject.EntityLayer.Concrete;

namespace HotelProject.WebUI.Dtos.AppUserDtos
{
    public class ResultAppUserDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? City { get; set; }
        public string? ImageURL { get; set; }
        public string? WorkDepartment { get; set; }
        //public int WorkLocationID { get; set; }
        ////public WorkLocation WorkLocation { get; set; }
    }
}
