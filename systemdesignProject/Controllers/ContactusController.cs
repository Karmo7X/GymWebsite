using Microsoft.AspNetCore.Mvc;

namespace systemdesignProject.Controllers
{
    public class ContactusController : Controller
    {
        public IActionResult Contactus()
        {
            return View();
        }
    }
}
