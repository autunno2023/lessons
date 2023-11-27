using DataLayer.Models;
using System;
using System.Collections.Generic;


namespace DataLayer.DbContext
{
    internal class HumanResourceContext : DbContext, IDisposable
    {
        public List<Employee> Employees { get; set; }
        public List<Jobs> Jobs { get; set; }
        public List<JobContract> JobsContract { get; set; }

        public HumanResourceContext(string config) : base(config)
        {
            Employees = ReadFromDb<Employee>("");
            Jobs = ReadFromDb<Jobs>("");
            JobsContract = ReadFromDb<JobContract>("");
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
