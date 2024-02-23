
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.BusinessLayer.Abstract
{
    public interface IAppUserService : IGenericService<AppUser>
    {
        Task<List<AppUser>> UserListWithWorkLocation();
    }
}
