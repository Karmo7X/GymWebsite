using Microsoft.AspNetCore.Mvc;
using systemdesignProject.Models;

namespace systemdesignProject.Controllers
{
    public class ClassesController : Controller
    {
        public IActionResult Classes()
        {
            GymdatabaseContext db = new GymdatabaseContext();
            var classesdata = db.Classes.ToList();
            return View(classesdata);
        }
    }
}
