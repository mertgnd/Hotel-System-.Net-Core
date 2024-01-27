using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.BusinessLayer.Concrete
{
    public class ContactInfoManager : IContactInfoService
    {
        private readonly IContactInfoDal _contactInfoDal;

        public ContactInfoManager(IContactInfoDal contactInfoDal)
        {
            _contactInfoDal = contactInfoDal;
        }

        public async Task<ContactInfo> TAdd(ContactInfo entity)
        {
            await _contactInfoDal.AddAsync(entity);
            return entity;
        }

        public async Task TDelete(ContactInfo entity)
        {
            await _contactInfoDal.DeleteAsync(entity);
        }

        public async Task<List<ContactInfo>> TGetAllAsync()
        {
            return await _contactInfoDal.GetAllAsync();
        }

        public async Task<ContactInfo> TGetById(int id)
        {
            return await _contactInfoDal.GetByIdAsync(id);
        }

        public async Task<ContactInfo> TUpdate(ContactInfo entity)
        {
            await _contactInfoDal.UpdateAsync(entity);
            return entity;
        }
    }
}
