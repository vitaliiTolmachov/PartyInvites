using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using PartyInvites.Models;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ViewResult Index() {
            int hour = DateTime.Now.Hour;
            ViewBag.Greetings = hour > 12 ? "Good Aftrenoon" : "Good morning";
            return View();
        }
        [HttpGet]
        public ViewResult RsvpForm() {
            return View();
        }
        [HttpPost]
        public ViewResult RsvpForm(GuestResponce guestResponce) {
            if (ModelState.IsValid) {
                //Todo: Send email to partyowner

                try {
                    var client = new SmtpClient("smtp.gmail.com", 587) {
                        Credentials = new NetworkCredential("Fullemail", "PWD"),
                        EnableSsl = true
                    };
                    client.Send("FullemailFromWho", guestResponce.Email, "RSVP Notification",
                        guestResponce.Name + " is " + ((guestResponce.WillAttend ?? false) ? "" : "not")
                + " attending");
                } catch (Exception ex)
                {
                    var m = ex.Message;
                }

                return View("Thanks", guestResponce);
            } else {
                //Form not valid
                return View();
            }
        }
    }
}