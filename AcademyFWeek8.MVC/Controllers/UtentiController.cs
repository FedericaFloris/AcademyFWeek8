using AcademyFWeek8.Core.BusinessLayer;
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

      
    }
}
