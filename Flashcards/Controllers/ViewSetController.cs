using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Flashcards.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Flashcards.Controllers {
    public class ViewSetController : Controller {

        public ViewSetController(IHostingEnvironment environment){
            HostEnv = environment;
        }

        private IHostingEnvironment HostEnv { get; set; }

        [Route("set/{setname}/{username}")]
        public IActionResult Index(string username, string setname) {

            string filepath = Path.Combine(HostEnv.WebRootPath, $"sets/{username}/{setname}.json");
            CardSet set = null;
            if(System.IO.File.Exists(filepath)){
                set = CardSet.BuildFromJson(System.IO.File.ReadAllText(filepath));
            }

            return View(set);
        }

        [Route("set/json/{setname}/{username}")]
        public IActionResult Json(string username, string setname){
            string filepath = Path.Combine(HostEnv.WebRootPath, $"sets/{username}/{setname}.json");
            CardSet set = null;
            if (System.IO.File.Exists(filepath)) {
                set = CardSet.BuildFromJson(System.IO.File.ReadAllText(filepath));
            }

            return Json(set);
        }
    }
}
