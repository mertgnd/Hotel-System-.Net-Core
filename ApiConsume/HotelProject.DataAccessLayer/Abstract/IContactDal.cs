﻿using HotelProject.EntityLayer.Concrete;

namespace HotelProject.DataAccessLayer.Abstract
{
    public interface IContactDal : IGenericDal<Contact>
    {
        Task<int> GetContactCount();
    }
}
