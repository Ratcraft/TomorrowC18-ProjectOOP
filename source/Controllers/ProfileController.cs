using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<Profile> userManager;

        public ProfileController(UserManager<Profile> userManager)
        {
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            var userid = userManager.GetUserId(HttpContext.User);
            Profile user = userManager.FindByIdAsync(userid).Result;
            return View(user);
        }
    }
}


// Edited By Louis Ribault 23732