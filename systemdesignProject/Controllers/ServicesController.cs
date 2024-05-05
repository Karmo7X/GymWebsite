using Microsoft.AspNetCore.Mvc;
using systemdesignProject.Models;

namespace systemdesignProject.Controllers
{
    public class ServicesController : Controller
    {
        // This view model contains both services and plans
      
        public IActionResult Services()
        {
            GymdatabaseContext db = new GymdatabaseContext();
            var services_data = db.Services.ToList();
            var plan_data = db.Planstable.ToList();
            var viewModel = new ServicesAndPlansViewModel
            {
                ServicesData = services_data,
                PlanData = plan_data
            };

            return View(viewModel);

           
        }
    }

   
}
