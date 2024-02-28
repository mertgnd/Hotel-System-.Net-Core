using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.BusinessLayer.Concrete
{
    public class AppUserManager : IAppUserService
    {
        private readonly IAppUserDal _appUserDal;

        public AppUserManager(IAppUserDal appUserDal)
        {
            _appUserDal = appUserDal;
        }

        public async Task<int> AppUserCount()
        {
            var value = await _appUserDal.AppUserCount();
            return value;
        }

        public async Task<AppUser> TAdd(AppUser entity)
        {
            await _appUserDal.AddAsync(entity);
            return entity;
        }

        public async Task TDelete(AppUser entity)
        {
            await _appUserDal.DeleteAsync(entity);
        }

        public async Task<List<AppUser>> TGetAllAsync()
        {
            return await _appUserDal.GetAllAsync(); ;
        }

        public async Task<AppUser> TGetById(int id)
        {
            return await _appUserDal.GetByIdAsync(id); ;
        }

        public async Task<AppUser> TUpdate(AppUser entity)
        {
            await _appUserDal.UpdateAsync(entity);
            return entity;
        }

        public async Task<List<AppUser>> UserListWithWorkLocation()
        {
            return await _appUserDal.UserListWithWorkLocation();
        }

        public async Task<List<AppUser>> UsersListWithWorkLocation()
        {
            return await _appUserDal.UsersListWithWorkLocation();
        }
    }
}
