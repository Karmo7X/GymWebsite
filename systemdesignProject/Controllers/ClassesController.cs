using Microsoft.AspNetCore.Mvc;

namespace systemdesignProject.Controllers
{
    public class ClassesController : Controller
    {
        public IActionResult Classes()
        {
            return View();
        }
    }
}
