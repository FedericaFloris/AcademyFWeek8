using AcademyFWeek8.Core.Entities;
using AcademyFWeek8.Core.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyFWeek8.RepositoryMOCK
{
    public class RepositoryDocentiMock : IRepositoryDocenti
    {
        public static List<Docente> Docenti = new List<Docente>()
        {
            new Docente
            {
                ID = 1,
                Nome ="Federica",
                Cognome="Floris",
                Email="feflo92@gmail.com",
                Telefono="575757575757"

            },
            new Docente
            {
                ID=2,
                Nome="Maura",
                Cognome="Mereu",
                Email="m.mereu@tiscali.it",
                Telefono="444444444"
            }

        };

        public Docente Add(Docente item)
        {
            if (Docenti.Count == 0)
            {
                item.ID = 1;
            }
            else //se la lista è piena trova l'id più alto e, dopo aver incrementato di 1, lo assegna ad item
            {
                int maxId = 1;
                foreach (var s in Docenti)
                {
                    if (s.ID > maxId)
                    {
                        maxId = s.ID;
                    }
                }
                item.ID = maxId + 1;
            }
            Docenti.Add(item);
            return item;
        }

        public bool Delete(Docente item)
        {
            Docenti.Remove(item);
            return true;
        }

        public List<Docente> GetAll()
        {
            return Docenti;
        }

        public Docente GetById(int id)
        {
            foreach (var item in Docenti)
            {
                if (item.ID == id)
                {
                    return item;
                }
            }
            return null;
        }

        public Docente Update(Docente item)
        {
            foreach (var s in Docenti)
            {
                if (s.ID == item.ID)
                {
                    s.Telefono = item.Telefono;
                    return s;
                }
            }
            return null;
        }
    }
}
