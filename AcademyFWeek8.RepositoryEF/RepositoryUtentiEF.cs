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
            throw new NotImplementedException();
        }

        public bool Delete(Utente item)
        {
            throw new NotImplementedException();
        }

        public List<Utente> GetAll()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
