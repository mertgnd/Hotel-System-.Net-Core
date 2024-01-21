using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public async Task<IActionResult> BookingList()
        {
            var values = await _bookingService.TGetAllAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> AddBooking([FromBody] Booking request)
        {
            var addedItem = await _bookingService.TAdd(request);

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
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var values = await _bookingService.TGetById(id);

            if (values != null)
            {
                await _bookingService.TDelete(values);
            }
            else
            {
                return BadRequest($"There is not such a data with: {id}");
            }

            return Ok($"{id} data has been deleted successfully.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBooking([FromBody] Booking request)
        {
            var input = await _bookingService.TGetById(request.BookingID);

            if (input != null)
            {
                var updatedItem = await _bookingService.TUpdate(request);

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
                return BadRequest($"There is no such a data with id: {request.BookingID}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookingById(int id)
        {
            var values = await _bookingService.TGetById(id);

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
