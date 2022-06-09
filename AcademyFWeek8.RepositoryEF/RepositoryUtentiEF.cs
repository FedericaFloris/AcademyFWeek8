using AcademyFWeek8.Core.Entities;
using AcademyFWeek8.Core.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyFWeek8.RepositoryEF
{
    public class RepositoryUtentiEF : IRepositoryUtenti
    {
        //private readonly MasterContext ctx;

        //public RepositoryUtentiEF()
        //{
        //}

        //public RepositoryUtentiEF(MasterContext context)
        //{
        //    ctx = context;
        //}
        public Utente Add(Utente item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Utenti.Add(item);
                ctx.SaveChanges();
            }
            return item;
        }

        public bool Delete(Utente item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Utenti.Remove(item);
                ctx.SaveChanges();
            }
            return true;
        }

        public List<Utente> GetAll()
        {
            using (var ctx = new MasterContext())
            {
                return ctx.Utenti.ToList();

            }
        }

        public Utente GetByUsername(string username)
        {
            using (var ctx = new MasterContext())
            {
                if (string.IsNullOrEmpty(username))
                {
                    return null;
                }
                return ctx.Utenti.FirstOrDefault(u => u.Username == username);
            }
         
            
        }

        public Utente Update(Utente item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Utenti.Update(item);
                ctx.SaveChanges();
            }
            return item;
        }
    }
}
