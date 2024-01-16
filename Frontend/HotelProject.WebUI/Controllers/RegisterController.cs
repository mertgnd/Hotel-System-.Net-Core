using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.RegisterDtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateUserDto request)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }

            var appUser = new AppUser() 
            { 
                Name = request.Name,
                Surname = request.Surname,
                Email = request.Mail,
                UserName = request.Username,
            };

            var result = await _userManager.CreateAsync(appUser, request.Password);

            if(result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }

            return View();
        }
    }
}
