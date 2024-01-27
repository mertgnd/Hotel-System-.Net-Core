using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EfContactInfoDal : GenericRepository<ContactInfo>, IContactInfoDal
    {
        public EfContactInfoDal(Context context) : base(context)
        {
        }
    }
}
