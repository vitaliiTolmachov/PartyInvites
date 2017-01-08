using System;
using System.Collections.Generic;
using System.Linq;
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
                return View("Thanks", guestResponce);
            } else {
                //Form not valid
                return View();
            }
        }
    }
}