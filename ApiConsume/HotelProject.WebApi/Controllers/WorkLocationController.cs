using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkLocationController : ControllerBase
    {
        private readonly IWorkLocationService _workLocationService;

        public WorkLocationController(IWorkLocationService workLocationService)
        {
            _workLocationService = workLocationService;
        }

        [HttpGet]
        public async Task<IActionResult> WorkLocationList()
        {
            var values = await _workLocationService.TGetAllAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> AddWorkLocation([FromBody] WorkLocation request)
        {
            var addedItem = await _workLocationService.TAdd(request);

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
        public async Task<IActionResult> DeleteWorkLocation(int id)
        {
            var values = await _workLocationService.TGetById(id);

            if (values != null)
            {
                await _workLocationService.TDelete(values);
            }
            else
            {
                return BadRequest($"There is not such a data with: {id}");
            }

            return Ok($"{id} data has been deleted successfully.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateWorkLocation([FromBody] WorkLocation request)
        {
            var input = await _workLocationService.TGetById(request.WorkLocationID);

            if (input != null)
            {
                var updatedItem = await _workLocationService.TUpdate(request);

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
                return BadRequest($"There is no such a data with id: {request.WorkLocationID}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWorkLocationById(int id)
        {
            var values = await _workLocationService.TGetById(id);

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
