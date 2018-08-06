using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Flashcards.Models;

namespace Flashcards.Controllers {
    public class HomeController : Controller {
        [Route("")]
        public IActionResult Index() {
            return View();
        }
        [Route("about")]
        public IActionResult About() {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
        [Route("contact")]
        public IActionResult Contact() {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        [Route("privacy")]
        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
