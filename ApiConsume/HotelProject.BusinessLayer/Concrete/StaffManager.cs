using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;


namespace HotelProject.BusinessLayer.Concrete
{
    public class StaffManager : IStaffService
    {
        private readonly IStaffDal _staffDal;

        public StaffManager(IStaffDal staffDal)
        {
            _staffDal = staffDal;
        }

        public async Task<int> GetStaffCount()
        {
            return await _staffDal.GetStaffCount(); 
        }

        public async Task<Staff> TAdd(Staff entity)
        {
            await _staffDal.AddAsync(entity);
            return entity;
        }

        public async Task TDelete(Staff entity)
        {
            await _staffDal.DeleteAsync(entity);
        }

        public async Task<List<Staff>> TGetAllAsync()
        {
            return await _staffDal.GetAllAsync();
        }

        public async Task<Staff> TGetById(int id)
        {
            return await _staffDal.GetByIdAsync(id);
        }

        public async Task<Staff> TUpdate(Staff entity)
        {
            await _staffDal.UpdateAsync(entity);
            return entity;
        }
    }
}
