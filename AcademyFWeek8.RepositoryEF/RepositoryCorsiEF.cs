using AcademyFWeek8.Core.Entities;
using AcademyFWeek8.Core.InterfaceRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyFWeek8.RepositoryEF
{
    public class RepositoryCorsiEF : IRepositoryCorsi
    {

        public Corso Add(Corso item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Corsi.Add(item);
                ctx.SaveChanges();
            }
            return item;
        }

        public bool Delete(Corso item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Corsi.Remove(item);
                ctx.SaveChanges();
            }
            return true;
        }

        public List<Corso> GetAll()
        {
            using (var ctx = new MasterContext())
            {
                return ctx.Corsi.Include(c => c.Studenti).Include(c => c.Lezioni).ToList();

            }
        }

        public Corso GetByCode(string codice)
        {
            using (var ctx = new MasterContext())
            {
                return ctx.Corsi.Include(x => x.Studenti).Include(x => x.Lezioni).FirstOrDefault(c => c.CorsoCodice == codice);
            }
        }

        public Corso Update(Corso item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Corsi.Update(item);
                ctx.SaveChanges();
            }
            return item;
        }
    }
}
