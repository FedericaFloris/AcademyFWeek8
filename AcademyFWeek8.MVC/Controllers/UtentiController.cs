using AcademyFWeek8.Core.BusinessLayer;
using AcademyFWeek8.Core.Entities;
using AcademyFWeek8.MVC.Helper;
using AcademyFWeek8.MVC.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AcademyFWeek8.MVC.Controllers
{
    public class UtentiController : Controller
    {
        private readonly IBusinessLayer BL;
        public UtentiController(IBusinessLayer bl)
        {
            BL = bl;
        }
        [HttpGet]
        public IActionResult Login(string returnUrl="/")
        {
            return View(new UtenteLoginViewModel { ReturnUrl = returnUrl });
        }
        [HttpPost]
        public async Task<IActionResult> LoginAsync(UtenteLoginViewModel utenteLoginViewModel)
        {
            if(utenteLoginViewModel == null)
            {
                return View();
            }

            var utente=BL.GetAccount(utenteLoginViewModel.Username);
            if(utente != null && ModelState.IsValid)
            {
                if (utente.Password == utenteLoginViewModel.Password)
                {
                    //l'utente è autenticato
                    //claim classe già pronta per momorizzare caratteristiche dell'utente
                    var claim = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, utente.Username),
                        new Claim(ClaimTypes.Role, utente.Ruolo.ToString())
                    };

                    //lista di proprietà
                    var properties = new AuthenticationProperties
                    {
                        RedirectUri = utenteLoginViewModel.ReturnUrl,
                        ExpiresUtc = DateTimeOffset.UtcNow.AddHours(1) //logout dopo un ora di innattività sulla pagina
                    };

                    //identità a partire dai claim,ci permette di creare il nostro profilo
                    var claimIdentity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);

                   await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimIdentity),
                        properties
                        );
                    return Redirect("/");

                }
                else
                {
                    ModelState.AddModelError(nameof(utenteLoginViewModel.Password), "Password Errata");
                    return View(utenteLoginViewModel);
                }
                
            }
            else
            {
                return View(utenteLoginViewModel);
            }
            return View();

        }

        public IActionResult Forbidden() => View();

        public async Task<IActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
        [HttpGet]
        public IActionResult Index()
        {
            //Devo recuperare la lista di corsi dal mio repository,
            List<Utente> utente = BL.GetAllUtente();
            //trasformarla in una lista di corsiViewModel da passare alla vista
            List<UtenteLoginViewModel> utentiViewModel = new List<UtenteLoginViewModel>();
            foreach (var item in utente)
            {
                utentiViewModel.Add(item.ToUtenteViewModel());
            }

            //per visualizzarli in una tabella

            return View(utentiViewModel);
        }
        public IActionResult Details(string id)
        {
            var utente = BL.GetAllUtente().FirstOrDefault(s => s.Username == id);
            var utenteViewModel = utente.ToUtenteViewModel();
            return View(utenteViewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Create(UtenteLoginViewModel utenteloginViewModel)
        {
            if (ModelState.IsValid)
            {
                //dobbiamo aggiungere il corsoViewModel al repository
                Utente utente = utenteloginViewModel.ToUtenteLogin();
                Esito esito = BL.AggiungiUtente(utente);
                if (esito.IsOk == true)
                {
                    //se va tutto a buon fine mi aspetto di tornare nell index e vederlo aggiunto alla tabella
                    return RedirectToAction(nameof(Index)); //tornami l azione che prende il nome di index
                }
                else
                {
                    //mi creo una pagina di Errore e visualizzo un messaggio, lo metto nella Shared perchè la utilizzero per tutto
                    ViewBag.MessaggioErrore = esito.Messaggio;
                    return View("ErroriDiBusiness");
                }
            }
            
            return View(utenteloginViewModel);
        }
        [HttpGet]
        public IActionResult Edit(string id)
        {
            var utente = BL.GetAllUtente().FirstOrDefault(c => c.Username == id);
            var utenteVM = utente.ToUtenteViewModel();
            return View(utenteVM);
        }
        [HttpPost]
        public IActionResult Edit(UtenteLoginViewModel utenteViewModel)
        {
            if (ModelState.IsValid)
            {
                var utente = utenteViewModel.ToUtenteLogin();
                Esito esito = BL.ModificaPasswordUtente(utente.Username, utente.Password);
                if (esito.IsOk == true)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.MessaggioErrore = esito.Messaggio;
                    return View("ErroriDiBusiness");
                }
            }
            return View(utenteViewModel);
        }
        [HttpGet]
        public IActionResult Delete(string id)
        {
            var utente = BL.GetAllUtente().FirstOrDefault(c => c.Username == id);
            var utenteVM = utente.ToUtenteViewModel();
            return View(utenteVM);
        }
        [HttpPost]
        public IActionResult Delete(UtenteLoginViewModel utenteViewModel)
        {
            var utente = utenteViewModel.ToUtenteLogin();
            Esito esito = BL.EliminaUtente(utente.Username);
            if (esito.IsOk == true)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.MessaggioErrore = esito.Messaggio;
                return View("ErroriDiBusiness");
            }

        }
    }


}

