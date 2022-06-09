using AcademyFWeek8.Core.BusinessLayer;
using AcademyFWeek8.Core.Entities;
using AcademyFWeek8.MVC.Helper;
using AcademyFWeek8.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace AcademyFWeek8.MVC.Controllers
{
    public class DocentiController : Controller
    {
        private readonly IBusinessLayer BL;
        public DocentiController(IBusinessLayer bl)
        {
            BL = bl;
        }
        [HttpGet]
        public IActionResult Index()
        {
            //Devo recuperare la lista di corsi dal mio repository,
            List<Docente> docenti = BL.GetAllDocente();
            //trasformarla in una lista di corsiViewModel da passare alla vista
            List<DocenteViewModel> docentiViewModel = new List<DocenteViewModel>();
            foreach (var item in docenti)
            {
                docentiViewModel.Add(item.ToDocenteViewModel());
            }

            //per visualizzarli in una tabella

            return View(docentiViewModel);
        }
        public IActionResult Details(int id)
        {
            var docente = BL.GetAllDocente().FirstOrDefault(s => s.ID == id);
            var docenteViewModel = docente.ToDocenteViewModel();
            return View(docenteViewModel);
        }
        //Crea nuovo docente
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DocenteViewModel docenteViewModel)
        {
            if (ModelState.IsValid)
            {
                //dobbiamo aggiungere il corsoViewModel al repository
                Docente docente = docenteViewModel.ToDocente();
                Esito esito = BL.AggiungiDocente(docente);
                if (esito.IsOk == true)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    //visualizzo il messaggio d'errore in una pagina
                    ViewBag.MessaggioErrore = esito.Messaggio;
                    return View("ErroriDiBusiness");
                }
            }
            return View(docenteViewModel);
        }
        //Modifica
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var docente = BL.GetAllDocente().FirstOrDefault(c => c.ID == id);
            var docenteVM = docente.ToDocenteViewModel();
            return View(docenteVM);
        }
        [HttpPost]
        public IActionResult Edit(DocenteViewModel docenteViewModel)
        {
            if (ModelState.IsValid)
            {
                var docente = docenteViewModel.ToDocente();
                Esito esito = BL.ModificaTelefonoDocente(docente.ID,docente.Telefono);
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
            return View(docenteViewModel);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var docente = BL.GetAllDocente().FirstOrDefault(c => c.ID == id);
            var docenteVM = docente.ToDocenteViewModel();
            return View(docenteVM);
        }
        [HttpPost]
        public IActionResult Delete(DocenteViewModel docenteViewModel)
        {
            var docente = docenteViewModel.ToDocente();
            Esito esito = BL.EliminaDocente(docente.ID);
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
