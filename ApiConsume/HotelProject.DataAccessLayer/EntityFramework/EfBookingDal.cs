using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        public EfBookingDal(Context context) : base(context)
        { 
        }

        public async Task BookingStatusChangeApproved(int id)
        {
            using (var context = new Context())
            {
                var values = await context.Bookings.FindAsync(id);

                values.Status = "Approved";
                await context.SaveChangesAsync();
            }
        }
    }
}
