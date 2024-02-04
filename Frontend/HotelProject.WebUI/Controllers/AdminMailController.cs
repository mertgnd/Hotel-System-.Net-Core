using HotelProject.WebUI.Models.Mail;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace HotelProject.WebUI.Controllers
{
    public class AdminMailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(AdminMailViewModel request)
        {
            // From who
            MimeMessage mimeMessage = new();
            MailboxAddress mailBoxAddress = new MailboxAddress("Mert Api Project", "mert.fordevelopment@gmail.com");
            mimeMessage.From.Add(mailBoxAddress);

            // To who
            MailboxAddress mailBoxAddressTo = new MailboxAddress("User", request.ReceiverMail); 
            mimeMessage.To.Add(mailBoxAddressTo);

            // Content of Message 
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = request.Message;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = request.Subject;

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("mert.fordevelopment@gmail.com", "hlya bdsb eebq immn");
            client.Send(mimeMessage);
            client.Disconnect(true);

            return View();
        }
    }   
}
