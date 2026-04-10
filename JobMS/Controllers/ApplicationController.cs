using Microsoft.AspNetCore.Mvc;

namespace JobMS.Controllers
{
    public class ApplicationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
