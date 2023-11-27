using DataLayer.Models;
using System;
using System.Collections.Generic;


namespace DataLayer.Db
{
    internal class HrContext : IDisposable
    {
        public List<Employee> Employees { get; set; }
        public List<Jobs> Jobs { get; set; }
        public List<JobContract> JobsContract { get; set; }

        public HrContext(string config)
        {
            //  Employees =  read from File; 
            //  Jobs =  read from File; 
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
