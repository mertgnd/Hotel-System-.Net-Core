using HotelProject.WebUI.Dtos.ContactDtos;
using HotelProject.WebUI.Dtos.SendMessageDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class AdminContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Inbox()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:26082/api/Contact");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<InboxMessageDto>>(jsonData);

                // Fetch inbox count
                var inboxCountClient = _httpClientFactory.CreateClient();
                var inboxCountResponseMessage = await inboxCountClient.GetAsync("http://localhost:26082/api/Contact/GetContactCount");
                var jsonDataInboxCount = await inboxCountResponseMessage.Content.ReadAsStringAsync();
                ViewBag.inboxCount = JsonConvert.DeserializeObject<int>(jsonDataInboxCount);

                // Fetch sendbox count
                var sendboxCountClient = _httpClientFactory.CreateClient();
                var sendboxCountResponseMessage = await sendboxCountClient.GetAsync("http://localhost:26082/api/SendMessage/GetSendMessageCount");
                var jsonDataSendBoxCount = await sendboxCountResponseMessage.Content.ReadAsStringAsync();
                ViewBag.sendboxCount = JsonConvert.DeserializeObject(jsonDataSendBoxCount);

                return View(values);
            }

            return View();
        }

        public async Task<IActionResult> SendBox()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:26082/api/SendMessage");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSendBoxDto>>(jsonData);

                // Fetch inbox count
                var inboxCountClient = _httpClientFactory.CreateClient();
                var inboxCountResponseMessage = await inboxCountClient.GetAsync("http://localhost:26082/api/Contact/GetContactCount");
                var jsonDataInboxCount = await inboxCountResponseMessage.Content.ReadAsStringAsync();
                ViewBag.inboxCount = JsonConvert.DeserializeObject<int>(jsonDataInboxCount);

                // Fetch sendbox count
                var sendboxCountClient = _httpClientFactory.CreateClient();
                var sendboxCountResponseMessage = await sendboxCountClient.GetAsync("http://localhost:26082/api/SendMessage/GetSendMessageCount");
                var jsonDataSendBoxCount = await sendboxCountResponseMessage.Content.ReadAsStringAsync();
                ViewBag.sendboxCount = JsonConvert.DeserializeObject(jsonDataSendBoxCount);

                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddSendMessage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSendMessage(AddSendMessageDto request)
        {
            request.SenderMail = "mertgnd36@gmail.com";
            request.SenderName = "Admin";
            request.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(request);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:26082/api/SendMessage", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("SendBox");
            }
            return View();
        }

        public async Task<IActionResult> MessageDetailsBySendBox(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:26082/api/SendMessage/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetSendMessageByIdDto>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> MessageDetailsByInbox(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:26082/api/Contact/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<InboxMessageDto>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<PartialViewResult> SidebarAdminContactPartial()
        {
            // Fetch inbox count
            var inboxCountClient = _httpClientFactory.CreateClient();
            var inboxCountResponseMessage = await inboxCountClient.GetAsync("http://localhost:26082/api/Contact/GetContactCount");
            if (inboxCountResponseMessage.IsSuccessStatusCode)
            {
                var jsonDataInboxCount = await inboxCountResponseMessage.Content.ReadAsStringAsync();
                ViewBag.inboxCount = JsonConvert.DeserializeObject<int>(jsonDataInboxCount);
            }
            else
            {
                // Handle error if required
                ViewBag.inboxCount = 0; // Set a default value
            }

            // Fetch sendbox count
            var sendboxCountClient = _httpClientFactory.CreateClient();
            var sendboxCountResponseMessage = await sendboxCountClient.GetAsync("http://localhost:26082/api/SendMessage/GetSendMessageCount");
            if (sendboxCountResponseMessage.IsSuccessStatusCode)
            {
                var jsonDataSendBoxCount = await sendboxCountResponseMessage.Content.ReadAsStringAsync();
                ViewBag.sendboxCount = JsonConvert.DeserializeObject<int>(jsonDataSendBoxCount);
            }
            else
            {
                // Handle error if required
                ViewBag.sendboxCount = 0; // Set a default value
            }

            return PartialView();
        }

        public PartialViewResult SidebarAdminContactCategoryPartial()
        {
            return PartialView();
        }
    }
}
