using DataLayer.Models;
using System.Collections.Generic;


namespace DataLayer.DbContext
{
    public class HumanResouresDbContext : DbContext
    {
        public List<Employee> Employees { get; set; }
        public List<Jobs> Jobs { get; set; }


        public HumanResouresDbContext(string config) : base(config)
        {
            Employees = ReadFromDb<Employee>(config + typeof(Employee).Name.ToString() + ".csv");
            // Jobs = ReadFromDb<Jobs>(config + typeof(Employee).ToString() + "csv");

        }
    }
}
