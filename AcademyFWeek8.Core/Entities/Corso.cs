using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyFWeek8.Core.Entities
{
    public class Corso
    {
        public string CorsoCodice { get; set; }
        public string Nome { get; set; }
        public string Descrizione { get; set; }
        public ICollection<Studente> Studenti { get; set; } = new List<Studente>();
        public ICollection<Lezione> Lezioni { get; set; } = new List<Lezione>();


        public override string ToString()
        {
            return $"{CorsoCodice}\t{Nome}\t{Descrizione}";
        }
    }
}
