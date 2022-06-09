using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AcademyFWeek8.MVC.Models
{
    public class DocenteViewModel : PersonaViewModel
    {
        [DisplayName("Numero di telefono")]
        [Required]
        public string Telefono { get; set; }
        public ICollection<LezioneViewModel> Lezioni { get; set; } = new List<LezioneViewModel>();

        public override string ToString()
        {
            return base.ToString() + $"\t tel.{Telefono}";
        }
    }
}
