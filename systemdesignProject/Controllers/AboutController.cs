using Microsoft.AspNetCore.Mvc;

namespace systemdesignProject.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Aboutus()
        {
            return View();
        }
    }
}
