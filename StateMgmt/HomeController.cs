using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
       
        public IActionResult Index()
        {
            string Name = Request.Cookies["Name"];
            return View("Index",Name);
        }
        [HttpPost]
        public IActionResult OnPost(IFormCollection form)
        {
            string Name = form["Name"].ToString();
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddMinutes(10);
            Response.Cookies.Append("Name", Name, options);
            return RedirectToAction(nameof(Index));
            
        }
        public IActionResult DeleteCookie()
        {
            Response.Cookies.Delete("Name");
            return View("Index");
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
