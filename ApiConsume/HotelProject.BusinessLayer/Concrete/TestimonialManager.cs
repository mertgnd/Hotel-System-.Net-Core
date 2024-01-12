using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using System.Formats.Asn1;

namespace HotelProject.BusinessLayer.Concrete
{
    public class TestimonialManager : ITestimonialService
    {
        private readonly ITestimonialDal _testimonialDal;

        public TestimonialManager(ITestimonialDal testimonialDal)
        {
            _testimonialDal = testimonialDal;
        }

        public async Task<Testimonial> TAdd(Testimonial entity)
        {
            await _testimonialDal.AddAsync(entity);
            return entity;
        }

        public async Task TDelete(Testimonial entity)
        {
            await _testimonialDal.DeleteAsync(entity);
        }

        public async Task<List<Testimonial>> TGetAllAsync()
        {
            return await _testimonialDal.GetAllAsync();
        }

        public async Task<Testimonial> TGetById(int id)
        {
            return await _testimonialDal.GetByIdAsync(id);
        }

        public async Task<Testimonial> TUpdate(Testimonial entity)
        {
            await _testimonialDal.UpdateAsync(entity);
            return entity;
        }
    }
}
