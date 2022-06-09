using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AcademyFWeek8.MVC.Models
{
    public class CorsoViewModel
    {
        [DisplayName("Codice Corso")] //nome visualizato nella pagina web
        [Required(ErrorMessage = "Campo Obbligatorio")] //campo obligatorio con messaggio personalizzato
        public string CorsoCodice { get; set; }
        [Required]
        public string Nome { get; set; }
        public string Descrizione { get; set; }
        public ICollection<StudenteViewModel> Studenti { get; set; } = new List<StudenteViewModel>();
        


        public override string ToString()
        {
            return $"{CorsoCodice}\t{Nome}\t{Descrizione}";
        }
    }
}
