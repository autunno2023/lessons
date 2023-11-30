using DataLayer.Models;
using System.Collections.Generic;

namespace ServiceLayer.Contracts
{
    public interface IEmployeePlatform : IHRPlatform
    {
        public List<Employee> GetAll();
        public Employee Get(int Id);

    }
}

