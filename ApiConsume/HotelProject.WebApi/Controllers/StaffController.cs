using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _staffService;

        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        [HttpGet]
        public async Task<IActionResult> StaffList()
        {
            var values = await _staffService.TGetAllAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> AddStaff([FromBody] Staff request)
        {
            var addedStaff = await _staffService.TAdd(request);

            if (addedStaff != null)
            {
                return Ok(addedStaff);
            }
            else
            {
                return StatusCode(500, "Failed to add data");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaff(int id)
        {
            var values = await _staffService.TGetById(id);

            if (values != null)
            {
                await _staffService.TDelete(values);
            }
            else
            {
                return BadRequest($"There is not such a item with: {id}");
            }

            return Ok($"{id} item has been deleted successfully.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStaff([FromBody] Staff request)
        {
            var input = await _staffService.TGetById(request.StaffID);

            if (input != null)
            {
                var updatedStaff = await _staffService.TUpdate(request);

                if (updatedStaff != null)
                {
                    return Ok(updatedStaff);
                }
                else
                {
                    return BadRequest("Update has been failed.");
                }
            }
            else
            {
                return BadRequest($"There is no such a item with id: {request.StaffID}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStaffById(int id)
        {
            var values = await _staffService.TGetById(id);
            
            if(values != null)
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
