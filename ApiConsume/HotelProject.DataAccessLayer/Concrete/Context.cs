using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelProject.DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser, AppRole, int>
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Staff> Staffs { get; set;}
        public DbSet<Subscribe> Subscribes { get; set;}
        public DbSet<Testimonial> Testimonials { get; set;}
        public DbSet<About> Abouts { get; set;}
        public DbSet<Booking> Bookings { get; set;}
    }
}

// For some reasons of Changing status I had to use this code block but I dont need it anymore. But I didnt want it to delete.

//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//{

//    var configuration = new ConfigurationBuilder()
//        .SetBasePath(Directory.GetCurrentDirectory())
//        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
//        .Build();

//    var connectionString = configuration.GetConnectionString("DefaultConnection");

//    optionsBuilder.UseSqlServer(connectionString);
//    optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
//}