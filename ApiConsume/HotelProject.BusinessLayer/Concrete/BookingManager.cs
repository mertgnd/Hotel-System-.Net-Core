﻿using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.BusinessLayer.Concrete
{
    public class BookingManager : IBookingService
    {
        private readonly IBookingDal _bookingDal;

        public BookingManager(IBookingDal bookingDal)
        {
            _bookingDal = bookingDal;
        }

        public async Task<Booking> TAdd(Booking entity)
        {
            await _bookingDal.AddAsync(entity);
            return entity;
        }

        public async Task TDelete(Booking entity)
        {
            await _bookingDal.DeleteAsync(entity);
        }

        public async Task<List<Booking>> TGetAllAsync()
        {
            return await _bookingDal.GetAllAsync();
        }

        public async Task<Booking> TGetById(int id)
        {
            return await _bookingDal.GetByIdAsync(id);
        }

        public async Task<Booking> TUpdate(Booking entity)
        {
            await _bookingDal.UpdateAsync(entity);
            return entity;
        }
    }
}
