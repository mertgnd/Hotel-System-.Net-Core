using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly IGuestService _guestService;

        public GuestController(IGuestService guestService)
        {
            _guestService = guestService;
        }

        [HttpGet]
        public async Task<IActionResult> GuestList()
        {
            var values = await _guestService.TGetAllAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> AddGuest([FromBody] Guest request)
        {
            var addedItem = await _guestService.TAdd(request);

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
        public async Task<IActionResult> DeleteGuest(int id)
        {
            var values = await _guestService.TGetById(id);

            if (values != null)
            {
                await _guestService.TDelete(values);
            }
            else
            {
                return BadRequest($"There is not such a data with: {id}");
            }

            return Ok($"{id} data has been deleted successfully.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateGuest([FromBody] Guest request)
        {
            var input = await _guestService.TGetById(request.GuestID);

            if (input != null)
            {
                var updatedItem = await _guestService.TUpdate(request);

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
                return BadRequest($"There is no such a data with id: {request.GuestID}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGuestById(int id)
        {
            var values = await _guestService.TGetById(id);

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
