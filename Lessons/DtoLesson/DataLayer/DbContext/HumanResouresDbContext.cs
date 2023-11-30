using DataLayer.Models;
using System.Collections.Generic;


namespace DataLayer.DbContext
{

    // ORM
    public class HumanResouresDbContext : DbContext
    {
        public List<Employee> Employees { get; set; }
        public List<Jobs> Jobs { get; set; }


        public HumanResouresDbContext(string Path) : base(Path)
        {
            Employees = ReadFromDb<Employee>(Path + typeof(Employee).Name.ToString() + ".csv");
            Jobs = ReadFromDb<Jobs>(Path + typeof(Jobs).Name.ToString() + ".csv"); // -> Api +  Oracle + SVC 
        }
    }
}
