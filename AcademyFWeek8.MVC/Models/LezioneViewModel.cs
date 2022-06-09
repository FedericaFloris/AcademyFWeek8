using AcademyFWeek8.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace AcademyFWeek8.MVC.Models
{
    public class LezioneViewModel
    {
        
        public int LezioneId { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DataOraInizio { get; set; }
        [Required]

        public int Durata { get; set; }
        public string Aula { get; set; }

        //Fk verso docente
        [Required]

        public int DocenteID { get; set; }
        public DocenteViewModel? Docente { get; set; }// = new DocenteViewModel();

        //Fk verso Corso
        [Required]

        public string CorsoCodice { get; set; }
        public CorsoViewModel? Corso { get; set; }// = new CorsoViewModel();


        public override string ToString()
        {
            return $"Lezione: {LezioneId}\tData:{DataOraInizio}\t Aula: {Aula}\tDurata (in giorni) : {Durata}";
        }
    }
}
