using AcademyFWeek8.Core.Entities;
using AcademyFWeek8.Core.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyFWeek8.Core.BusinessLayer
{
    public class MainBusinessLayer : IBusinessLayer
    {
        private readonly IRepositoryCorsi corsiRepo;        
        private readonly IRepositoryStudenti studentiRepo;
        private readonly IRepositoryDocenti docentiRepo;
        private readonly IRepositoryLezioni lezioniRepo;
        private readonly IRepositoryUtenti utentiRepo;


        public MainBusinessLayer(IRepositoryCorsi corsi, IRepositoryStudenti studenti,IRepositoryDocenti docenti,IRepositoryLezioni lezioni, IRepositoryUtenti utenti)
        {
            corsiRepo = corsi;
            studentiRepo = studenti;
            docentiRepo = docenti;
            lezioniRepo = lezioni;
            utentiRepo = utenti;
        }

       
        #region Funzionalità Studenti
        public Esito EliminaStudente(int idStudenteDaEliminare)
        {
            var studenteEsistente = studentiRepo.GetById(idStudenteDaEliminare);
            if (studenteEsistente == null)
            {
                return new Esito { Messaggio = "Nessuno studente corrispondente all'id inserito", IsOk = false };
            }
            studentiRepo.Delete(studenteEsistente);
            return new Esito { Messaggio = "Studente eliminato correttamente", IsOk = true };
        }
        public List<Studente> GetAllStudenti()
        {
            return studentiRepo.GetAll();
        }

        public List<Studente> GetStudentiByCorsoCodice(string codiceCorso)
        {
            //controllo input
            //controllo se codice corso esiste. Se non esiste allora restituisco null
            //se il corso esiste, allora recupero dalla repo degli studenti la lista di quelli che hanno quel corsoCodice
            var corso = corsiRepo.GetByCode(codiceCorso);
            if (corso == null)
            {
                return null;
            }
            List<Studente> studentiFiltrati = new List<Studente>();
            foreach (var item in studentiRepo.GetAll())
            {
                if (item.CorsoCodice == codiceCorso)
                {
                    studentiFiltrati.Add(item);
                }
            }
            return studentiFiltrati;

        }

        public Esito InserisciNuovoStudente(Studente nuovoStudente)
        {
            //controllo input
            Corso corsoEsistente = corsiRepo.GetByCode(nuovoStudente.CorsoCodice);
            if (corsoEsistente == null)
            {
                return new Esito { Messaggio = "Codice corso errato", IsOk = false };
            }
            studentiRepo.Add(nuovoStudente);
            //corsoEsistente.Studenti.Add(nuovoStudente);
            return new Esito { Messaggio = "studente inserito correttamente", IsOk = true };
        }
        public Esito ModificaMailStudente(int idStudenteDaModificare, string nuovaEmail)
        {
            //controllo input
            //controllo se id esiste
            var studente = studentiRepo.GetById(idStudenteDaModificare);
            if (studente == null)
            {
                return new Esito { Messaggio = "Id Studente errato o inesistente", IsOk = false };
            }
            studente.Email = nuovaEmail;
            studentiRepo.Update(studente);
            return new Esito { Messaggio = "Email Studente aggiornata correttamente", IsOk = true };
        }
        #endregion Funzionalità Studenti

        #region Funzionalità Corsi
        public Esito AggiungiCorso(Corso nuovoCorso)
        {
            Corso corsoRecuperato = corsiRepo.GetByCode(nuovoCorso.CorsoCodice);
            if (corsoRecuperato == null)
            {
                corsiRepo.Add(nuovoCorso);
                return new Esito() { IsOk = true, Messaggio = "Corso aggiunto correttamente" };
            }
            return new Esito() { IsOk = false, Messaggio = "Impossibile aggiungere il corso perché esiste già un corso con quel codice" };
        }
        public Esito EliminaCorso(string? codice)
        {
            var corsoRecuperato = corsiRepo.GetByCode(codice);
            if (corsoRecuperato == null)
            {
                return new Esito() { IsOk = false, Messaggio = "Nessun corso corrispondente al codice inserito" };
            }
            corsiRepo.Delete(corsoRecuperato);
            return new Esito() { IsOk = true, Messaggio = "Corso eliminato correttamente" };
        }

        public List<Corso> GetAllCorsi()
        {
            return corsiRepo.GetAll();
        }

        

        public Esito ModificaCorso(string? codice, string? nuovoNome, string? nuovaDescrizione)
        {
            var corsoRecuperato=corsiRepo.GetByCode(codice);
            if(corsoRecuperato == null)
            {
                return new Esito() { IsOk = false, Messaggio = "Nessun corso corrispondente al codice inserito" };
            }
            corsoRecuperato.Nome = nuovoNome;
            corsoRecuperato.Descrizione= nuovaDescrizione;
            corsiRepo.Update(corsoRecuperato);
            return new Esito() { IsOk = true, Messaggio = "Corso aggiornato correttamente" };
        }


        #endregion Funzionalità Corsi

        #region Funzionalità Docenti
        public List<Docente> GetAllDocente()
        {
            return docentiRepo.GetAll();
        }

        public Esito AggiungiDocente(Docente nuovoDocente)
        {
            Docente docenteRecuperato = docentiRepo.GetById(nuovoDocente.ID);
            if (docenteRecuperato == null)
            {
                docentiRepo.Add(nuovoDocente);
                return new Esito() { IsOk = true, Messaggio = "Docente aggiunto correttamente" };
            }
            return new Esito() { IsOk = false, Messaggio = "Impossibile aggiungere il docente" };
        }

        public Esito ModificaTelefonoDocente(int idDocenteDaModificare, string nuovoNumeroTel)
        {
            var docenteRecuperato = docentiRepo.GetById(idDocenteDaModificare);
            if (docenteRecuperato == null)
            {
                return new Esito() { IsOk = false, Messaggio = "Nessun docente corrispondente al codice inserito" };
            }
            docenteRecuperato.Telefono = nuovoNumeroTel;
            
            docentiRepo.Update(docenteRecuperato);
            return new Esito() { IsOk = true, Messaggio = "Docente aggiornato correttamente" };
        }

        public Esito EliminaDocente(int idDocenteDaModificare)
        {
            var docenteRecuperato = docentiRepo.GetById(idDocenteDaModificare);
            if (docenteRecuperato == null)
            {
                return new Esito() { IsOk = false, Messaggio = "Nessun docente corrispondente al codice inserito" };
            }
            docentiRepo.Delete(docenteRecuperato);
            return new Esito() { IsOk = true, Messaggio = "Docente eliminato correttamente" };
        }


        #endregion
        #region Funzionalità Corsi
        public List<Lezione> GetAllLezioni()
        {
            return lezioniRepo.GetAll();
        }

        public Esito AggiungiLezione(Lezione nuovaLezione)
        {
            Lezione lezioneRecuperata = lezioniRepo.GetById(nuovaLezione.LezioneId);
            if (lezioneRecuperata == null)
            {
                lezioniRepo.Add(nuovaLezione);
                return new Esito() { IsOk = true, Messaggio = "Lezione aggiunta correttamente" };
            }
            return new Esito() { IsOk = false, Messaggio = "Impossibile aggiungere la lezione" };
        }

        public Esito ModificaAulaLezione(int idLezioneDaModificare, string nuovaAula)
        {
            Lezione lezioneRecuperata = lezioniRepo.GetById(idLezioneDaModificare);
            if (lezioneRecuperata == null)
            {
                return new Esito() { IsOk = false, Messaggio = "Nessuna lezione corrispondente al codice inserito" };
            }
            lezioneRecuperata.Aula = nuovaAula;

            lezioniRepo.Update(lezioneRecuperata);
            return new Esito() { IsOk = true, Messaggio = "Lezione aggiornata correttamente" };
        }

        public Esito EliminaLezione(int idLezioneDaEliminare)
        {
            var lezioneRecuperata = lezioniRepo.GetById(idLezioneDaEliminare);
            if (lezioneRecuperata == null)
            {
                return new Esito() { IsOk = false, Messaggio = "Nessuna lezione corrispondente al codice inserito" };
            }
            lezioniRepo.Delete(lezioneRecuperata);
            return new Esito() { IsOk = true, Messaggio = "Lezione eliminata correttamente" };
        }
        #endregion
        public Utente GetAccount(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return null;
            }
            return utentiRepo.GetByUsername(username);
        }

        public Esito AggiungiUtente(Utente nuovoUtente)
        {
            Utente utenteRecuperato = utentiRepo.GetByUsername(nuovoUtente.Username);
            if (utenteRecuperato == null)
            {
                utentiRepo.Add(nuovoUtente);
                return new Esito() { IsOk = true, Messaggio = "Utente aggiunto correttamente" };
            }
            return new Esito() { IsOk = false, Messaggio = "Impossibile aggiungere utente" };
        }

        public Esito ModificaPasswordUtente(string utenteDaModificare, string nuovaPassword)
        {
            Utente utenteRecuperato = utentiRepo.GetByUsername(utenteDaModificare);
            if (utenteRecuperato == null)
            {
                return new Esito() { IsOk = false, Messaggio = "Nessun utente corrispondente al codice inserito" };
            }
            utenteRecuperato.Password = nuovaPassword;

            utentiRepo.Update(utenteRecuperato);
            return new Esito() { IsOk = true, Messaggio = "Utente aggiornato correttamente" };
        }

        public Esito EliminaUtente(string utenteDaEliminare)
        {
            var utenteRecuperato = utentiRepo.GetByUsername(utenteDaEliminare);
            if (utenteRecuperato == null)
            {
                return new Esito() { IsOk = false, Messaggio = "Nessun utente corrispondente al codice inserito" };
            }
            utentiRepo.Delete(utenteRecuperato);
            return new Esito() { IsOk = true, Messaggio = "Utente eliminata correttamente" };
        }

        public List<Utente> GetAllUtente()
        {
            return utentiRepo.GetAll();
        }
    }

   
}
