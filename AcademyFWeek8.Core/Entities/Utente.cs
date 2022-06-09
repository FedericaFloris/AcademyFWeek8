using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyFWeek8.Core.Entities
{
    public class Utente
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
        public Ruolo Ruolo { get; set; }
    }
    public enum Ruolo
    {
        Administrator = 0,
        User=1
    }
}
