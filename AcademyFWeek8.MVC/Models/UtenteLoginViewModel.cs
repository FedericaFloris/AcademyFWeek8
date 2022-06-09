using System.ComponentModel.DataAnnotations;

namespace AcademyFWeek8.MVC.Models
{
    public class UtenteLoginViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required, DataType(DataType.Password)] //ti mette gli asterischi invece dei caratteri
        public string Password { get; set; }    
        public string ReturnUrl { get; set; }
    }
}
