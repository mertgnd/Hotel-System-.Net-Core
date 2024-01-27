using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.EntityFramework;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.BusinessLayer.Concrete
{
    public class ContactManager : IContactService
    {
        private readonly IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public async Task<Contact> TAdd(Contact entity)
        {
            await _contactDal.AddAsync(entity);
            return entity;
        }

        public async Task TDelete(Contact entity)
        {
            await _contactDal.DeleteAsync(entity);
        }

        public async Task<List<Contact>> TGetAllAsync()
        {
            return await _contactDal.GetAllAsync();
        }

        public async Task<Contact> TGetById(int id)
        {
            return await _contactDal.GetByIdAsync(id);
        }

        public async Task<Contact> TUpdate(Contact entity)
        {
            await _contactDal.UpdateAsync(entity);
            return entity;
        }
    }
}
