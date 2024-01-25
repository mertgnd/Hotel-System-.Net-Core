using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiConsume.Models;

namespace RapidApiConsume.Controllers
{
    public class SearchLocationIdController : Controller
    {
        public async Task<IActionResult> Index(string cityName)
        {
            cityName = !string.IsNullOrEmpty(cityName) ? cityName : "Berlin";

            List<BookingApiLocationViewModel> model = new List<BookingApiLocationViewModel>();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?name={cityName}&locale=en-gb"),
                Headers =
                {
                    { "X-RapidAPI-Key", "44211a5278mshc0de0dae1c1ff86p12a2efjsn5687d846b0c4" },
                    { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                model = JsonConvert.DeserializeObject<List<BookingApiLocationViewModel>>(body);
                return View(model.Take(1).ToList());
            }
        }
    }
}
