using HotelProject.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly IAppUserService _appUserService;

        public AppUserController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        //[HttpGet("GetUserListWithWorkLocation")]
        //public async Task<IActionResult> UserListWithWorkLocation()
        //{
        //    var values = await _appUserService.UserListWithWorkLocation();
        //    return Ok(values);
        //}

        [HttpGet]
        public async Task<IActionResult> AppUserList()
        {
            var values = await _appUserService.TGetAllAsync();
            return Ok(values);
        }
    }
}
