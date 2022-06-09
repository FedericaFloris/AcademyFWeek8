using AcademyFWeek8.Core.BusinessLayer;
using AcademyFWeek8.Core.Entities;
using AcademyFWeek8.MVC.Helper;
using AcademyFWeek8.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace AcademyFWeek8.MVC.Controllers
{
    public class LezioniController : Controller
    {
        private readonly IBusinessLayer BL;

        public LezioniController(IBusinessLayer bl)
        {
            BL = bl;
        }
        
        public IActionResult Index()
        {
            //Devo reuperare la lista di corsi dal mio repository
            List<Lezione> lezioni = BL.GetAllLezioni();
            //trasformarla in una lista di corsiViewModel da passare alla vista
            List<LezioneViewModel> lezioniViewModels = new List<LezioneViewModel>();
            foreach (var item in lezioni)
            {
                lezioniViewModels.Add(item.ToLezioneViewModel()); //metodo extension
            }
            //per visualizzarli in una tabella

            return View(lezioniViewModels);
        }
        public IActionResult Details(int id)
        {
            var lezione = BL.GetAllLezioni().FirstOrDefault(c => c.LezioneId == id);

            var lezioneViewModel = lezione.ToLezioneViewModel();
            //lezioneViewModel.Docente.Nome = lezione.Docente.Nome;
            //lezioneViewModel.Docente.Cognome = lezione.Docente.Cognome;
            
            return View(lezioneViewModel);
        }
        //Metodo di inserimento
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(LezioneViewModel lezioneViewModel)
        {
            if (ModelState.IsValid)
            {
                //dobbiamo aggiungere il corsoViewModel al repository
                Lezione lezione = lezioneViewModel.ToLezione();
                Esito esito = BL.AggiungiLezione(lezione);
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
            return View(lezioneViewModel);
        }
        //Modifica
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var lezione = BL.GetAllLezioni().FirstOrDefault(C => C.LezioneId == id);
            var lezioneVM = lezione.ToLezioneViewModel();
            return View(lezioneVM);
        }

        [HttpPost]
        public IActionResult Edit(LezioneViewModel lezioneViewModel)
        {
            if (ModelState.IsValid)
            {
                var lezione = lezioneViewModel.ToLezione();
                Esito esito = BL.ModificaAulaLezione(lezione.LezioneId,lezione.Aula);
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
            return View(lezioneViewModel);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var lezione = BL.GetAllLezioni().FirstOrDefault(C => C.LezioneId == id);
            var lezioneVM = lezione.ToLezioneViewModel();
            return View(lezioneVM);
        }

        [HttpPost]
        public IActionResult Delete(LezioneViewModel lezioneViewModel)
        {


            var lezione = lezioneViewModel.ToLezione();
            Esito esito = BL.EliminaLezione(lezione.LezioneId);
            if (esito.IsOk == true)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.MessaggioErrore = esito.Messaggio;
                return View("ErroriDiBusiness");
            }

            return View(lezioneViewModel);
        }
    }
}
