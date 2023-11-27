namespace DataLayer.Models
{
    public class JobContract : HR
    {
        string Id { get; set; }
        public decimal salary = 1800M;
        public string Company { get; set; }
    }
}
