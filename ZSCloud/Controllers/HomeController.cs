using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZSCloud.Models;
using ZSCloud.Service;

namespace ZSCloud.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(SendEmailModel sendEmailModel)
        {
            EmailService emailService = new EmailService();
            string message = "";
           bool isSentEmail= emailService.SendEmail(sendEmailModel);

            message = isSentEmail == false ? "Email failed, Please check your internet Connection or send again." : "Ëmail sent successfully";

            return Json(new {isSentEmail=isSentEmail, message = message });
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}