using Microsoft.AspNetCore.Mvc;
using systemdesignProject.Models;

namespace systemdesignProject.Controllers
{
    public class OurteamController : Controller
    {
        public IActionResult Ourteam()
        {

            GymdatabaseContext db = new GymdatabaseContext();
            var our_teamdata = db.Ourteams.ToList();
            return View(our_teamdata);
        }
    }
}
