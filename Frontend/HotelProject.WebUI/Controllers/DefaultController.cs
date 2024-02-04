using HotelProject.DataAccessLayer.Concrete;
using HotelProject.WebUI.Dtos.SubscribeDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly Context _context;

        public DefaultController(IHttpClientFactory httpClientFactory, Context context)
        {
            _httpClientFactory = httpClientFactory;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult _SubscribePartial()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> _SubscribePartial(AddSubscribeDto request)
        {
            bool isEmailSubscribed = CheckIfEmailIsSubscribed(request.Mail);

            if (isEmailSubscribed)
            {
                TempData["SubscribeDangerMessage"] = "This Email already registered.";
            }
            else
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(request);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                await client.PostAsync("http://localhost:26082/api/Subscribe", stringContent);

                TempData["SubscribeSuccessMessage"] = "Your subscribe was successful!";
            }

            return RedirectToAction("Index", "Default", new { section = "subscribeSection" });
        }

        private bool CheckIfEmailIsSubscribed(string email)
        {
            bool isEmailSubscribed = _context.Subscribes.Any(s => s.Mail == email);

            return isEmailSubscribed;
        }
    }
}
