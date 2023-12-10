namespace DataLayer.Models.HR
{
    public class Company : HR
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public Jobs Jobs { get; set; }

    }
}
