using AcademyFWeek8.Core.BusinessLayer;
using AcademyFWeek8.Core.Entities;
using AcademyFWeek8.MVC.Helper;
using AcademyFWeek8.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AcademyFWeek8.MVC.Controllers
{
    public class StudentiController : Controller
    {
        private readonly IBusinessLayer BL;

        public StudentiController(IBusinessLayer bl)
        {
            BL = bl;
        }
        public IActionResult Index()
        {
            
            

                //Devo reuperare la lista di corsi dal mio repository
                List<Studente> studenti = BL.GetAllStudenti();
                //trasformarla in una lista di corsiViewModel da passare alla vista
                List<StudenteViewModel> studentiViewModels = new List<StudenteViewModel>();
                foreach (var item in studenti)
                {
                    studentiViewModels.Add(item.ToStudenteViewModel()); //metodo extension
                }
                //per visualizzarli in una tabella

                return View(studentiViewModels);
            
        }
        
        public IActionResult Details(int id)
        {
            var studente = BL.GetAllStudenti().FirstOrDefault(c => c.ID == id);
            var studenteViewModel = studente.ToStudenteViewModel();
            return View(studenteViewModel);
        }

        //Metodo di inserimento
        [HttpGet]
        public IActionResult Create()
        {
            LoadViewBag();
            return View();
        }
        [HttpPost]
        public IActionResult Create(StudenteViewModel studenteViewModel)
        {
            if (ModelState.IsValid)
            {
                //dobbiamo aggiungere il corsoViewModel al repository
                Studente studente = studenteViewModel.ToStudente();
                Esito esito = BL.InserisciNuovoStudente(studente);
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
            LoadViewBag();
            return View(studenteViewModel);
        }
        //Modifica
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var studente = BL.GetAllStudenti().FirstOrDefault(c => c.ID == id);
            var studenteVM = studente.ToStudenteViewModel();
            LoadViewBag();
            return View(studenteVM);
        }

        [HttpPost]
        public IActionResult Edit(StudenteViewModel studenteViewModel)
        {
            if (ModelState.IsValid)
            {
                var studente = studenteViewModel.ToStudente();
                Esito esito = BL.ModificaMailStudente(studenteViewModel.ID, studenteViewModel.Email);
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
            LoadViewBag();
            return View(studenteViewModel);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var studente = BL.GetAllStudenti().FirstOrDefault(C => C.ID == id);
            var studenteVM = studente.ToStudenteViewModel();
            return View(studenteVM);
        }
        [HttpPost]
        public IActionResult Delete(StudenteViewModel studenteViewModel)
        {


            var studente = studenteViewModel.ToStudente();
            Esito esito = BL.EliminaStudente(studente.ID);
            if (esito.IsOk == true)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.MessaggioErrore = esito.Messaggio;
                return View("ErroriDiBusiness");
            }

            return View(studenteViewModel);
        }
        private void LoadViewBag()
        {
            ViewBag.TitoloStudio = new SelectList(new[]
            {
                new{Value="M", Text="Master"},
                new{Value="L", Text="Laurea"},
                new{Value="D", Text="Diploma"},
            }.OrderBy(x => x.Text), "Value", "Text");
        }
    }
}
