using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendMessageController : ControllerBase
    {
        private readonly ISendMessageService _sendMessageService;

        public SendMessageController(ISendMessageService sendMessageService)
        {
            _sendMessageService = sendMessageService;
        }

        [HttpGet]
        public async Task<IActionResult> SendMessageList()
        {
            var values = await _sendMessageService.TGetAllAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> AddSendMessage([FromBody] SendMessage request)
        {
            var addedItem = await _sendMessageService.TAdd(request);

            if (addedItem != null)
            {
                return Ok(addedItem);
            }
            else
            {
                return StatusCode(500, "Failed to add data");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSendMessage(int id)
        {
            var values = await _sendMessageService.TGetById(id);

            if (values != null)
            {
                await _sendMessageService.TDelete(values);
            }
            else
            {
                return BadRequest($"There is not such a item with: {id}");
            }

            return Ok($"{id} item has been deleted successfully.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSendMessage([FromBody] SendMessage request)
        {
            var input = await _sendMessageService.TGetById(request.SendMessageID);

            if (input != null)
            {
                var updatedItem = await _sendMessageService.TUpdate(request);

                if (updatedItem != null)
                {
                    return Ok(updatedItem);
                }
                else
                {
                    return BadRequest("Update has been failed.");
                }
            }
            else
            {
                return BadRequest($"There is no such a item with id: {request.SendMessageID}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSendMessageById(int id)
        {
            var values = await _sendMessageService.TGetById(id);

            if (values != null)
            {
                return Ok(values);
            }
            else
            {
                return BadRequest($"There is no such a item with id: {id}");
            }
        }
    }
}
