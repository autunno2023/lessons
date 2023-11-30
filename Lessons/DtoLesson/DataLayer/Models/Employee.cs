namespace DataLayer.Models
{
    public class Employee : HR
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ContactId { get; set; }
        public int JobContractId { get; set; }

    }
    public enum County
    {
        IT,
        DE,
        UK,
        FR,
        ES,
        PT,
        PL,
        DK,
        SE,
        CH
    }
}
