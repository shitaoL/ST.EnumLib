using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EnumLibTest.Models;
using ST.EnumLib;

namespace EnumLibTest.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            string displayName = UserStatus.Active.GetDisplayName();
            string description = UserStatus.Active.GetDescription();

            //if status =2
            int status = 2;
            string name = status.GetName<UserStatus>();

            displayName = status.GetDisplayName<UserStatus>();
            description = status.GetDescription<UserStatus>();

            displayName = ((UserStatus)status).GetDisplayName();
            description = ((UserStatus)status).GetDescription();
            
            var dic = EnumUtil.GetNamesDictionary<UserStatus>();
            dic = EnumUtil.GetDisplayNamesDictionary<UserStatus>();
            dic = EnumUtil.GetDescriptionsDictionary<UserStatus>();

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
