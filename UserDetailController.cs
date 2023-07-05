using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class UserDetailController : Controller
    {
        public IActionResult Index()
        {
            HttpContext.Session.SetString("Name", "Thakur");
            HttpContext.Session.SetString("Gender", "Male");
            HttpContext.Session.SetInt32("Age", 50);

            return View();
        }
        public IActionResult Get()
        {
            User usr = new User()
            {
                Name = HttpContext.Session.GetString("Name"),
                Gender = HttpContext.Session.GetString("Gender"),
                Age = HttpContext.Session.GetInt32("Age").Value
            };
            return View(usr);
        }
    }
}

