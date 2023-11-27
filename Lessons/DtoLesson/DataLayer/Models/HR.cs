using ServiceLayer;

namespace DataLayer.Models
{

    public abstract class HR
    {

    }
    public class Employee : HR
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public County County { get; set; }
        public Jobs Jobs { get; set; }

    }

    public class Jobs : HR
    {
        public string Title { get; set; }
        public string Company { get; set; }
        public JobContract Contract { get; set; }
    }
    public class JobContract : HR
    {
        string Id { get; set; }
        public decimal salary = 1800M;
        public string Company { get; set; }
    }
}
