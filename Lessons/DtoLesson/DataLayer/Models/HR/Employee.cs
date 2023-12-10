namespace DataLayer.Models.HR
{
    public class Employee : HR
    {

        public int Id { get; set; }
        public string? Name { get; set; }
        public int ContactId { get; set; }
        public bool IsLocked { get; set; }
        public int JobContractId { get; set; }
        public string? SocialNumber { get; set; }
        public string? Email { get; set; }
        public JobContract? JobContract { get; set; }

    }

}
