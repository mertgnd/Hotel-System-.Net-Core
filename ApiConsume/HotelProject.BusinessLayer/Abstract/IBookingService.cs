using HotelProject.EntityLayer.Concrete;

namespace HotelProject.BusinessLayer.Abstract
{
    public interface IBookingService : IGenericService<Booking>
    {
        Task BookingStatusChangeApproved(int id);
        Task BookingStatusChangeWait(int id);
        Task BookingStatusChangeReset(int id);
        Task BookingStatusChangeCancel(int id);
        Task<int> BookingCount();
        Task<List<Booking>> Last6Bookings();
    }
}
