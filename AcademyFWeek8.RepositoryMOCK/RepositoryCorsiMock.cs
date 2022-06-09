using AcademyFWeek8.Core.Entities;
using AcademyFWeek8.Core.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyFWeek8.RepositoryMOCK
{
    public class RepositoryCorsiMock : IRepositoryCorsi
    {
        private static List<Corso> corsi = new List<Corso>()
        {
            new Corso{CorsoCodice="C-01", Nome= "Pre-Academy F", Descrizione="C# corso base"},
            new Corso{CorsoCodice="C-02", Nome= "Academy F", Descrizione="C# corso avanzato"}
        };

        public Corso Add(Corso item)
        {
            if(item == null)
            {
                return null;
            }
            corsi.Add(item);
            return item;
        }

        public bool Delete(Corso item)
        {
            if (item == null)
            {
                return false;
            }
            corsi.Remove(item);
            return true;
        }

        public List<Corso> GetAll()
        {
            return corsi;
        }

        public Corso GetByCode(string codice)
        {
            foreach (var item in corsi)
            {
                if(item.CorsoCodice == codice)
                {
                    return item;
                }
            }
            return null;
        }

        public Corso Update(Corso item)
        {
            foreach (var c in corsi)
            {
                if (c.CorsoCodice == item.CorsoCodice)
                {
                    c.Nome = item.Nome;
                    c.Descrizione = item.Descrizione;
                    return c;
                }
            }
            return null;
        }
    }
}
