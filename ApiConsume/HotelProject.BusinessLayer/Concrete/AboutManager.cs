using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public async Task<About> TAdd(About entity)
        {
            await _aboutDal.AddAsync(entity);
            return entity;
        }

        public async Task TDelete(About entity)
        {
            await _aboutDal.DeleteAsync(entity);
        }

        public async Task<List<About>> TGetAllAsync()
        {
            return await _aboutDal.GetAllAsync();
        }

        public async Task<About> TGetById(int id)
        {
            return await _aboutDal.GetByIdAsync(id);
        }

        public async Task<About> TUpdate(About entity)
        {
            await _aboutDal.UpdateAsync(entity);
            return entity;
        }
    }
}
