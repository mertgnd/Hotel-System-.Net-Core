using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.BusinessLayer.Concrete
{
    public class RoomManager : IRoomService
    {
        private readonly IRoomDal _roomDal;

        public RoomManager(IRoomDal roomDal)
        {
            _roomDal = roomDal;
        }

        public async Task<Room> TAdd(Room entity)
        {
            await _roomDal.AddAsync(entity);
            return entity;
        }

        public async Task TDelete(Room entity)
        {
            await _roomDal.DeleteAsync(entity);
        }

        public async Task<List<Room>> TGetAllAsync()
        {
            return await _roomDal.GetAllAsync();
        }

        public async Task<Room> TGetById(int id)
        {
            return await _roomDal.GetByIdAsync(id);
        }

        public async Task<Room> TUpdate(Room entity)
        {
            await _roomDal.UpdateAsync(entity);
            return entity;
        }
    }
}
