using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyFWeek8.Core.Entities
{
    public abstract class Persona
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return $"Id: {ID}\t{Nome}\t{Cognome}\tmail: {Email}";
        }
    }
}
