using HotelProject.EntityLayer.Concrete;

namespace HotelProject.DataAccessLayer.Abstract
{
    public interface IAppUserDal : IGenericDal<AppUser>
    {
        Task<List<AppUser>> UserListWithWorkLocation();
        Task<List<AppUser>> UsersListWithWorkLocation();
        Task<int> AppUserCount();
    }
}
