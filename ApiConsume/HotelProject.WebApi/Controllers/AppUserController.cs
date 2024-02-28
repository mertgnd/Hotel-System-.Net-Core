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

        [HttpGet("AppUserList")]
        public async Task<IActionResult> AppUserList()
        {
            var values = await _appUserService.TGetAllAsync();
            return Ok(values);
        }

        [HttpGet("UsersListWithWorkLocation")]
        public async Task<IActionResult> Index()
        {
            var values = await _appUserService.UsersListWithWorkLocation();
            return Ok(values);
        }
    }
}
