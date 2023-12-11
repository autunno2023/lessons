namespace DataLayer.Models.HR
{
    public class Job : HR
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string CompanyName { get; set; }
        public JobContract JobContract { get; set; }

    }
}
