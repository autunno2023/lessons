using DataLayer.Models;
using System;
using System.Collections.Generic;


namespace DataLayer.Db
{
    internal class HumanResourceContext : IDisposable
    {
        public List<Employee> Employees { get; set; }
        public List<Jobs> Jobs { get; set; }
        public List<JobContract> JobsContract { get; set; }

        public HumanResourceContext(string config)
        {
            //  Employees =  read from Csv; 
            //  Jobs =  read from File Csv; 
            //  JobsContract =  read from Csv; 
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
