using AcademyFWeek8.Core.Entities;
using AcademyFWeek8.Core.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyFWeek8.RepositoryMOCK
{
    public class RepositoryStudentiMock : IRepositoryStudenti
    {
        public static List<Studente> Studenti = new List<Studente>()
        {
            new Studente{
                ID=1,
                Nome="Renata",
                Cognome="Carriero",
                DataNascita=new DateTime(1987,04,01),
                Email="renata@mail.it",
                TitoloStudio="laurea",
                CorsoCodice="C-01"},

            new Studente{
                ID=2,
                Nome="Mario",
                Cognome="Rossi",
                DataNascita=new DateTime(1980,10,10),
                Email="mario@mail.it",
                TitoloStudio="laurea",
                CorsoCodice="C-02"}
        };


        public Studente Add(Studente item)
        {
            if (Studenti.Count == 0)
            {
                item.ID = 1;
            }
            else //se la lista è piena trova l'id più alto e, dopo aver incrementato di 1, lo assegna ad item
            {
                int maxId = 1;
                foreach (var s in Studenti)
                {
                    if (s.ID > maxId)
                    {
                        maxId = s.ID;
                    }
                }
                item.ID = maxId + 1;
            }
            Studenti.Add(item);
            return item;
        }

        public bool Delete(Studente item)
        {
            Studenti.Remove(item);
            return true;
        }

        public List<Studente> GetAll()
        {
            return Studenti;
        }

        public Studente GetById(int id)
        {
            foreach (var item in Studenti)
            {
                if (item.ID == id)
                {
                    return item;
                }
            }
            return null;
        }

        public Studente Update(Studente item)
        {
            foreach (var s in Studenti)
            {
                if (s.ID == item.ID)
                {
                    s.Email = item.Email;
                    return s;
                }
            }
            return null;
        }
    }
}
