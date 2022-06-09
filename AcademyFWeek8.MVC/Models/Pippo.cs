namespace AcademyFWeek8.MVC.Models
{
    public class Pippo
    {
        public string Nome { get; set; }

        public string Saluta()
        {
            return $"Ciao mi chiamo {Nome}";
        }

        public string SalutaTutti()
        {
            return $"Ciao mi chiamo {Nome}";
        }
    }
}
