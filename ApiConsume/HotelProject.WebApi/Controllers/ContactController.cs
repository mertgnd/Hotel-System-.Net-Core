using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public async Task<IActionResult> ContactList()
        {
            var values = await _contactService.TGetAllAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> AddContact([FromBody] Contact request)
        {
            request.Date = Convert.ToDateTime(DateTime.Now.ToString());
            var addedItem = await _contactService.TAdd(request);

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
        public async Task<IActionResult> DeleteContact(int id)
        {
            var values = await _contactService.TGetById(id);

            if (values != null)
            {
                await _contactService.TDelete(values);
            }
            else
            {
                return BadRequest($"There is not such a data with: {id}");
            }

            return Ok($"{id} data has been deleted successfully.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateContact([FromBody] Contact request)
        {
            var input = await _contactService.TGetById(request.ContactID);

            if (input != null)
            {
                var updatedItem = await _contactService.TUpdate(request);

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
                return BadRequest($"There is no such a data with id: {request.ContactID}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactById(int id)
        {
            var values = await _contactService.TGetById(id);

            if (values != null)
            {
                return Ok(values);
            }
            else
            {
                return BadRequest($"There is no such a data with id: {id}");
            }
        }

        [HttpGet("GetContactCount")]
        public async Task<IActionResult> GetContactCount()
        {
            var values = await _contactService.GetContactCount();
            return Ok(values);
        }
    }
}
