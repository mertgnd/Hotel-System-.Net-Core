using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelProject.DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser, AppRole, int>
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
            //optionsBuilder.UseSqlServer("server=DESKTOP-BFFKA5K;initial catalog=hotelDB;integrated security=true;");
        }
        
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Staff> Staffs { get; set;}
        public DbSet<Subscribe> Subscribes { get; set;}
        public DbSet<Testimonial> Testimonials { get; set;}
        public DbSet<About> Abouts { get; set;}
        public DbSet<Booking> Bookings { get; set;}
    }
}