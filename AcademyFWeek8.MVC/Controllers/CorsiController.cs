using AcademyFWeek8.Core.BusinessLayer;
using AcademyFWeek8.Core.Entities;
using AcademyFWeek8.MVC.Helper;
using AcademyFWeek8.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AcademyFWeek8.MVC.Controllers
{
    public class CorsiController : Controller
    {
        private readonly IBusinessLayer BL;

        public CorsiController(IBusinessLayer bl)
        {
            BL = bl;
        }
        [HttpGet]
        public IActionResult Index()
        {

            //Devo reuperare la lista di corsi dal mio repository
            List<Corso> corsi = BL.GetAllCorsi();
            //trasformarla in una lista di corsiViewModel da passare alla vista
            List<CorsoViewModel> corsiViewModels = new List<CorsoViewModel>();
            foreach(var item in corsi)
            {
                corsiViewModels.Add(item.ToCorsoViewModel()); //metodo extension
            }
            //per visualizzarli in una tabella
            
            return View(corsiViewModels);
        }
        [HttpGet("Corsi/Details/{codice}")]
        public IActionResult Details(string codice)
        {
           var corso= BL.GetAllCorsi().FirstOrDefault(c => c.CorsoCodice == codice);
            var corsoViewModel = corso.ToCorsoViewModel();
            return View(corsoViewModel);
        }
      //Metodo di inserimento
        [Authorize(Policy="Adm")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Policy = "Adm")]
        [HttpPost]
        public IActionResult Create(CorsoViewModel corsoViewModel)
        {
            if (ModelState.IsValid)
            {
                //dobbiamo aggiungere il corsoViewModel al repository
                Corso corso = corsoViewModel.ToCorso();
               Esito esito= BL.AggiungiCorso(corso);
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
            return View(corsoViewModel);
        }
        //Modifica
        [Authorize(Policy = "Adm")]
        [HttpGet]
        public IActionResult Edit(string id)
        {
            var corso=BL.GetAllCorsi().FirstOrDefault(C => C.CorsoCodice == id);
            var corsoVM = corso.ToCorsoViewModel();
            return View(corsoVM);
        }
        [Authorize(Policy = "Adm")]
        [HttpPost]
        public IActionResult Edit(CorsoViewModel corsoViewModel)
        {
            if (ModelState.IsValid)
            {
                var corso = corsoViewModel.ToCorso();
                Esito esito=BL.ModificaCorso(corso.CorsoCodice, corso.Nome, corso.Descrizione);
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
            return View(corsoViewModel);
        }
        [Authorize(Policy = "Adm")]
        [HttpGet]
        public IActionResult Delete(string id)
        {
            var corso = BL.GetAllCorsi().FirstOrDefault(C => C.CorsoCodice == id);
            var corsoVM = corso.ToCorsoViewModel();
            return View(corsoVM);
        }
        [Authorize(Policy = "Adm")]
        [HttpPost]
        public IActionResult Delete(CorsoViewModel corsoViewModel)
        {
            
            
                var corso = corsoViewModel.ToCorso();
                Esito esito = BL.EliminaCorso(corso.CorsoCodice);
                if (esito.IsOk == true)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.MessaggioErrore = esito.Messaggio;
                    return View("ErroriDiBusiness");
                }
            
            return View(corsoViewModel);
        }
    }
}
