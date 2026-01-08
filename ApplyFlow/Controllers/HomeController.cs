using System.Diagnostics;
using ApplyFlow.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApplyFlow.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if(User.Identity != null && User.Identity.IsAuthenticated)
            {
               return RedirectToAction("Index", "JobApplications");
			}
			return View();
        }

    }
}
