namespace AcademyFWeek8.MVC.EsempioCounter
{
    public class Counter : ICounter
    {
        private int count = 0;
        public int Count()
        {
            return ++count;
        }
    }
}
