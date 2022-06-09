using AcademyFWeek8.Core.Entities;
using AcademyFWeek8.MVC.Models;

namespace AcademyFWeek8.MVC.Helper
{
    public static class Mapping //serve per fare la traduzione
    {
        //Quando hai una classe in comune e non puoi modificarla posso aggiungere un metodo di istanza
        //che serve solo a me senza intaccare la classe e che non serve agli altri si usa:
        //ExtentionMethod 
        //public static string SalutaTutti(this Pippo p)
        //{
        //    return $"Ciao mi chiamo {p.Nome} e saluto tutti";
        //}

        public static CorsoViewModel ToCorsoViewModel(this Corso corso)
        {
            //questa ci serve per mettere dentro studenti una lista di studentiviewmodel presa da studente
            List<StudenteViewModel> studentiViewModel = new List<StudenteViewModel>();
            
            foreach(var item in corso.Studenti)
            {
                studentiViewModel.Add(item?.ToStudenteViewModel()); //il ?nel caso che la lista sia vuota
            }
            return new CorsoViewModel
            {
                CorsoCodice = corso.CorsoCodice,
                Descrizione = corso.Descrizione,
                Nome = corso.Nome,
                Studenti= studentiViewModel,
            };
        }

        public static StudenteViewModel ToStudenteViewModel(this Studente studente)
        {
            return new StudenteViewModel()
            {
                ID = studente.ID,
                Nome = studente.Nome,
                Cognome = studente.Cognome,
                Email = studente.Email,
                TitoloStudio = studente.TitoloStudio,
                DataNascita = studente.DataNascita,
                CorsoCodice = studente.CorsoCodice
            };
        }

        public static DocenteViewModel ToDocenteViewModel(this Docente docente)
        {
            List<LezioneViewModel> lezioneViewModel = new List<LezioneViewModel>();
            foreach(var item in docente.Lezioni)
            {
                lezioneViewModel.Add(item?.ToLezioneViewModel());
            }
            return new DocenteViewModel()
            {
                ID = docente.ID,
                Nome = docente.Nome,
                Cognome = docente.Cognome,
                Email = docente.Email,
                Telefono = docente.Telefono,
                Lezioni = lezioneViewModel,
            };
        }

        public static LezioneViewModel ToLezioneViewModel(this Lezione lezione)
        {
            return new LezioneViewModel()
            {
                LezioneId = lezione.LezioneId,
                DataOraInizio = lezione.DataOraInizio,
                Durata = lezione.Durata,
                Aula = lezione.Aula,
                //Docente = lezione.Docente.ToDocenteViewModel(),
                DocenteID = lezione.DocenteID,
                //Corso = lezione.Corso.ToCorsoViewModel(),
                CorsoCodice = lezione.CorsoCodice,
            };
        }
        public static UtenteLoginViewModel ToUtenteViewModel(this Utente utente)
        {
            return new UtenteLoginViewModel()
            {
                id = utente.Id,
                Username = utente.Username,
                Password = utente.Password,
                ReturnUrl = utente.ReturnUrl,
                Ruolo = utente.Ruolo,

            };
        }

        public static Corso ToCorso(this CorsoViewModel corsoViewModel)
        {
            List<Studente> studenti = new List<Studente>();
            foreach (var item in corsoViewModel.Studenti)
            {
                studenti.Add(item?.ToStudente()); 
            }
            return new Corso
            {
                CorsoCodice = corsoViewModel.CorsoCodice,
                
                Descrizione = corsoViewModel.Descrizione,
                Nome = corsoViewModel.Nome,
                Studenti = studenti
            };
        }

        public static Studente ToStudente(this StudenteViewModel studenteViewModel)
        {
            return new Studente()
            {
                ID = studenteViewModel.ID,
                Nome = studenteViewModel.Nome,
                Cognome = studenteViewModel.Cognome,
                Email = studenteViewModel.Email,
                TitoloStudio = studenteViewModel.TitoloStudio,
                DataNascita = studenteViewModel.DataNascita,
                CorsoCodice = studenteViewModel.CorsoCodice
            };
        }
        public static Docente ToDocente(this DocenteViewModel docenteViewModel)
        {
            List<Lezione> lezioni = new List<Lezione>();
            foreach (var item in docenteViewModel.Lezioni)
            {
                lezioni.Add(item?.ToLezione());
            }
            return new Docente()
            {
                ID = docenteViewModel.ID,
                Nome = docenteViewModel.Nome,
                Cognome = docenteViewModel.Cognome,
                Email = docenteViewModel.Email,
                Telefono = docenteViewModel.Telefono,
                Lezioni = lezioni
                

                
            };
        }
        public static Utente ToUtenteLogin(this UtenteLoginViewModel utenteLoginViewModel)
        {
           
            return new Utente()
            {
               Id = utenteLoginViewModel.id,
               Username = utenteLoginViewModel.Username,
               Password = utenteLoginViewModel.Password,    
               ReturnUrl = utenteLoginViewModel.ReturnUrl,
               Ruolo=utenteLoginViewModel.Ruolo,



            };
        }

        public static Lezione ToLezione(this LezioneViewModel lezioneViewModel)
        {
            return new Lezione()
            {
                LezioneId = lezioneViewModel.LezioneId,
                DataOraInizio = lezioneViewModel.DataOraInizio,
                Durata = lezioneViewModel.Durata,
                Aula = lezioneViewModel.Aula,
                //Docente= lezioneViewModel.Docente.ToDocente(),
                DocenteID = lezioneViewModel.DocenteID,
                //Corso = lezioneViewModel.Corso.ToCorso(),
                CorsoCodice= lezioneViewModel.CorsoCodice,
            };
        }

    }
}
