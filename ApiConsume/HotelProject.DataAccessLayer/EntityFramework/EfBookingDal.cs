using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {

        public EfBookingDal(Context context) : base(context)
        { 
        }

        public async Task BookingStatusChangeApproved(int id)
        {
            var values = await GetByIdAsync(id);

            if(values != null)
            {
                values.Status = "Approved.";
                await UpdateAsync(values);
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task BookingStatusChangeCancel(int id)
        {
            var values = await GetByIdAsync(id);

            if (values != null)
            {
                values.Status = "Canceled.";
                await UpdateAsync(values);
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task BookingStatusChangeReset(int id)
        {
            var values = await GetByIdAsync(id);

            if (values != null)
            {
                values.Status = "Waiting for Approval.";
                await UpdateAsync(values);
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task BookingStatusChangeWait(int id)
        {
            var values = await GetByIdAsync(id);

            if (values != null)
            {
                values.Status = "Holding.";
                await UpdateAsync(values);
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
