using LaytonTemple.Models;
using LaytonTemple.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LaytonTemple.Controllers
{
    public class HomeController : Controller
    {
        private ApptContext daContext { get; set; }
        private readonly ILogger<HomeController> _logger;

        public HomeController(ApptContext group)
        {
            daContext = group;
        } 
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Sign_Up()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Sign_Up(AvailableTimes temp)
        {
            var x = new GroupView { timeslot = temp};
            return View("Form", x);
        }


        [HttpPost]
        public IActionResult Form(GroupView group)
        {
            daContext.Update(group);
            daContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Appointments()
        {
            var x = daContext.Info.ToList();
            return View("Appointments", x);
        }

        [HttpGet]
        public IActionResult Edit(int groupid)
        {
            var application = daContext.Groups.Single(x => x.GroupID == groupid);

            return View("Form", application);
        }

        [HttpPost]
        public IActionResult Edit(GroupInfo blah)
        {
            daContext.Update(blah);
            daContext.SaveChanges();
                     
            return View("Appointments");
        }

        public IActionResult Delete(GroupInfo blah)
        {
            daContext.Remove(blah);
            daContext.SaveChanges();

            return View("Appointments");
        }

    }
}
