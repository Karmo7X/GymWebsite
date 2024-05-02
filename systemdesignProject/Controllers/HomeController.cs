using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using systemdesignProject.Models;

namespace systemdesignProject.Controllers
{
    public class HomeController : Controller
    {
      

        public IActionResult Index()
        {
            GymdatabaseContext db = new GymdatabaseContext();
            var our_teamdata = db.Ourteams.ToList();
            var plan_data = db.Planstables.ToList();
         

            return View(our_teamdata);
        }

     

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
