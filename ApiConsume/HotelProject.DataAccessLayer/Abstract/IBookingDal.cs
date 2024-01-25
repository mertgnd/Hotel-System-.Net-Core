using HotelProject.EntityLayer.Concrete;

namespace HotelProject.DataAccessLayer.Abstract
{
    public interface IBookingDal : IGenericDal<Booking>
    {
        Task BookingStatusChangeApproved(int id);
        Task BookingStatusChangeWait(int id);
        Task BookingStatusChangeReset(int id);
        Task BookingStatusChangeCancel(int id);
    }
}
