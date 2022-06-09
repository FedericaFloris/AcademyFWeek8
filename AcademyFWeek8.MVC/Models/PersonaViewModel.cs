using System.ComponentModel.DataAnnotations;

namespace AcademyFWeek8.MVC.Models
{
    public abstract class PersonaViewModel
    {
        [Required]
        public int ID { get; set; }
        [Required]

        public string Nome { get; set; }
        [Required]

        public string Cognome { get; set; }
        [Required]

        public string Email { get; set; }

        public override string ToString()
        {
            return $"Id: {ID}\t{Nome}\t{Cognome}\tmail: {Email}";
        }
    }
}
