using HotelProject.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardWidgetsController : ControllerBase
    {
        private readonly IStaffService _staffService;
        private readonly IBookingService _bookingService;
        private readonly IGuestService _guestService;
        private readonly IAppUserService _appUserService;

        public DashboardWidgetsController(IStaffService staffService, IBookingService bookingService, 
            IGuestService guestService, IAppUserService appUserService)
        {
            _staffService = staffService;
            _bookingService = bookingService;
            _guestService = guestService;
            _appUserService = appUserService;
        }

        [HttpGet("StaffCount")]
        public async Task<IActionResult> StaffCount()
        {
            var value = await _staffService.GetStaffCount();
            return Ok(value);
        }

        [HttpGet("BookingCount")]
        public async Task<IActionResult> BookingCount()
        {
            var value = await _bookingService.BookingCount();
            return Ok(value);
        }

        [HttpGet("GuestCount")]
        public async Task<IActionResult> GuestCount()
        {
            var value = await _guestService.GuestCount();
            return Ok(value);
        }

        [HttpGet("AppUserCount")]
        public async Task<IActionResult> AppUserCount()
        {
            var value = await _appUserService.AppUserCount();
            return Ok(value);
        }
    }
}
