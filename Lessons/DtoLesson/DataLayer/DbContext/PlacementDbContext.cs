using DataLayer.Models;
using System.Collections.Generic;


namespace DataLayer.DbContext
{
    public class PlacementDbContext : DbContext
    {
        public List<JobContract> JobsContract { get; set; }

        public PlacementDbContext(string config) : base(config)
        {
            JobsContract = ReadFromDb<JobContract>(config + typeof(Employee).ToString() + "csv");
        }
    }
}
