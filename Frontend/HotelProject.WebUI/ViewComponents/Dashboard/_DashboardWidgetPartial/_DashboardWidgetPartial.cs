using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Mozilla;

namespace HotelProject.WebUI.ViewComponents.Dashboard._DashboardWidgetPartial
{
    public class _DashboardWidgetPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardWidgetPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var staffClient = _httpClientFactory.CreateClient();
            var staffResponseMessage = await staffClient.GetAsync("http://localhost:26082/api/DashboardWidgets/StaffCount");
            var staffJsonData = await staffResponseMessage.Content.ReadAsStringAsync();
            ViewBag.staffCount = staffJsonData;

            var bookingClient = _httpClientFactory.CreateClient();
            var bookingResponseMessage = await bookingClient.GetAsync("http://localhost:26082/api/DashboardWidgets/BookingCount");
            var bookingJsonData = await bookingResponseMessage.Content.ReadAsStringAsync();
            ViewBag.bookingCount = bookingJsonData;

            var guestClient = _httpClientFactory.CreateClient();
            var guestResponseMessage = await guestClient.GetAsync("http://localhost:26082/api/DashboardWidgets/GuestCount");
            var guestJsonData = await guestResponseMessage.Content.ReadAsStringAsync();
            ViewBag.guestCount = guestJsonData;

            var appUserClient = _httpClientFactory.CreateClient();
            var appUserResponseMessage = await appUserClient.GetAsync("http://localhost:26082/api/DashboardWidgets/AppUserCount");
            var appUserJsonData = await appUserResponseMessage.Content.ReadAsStringAsync();
            ViewBag.appUserCount = appUserJsonData;

            return View();
        }
    }
}
