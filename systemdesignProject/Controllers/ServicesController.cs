using Microsoft.AspNetCore.Mvc;

namespace systemdesignProject.Controllers
{
    public class ServicesController : Controller
    {
        public IActionResult Services()
        {
            return View();
        }
    }
}
