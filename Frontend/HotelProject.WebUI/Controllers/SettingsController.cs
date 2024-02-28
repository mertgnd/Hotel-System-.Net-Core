using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Models.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    public class SettingsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public SettingsController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel model = new UserEditViewModel();
            model.Name = user.Name;
            model.Surname = user.Surname;
            model.Email = user.Email;
            model.Username = user.UserName;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel request)
        {
            if(request.Password == request.ConfirmPassword)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                user.Name = request.Name;
                user.Surname = request.Surname;
                user.Email = request.Email;
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, request.Password);
                await _userManager.UpdateAsync(user);
                return RedirectToAction("Index", "Login");
            }

            return View();
        }
    }
}
