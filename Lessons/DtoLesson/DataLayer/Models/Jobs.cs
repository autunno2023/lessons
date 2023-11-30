namespace DataLayer.Models
{
    public class Jobs : HR
    {
        public string Title { get; set; }
        public Company Company { get; set; }
        public JobContract Contract { get; set; }
    }
}
