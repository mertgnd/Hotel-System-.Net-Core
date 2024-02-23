using Microsoft.AspNetCore.Identity;

namespace HotelProject.EntityLayer.Concrete
{
    public class AppUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? City { get; set; }
        public string? ImageURL { get; set; }
        public string? Gender { get; set; }
        public string? Country { get; set; }
        public string? WorkDepartment { get; set; }
        public int WorkLocationID { get; set; }
        public WorkLocation WorkLocation { get; set; }
    }
}
