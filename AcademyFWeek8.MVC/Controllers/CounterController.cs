using AcademyFWeek8.MVC.EsempioCounter;
using AcademyFWeek8.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AcademyFWeek8.MVC.Controllers
{
    [Authorize(Policy = "Adm")]
    public class CounterController : Controller
    {
        private readonly ICounter counter1;
        private readonly ICounter counter2;

        public CounterController(ICounter counter1, ICounter counter2)
        {
            this.counter1 = counter1;
            this.counter2 = counter2;
        }
        public IActionResult Index()
        {
            int a = counter1.Count();
            int b = counter2.Count();

            CounterViewModel c=new CounterViewModel { A = a, B = b };
            return View(c);
        }
    }
}
