using AcademyFWeek8.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AcademyFWeek8.MVC.Controllers
{
    [Authorize] //mi rimanda direttamente al login, non devo essere per forza amministratore o utente
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [AllowAnonymous] //mi permette di accedere a queste azioni anche senza autenticazione
        public IActionResult Index()
        {
            return View();
        }
        //devo essere autenticato perchè non ho Allow idem per le altre perchè all inizio ho messo authorized
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Prova()
        {
            //model
            NumeroViewModel mioOggettoProva = new NumeroViewModel() { ValoreNumerico = 10, NumeroInLettere = "dieci" };

            //ViewBag
            ViewBag.Messaggio = "Benvenuti nella pagina. Questo è il messaggio contenuto nella variabile MESSAGGIO della ViewBag";
            ViewBag.Valore = 123;
            NumeroViewModel mioNumero1 = new NumeroViewModel() { ValoreNumerico = 1, NumeroInLettere = "uno" };
            ViewBag.PrimoNumero = mioNumero1;

            //ViewData
            ViewData["MessaggioVD"] = "Benvenuti anche da parte del ViewData";
            ViewData["ValoreVD"] = 123444444;
            //ViewData["Valore"] = 999999999; //Attenzione alle chiavi
            NumeroViewModel mioNumero2 = new NumeroViewModel() { ValoreNumerico = 2, NumeroInLettere = "due" };
            ViewData["SecondoNumero"] = mioNumero2;

            return View(mioOggettoProva);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}