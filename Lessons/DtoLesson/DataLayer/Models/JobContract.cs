namespace DataLayer.Models
{
    public class JobContract : HR
    {
        public int Id { get; set; }
        public decimal salary = 1800M;
        public string Company { get; set; }
    }
}
