namespace DataLayer.Models
{
    public class Employee : HR
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int ContactId { get; set; }
        public int JobContractId { get; set; }
        public string SocialNumber { get; set; }
        public JobContract JobContract { get; set; }

    }

}
