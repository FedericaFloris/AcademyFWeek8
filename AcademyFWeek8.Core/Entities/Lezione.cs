using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyFWeek8.Core.Entities
{
    public class Lezione
    {
        public int LezioneId { get; set; }
        public DateTime DataOraInizio { get; set; }
        public int Durata { get; set; }
        public string Aula { get; set; }

        //Fk verso docente
        public int DocenteID { get; set; }
        public Docente Docente { get; set; }

        //Fk verso Corso
        public string CorsoCodice { get; set; }
        public Corso Corso { get; set; }


        public override string ToString()
        {
            return $"Lezione: {LezioneId}\tData:{DataOraInizio}\t Aula: {Aula}\tDurata (in giorni) : {Durata}";
        }
    }
}
