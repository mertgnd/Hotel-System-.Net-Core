using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.BusinessLayer.Concrete
{
    public class SubscribeManager : ISubscribeService
    {
        private readonly ISubscribeDal _subscribeDal;

        public SubscribeManager(ISubscribeDal subscribeDal)
        {
            _subscribeDal = subscribeDal;
        }

        public async Task<Subscribe> TAdd(Subscribe entity)
        {
            await _subscribeDal.AddAsync(entity);
            return entity;
        }

        public async Task TDelete(Subscribe entity)
        {
            await _subscribeDal.DeleteAsync(entity);
        }

        public async Task<List<Subscribe>> TGetAllAsync()
        {
            return await _subscribeDal.GetAllAsync();
        }

        public async Task<Subscribe> TGetById(int id)
        {
            return await _subscribeDal.GetByIdAsync(id);
        }

        public async Task<Subscribe> TUpdate(Subscribe entity)
        {
            await _subscribeDal.UpdateAsync(entity);
            return entity;
        }
    }
}
