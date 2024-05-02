using Microsoft.AspNetCore.Mvc;
using systemdesignProject.Models;

namespace systemdesignProject.Controllers
{
    public class ServicesController : Controller
    {
        public IActionResult Services()
        {

            GymdatabaseContext db = new GymdatabaseContext();
            var servcies_data = db.Services.ToList();
            var plan_data = db.Planstables.ToList();
            return View(servcies_data);
        }
    }
}
