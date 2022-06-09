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
    public class RepositoryDocentiEF : IRepositoryDocenti
    {
        public Docente Add(Docente item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Docenti.Add(item);
                ctx.SaveChanges();
            }
            return item;
        }

        public bool Delete(Docente item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Docenti.Remove(item);
                ctx.SaveChanges();
            }
            return true;
        }

        public List<Docente> GetAll()
        {
            using (var ctx = new MasterContext())
            {
                return ctx.Docenti.Include(c => c.Lezioni).ToList();

            }
        }

        public Docente GetById(int id)
        {
            using (var ctx = new MasterContext())
            {
                return ctx.Docenti.Include(x => x.Lezioni).FirstOrDefault(s => s.ID == id);
            }
        }

        public Docente Update(Docente item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Docenti.Update(item);
                ctx.SaveChanges();
            }
            return item;
        }
    }
}
