namespace HotelProject.BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        Task<T> TAdd(T entity);
        Task TDelete(T entity);
        Task<T> TUpdate(T entity);
        Task<List<T>> TGetAllAsync();
        Task<T> TGetById(int id);
    }
}
