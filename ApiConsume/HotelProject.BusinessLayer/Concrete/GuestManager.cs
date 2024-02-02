using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.BusinessLayer.Concrete
{
    public class GuestManager : IGuestService
    {
        private readonly IGuestDal _guestDal;

        public GuestManager(IGuestDal guestDal)
        {
            _guestDal = guestDal;
        }

        public async Task<Guest> TAdd(Guest entity)
        {
            await _guestDal.AddAsync(entity);
            return entity;
        }

        public async Task TDelete(Guest entity)
        {
            await _guestDal.DeleteAsync(entity);
        }

        public async Task<List<Guest>> TGetAllAsync()
        {
            return await _guestDal.GetAllAsync();
        }

        public async Task<Guest> TGetById(int id)
        {
            return await _guestDal.GetByIdAsync(id);
        }

        public async Task<Guest> TUpdate(Guest entity)
        {
            await _guestDal.UpdateAsync(entity);
            return entity;
        }
    }
}
