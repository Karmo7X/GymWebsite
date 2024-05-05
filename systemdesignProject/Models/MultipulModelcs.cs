using Microsoft.AspNetCore.Mvc;

namespace systemdesignProject.Models
{
    public class ServicesAndPlansViewModel
    {
        public List<Service> ServicesData { get; set; }
        public List<Planstable> PlanData { get; set; }
    }
    public class HomeMultipulViewModel
    {
        public List<Ourteam> OurteamData { get; set; }
        public List<Planstable> PlanData { get; set; }
        public List<Class> ClassesData { get; set; }
    }
}
