using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyFWeek8.Core.Entities
{
    public class Docente: Persona
    {
        public string Telefono { get; set; }
        public ICollection<Lezione> Lezioni { get; set; } = new List<Lezione>();

        public override string ToString()
        {
            return base.ToString()+ $"\t tel.{Telefono}";
        }
    }
}
