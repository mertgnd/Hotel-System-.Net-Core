using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;


namespace HotelProject.BusinessLayer.Concrete
{
    public class ServiceManager : IServiceService
    {
        private readonly IServiceDal _serviceDal;

        public ServiceManager(IServiceDal serviceDal)
        {
            _serviceDal = serviceDal;
        }

        public async Task<Service> TAdd(Service entity)
        {
            await _serviceDal.AddAsync(entity);
            return entity;
        }

        public async Task TDelete(Service entity)
        {
            await _serviceDal.DeleteAsync(entity);
        }

        public async Task<List<Service>> TGetAllAsync()
        {
            return await _serviceDal.GetAllAsync();
        }

        public async Task<Service> TGetById(int id)
        {
            return await _serviceDal.GetByIdAsync(id);
        }

        public async Task<Service> TUpdate(Service entity)
        {
            await _serviceDal.UpdateAsync(entity);
            return entity;
        }
    }
}
