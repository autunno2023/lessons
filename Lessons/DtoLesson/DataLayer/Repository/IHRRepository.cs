using DataLayer.DbContext;
using DataLayer.Dto;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer.Repository
{
    internal interface IHRRepository
    {
        public EmployeesServiceDTo GetEmployee(int Id);
        public List<EmployeesServiceDTo> GetAllEmployee();

    }
    public class HRRepository
    {
        private readonly HumanResouresDbContext Db;

        public HRRepository(string path)
        {
            Db = new HumanResouresDbContext(path);
        }
        public EmployeesServiceDTo? GetEmployee(int Id)
        {
            return Db.GetEmployees.FirstOrDefault(i => i.Id == Id);
        }
        public List<EmployeesServiceDTo> GetAllEmployees()
        {
            return Db.GetEmployees;
        }
    }
}
