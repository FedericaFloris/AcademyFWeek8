using AcademyFWeek8.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyFWeek8.Core.BusinessLayer
{
    public interface IBusinessLayer
    {
        //Elenco dei metodi/funzionalità esposte
        List<Corso> GetAllCorsi();
        Esito AggiungiCorso(Corso nuovoCorso);
        Esito ModificaCorso(string? codice, string? nuovoNome, string? nuovaDescrizione);
        Esito EliminaCorso(string? codice);
        List<Studente> GetAllStudenti();
        Esito InserisciNuovoStudente(Studente nuovoStudente);
        Esito ModificaMailStudente(int idStudenteDaModificare, string? nuovaEmail);
        Esito EliminaStudente(int idStudenteDaEliminare);
        List<Studente> GetStudentiByCorsoCodice(string? codiceCorso);

        List<Docente> GetAllDocente();
        Esito AggiungiDocente(Docente nuovoDocente);
        Esito ModificaTelefonoDocente(int idDocenteDaModificare, string nuovoNumeroTel);
        Esito EliminaDocente(int idDocenteDaModificare);

        List<Lezione> GetAllLezioni();
        Esito AggiungiLezione(Lezione nuovaLezione);
        Esito ModificaAulaLezione(int idLezioneDaModificare, string nuovaAula);
        Esito EliminaLezione(int idLezioneDaEliminare);

        List<Utente> GetAllUtente();
        public Utente GetAccount(string username);

        Esito AggiungiUtente(Utente nuovoUtente);

        Esito ModificaPasswordUtente(string usernameDaModificare, string nuovaPassword);
        Esito EliminaUtente(string utenteDaEliminare);
    }
}
