
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EfAppUserDal : GenericRepository<AppUser>, IAppUserDal
    {
        public EfAppUserDal(Context context) : base(context)
        {
        }

        public async Task<int> AppUserCount()
        {
            return await _context.Users.CountAsync();
        }

        public async Task<List<AppUser>> UserListWithWorkLocation()
        {
            var values = await _context.Users.Include(x => x.WorkLocation).ToListAsync();
            return values;
        }

        public async Task<List<AppUser>> UsersListWithWorkLocation()
        {
            var values = await _context.Users.Include(x => x.WorkLocation).ToListAsync();
            return values;
        }
    }
}
