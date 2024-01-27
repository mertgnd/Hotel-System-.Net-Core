using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactInfoController : ControllerBase
    {
        private readonly IContactInfoService _contactInfoService;

        public ContactInfoController(IContactInfoService contactInfoService)
        {
            _contactInfoService = contactInfoService;
        }

        [HttpGet]
        public async Task<IActionResult> ContactInfoList()
        {
            var values = await _contactInfoService.TGetAllAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> AddContactInfo([FromBody] ContactInfo request)
        {
            var addedItem = await _contactInfoService.TAdd(request);

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
        public async Task<IActionResult> DeleteContactInfo(int id)
        {
            var values = await _contactInfoService.TGetById(id);

            if (values != null)
            {
                await _contactInfoService.TDelete(values);
            }
            else
            {
                return BadRequest($"There is not such a data with: {id}");
            }

            return Ok($"{id} data has been deleted successfully.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateContactInfo([FromBody] ContactInfo request)
        {
            var input = await _contactInfoService.TGetById(request.ContactInfoID);

            if (input != null)
            {
                var updatedItem = await _contactInfoService.TUpdate(request);

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
                return BadRequest($"There is no such a data with id: {request.ContactInfoID}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactInfoById(int id)
        {
            var values = await _contactInfoService.TGetById(id);

            if (values != null)
            {
                return Ok(values);
            }
            else
            {
                return BadRequest($"There is no such a data with id: {id}");
            }
        }
    }
}
