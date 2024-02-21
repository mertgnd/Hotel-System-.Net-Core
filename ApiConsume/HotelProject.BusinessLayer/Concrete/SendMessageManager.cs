using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.EntityFramework;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.BusinessLayer.Concrete
{
    public class SendMessageManager : ISendMessageService
    {
        private readonly ISendMessageDal _sendMessageDal;

        public SendMessageManager(ISendMessageDal sendMessageDal)
        {
            _sendMessageDal = sendMessageDal;
        }

        public async Task<int> SendMessageCount()
        {
            var value = await _sendMessageDal.SendMessageCount();
            return value;
        }

        public async Task<SendMessage> TAdd(SendMessage entity)
        {
            await _sendMessageDal.AddAsync(entity);
            return entity;
        }

        public async Task TDelete(SendMessage entity)
        {
            await _sendMessageDal.DeleteAsync(entity);
        }

        public async Task<List<SendMessage>> TGetAllAsync()
        {
            return await _sendMessageDal.GetAllAsync();
        }

        public async Task<SendMessage> TGetById(int id)
        {
            return await _sendMessageDal.GetByIdAsync(id);
        }

        public async Task<SendMessage> TUpdate(SendMessage entity)
        {
            await _sendMessageDal.UpdateAsync(entity);
            return entity;
        }
    }
}
