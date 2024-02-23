using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.BusinessLayer.Concrete
{
    public class WorkLocationManager : IWorkLocationService
    {
        private readonly IWorkLocationDal _workLocationDal;

        public WorkLocationManager(IWorkLocationDal workLocationDal)
        {
            _workLocationDal = workLocationDal;
        }

        public async Task<WorkLocation> TAdd(WorkLocation entity)
        {
            await _workLocationDal.AddAsync(entity);
            return entity;
        }

        public async Task TDelete(WorkLocation entity)
        {
            await _workLocationDal.DeleteAsync(entity);
        }

        public Task<List<WorkLocation>> TGetAllAsync()
        {
            return _workLocationDal.GetAllAsync();
        }

        public Task<WorkLocation> TGetById(int id)
        {
            return _workLocationDal.GetByIdAsync(id);
        }

        public async Task<WorkLocation> TUpdate(WorkLocation entity)
        {
            await _workLocationDal.UpdateAsync(entity);
            return entity;
        }
    }
}
