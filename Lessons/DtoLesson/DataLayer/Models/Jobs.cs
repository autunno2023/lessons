namespace DataLayer.Models
{
    public class Jobs : HR
    {
        internal string Title { get; set; }
        internal Company Company { get; set; }
        internal JobContract Contract { get; set; }
    }
}
