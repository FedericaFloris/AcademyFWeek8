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
    public class RepositorylezioniEF : IRepositoryLezioni
    {
        public Lezione Add(Lezione item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Lezioni.Add(item);
                ctx.SaveChanges();
            }
            return item;
        }

        public bool Delete(Lezione item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Lezioni.Remove(item);
                ctx.SaveChanges();
            }
            return true;
        }

        public List<Lezione> GetAll()
        {
            using (var ctx = new MasterContext())
            {
                return ctx.Lezioni.Include(c => c.Docente).Include(c => c.Corso).ToList();

            }
        }

        public Lezione GetById(int id)
        {
            using (var ctx = new MasterContext())
            {
                return ctx.Lezioni.Include(x => x.Docente).Include(x => x.Corso).FirstOrDefault(c => c.LezioneId == id);
            }
        }

        public Lezione Update(Lezione item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Lezioni.Update(item);
                ctx.SaveChanges();
            }
            return item;
        }
    }
}
