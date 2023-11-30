using DataLayer.Dto;
using DataLayer.Models;

namespace ServiceLayer.Dto
{
    internal class EmployeesServiceDTo : EmployeesViewModelDTo
    {
        public int Id { get; set; }
        public string Contract { get; set; }
        public string Salary { get; set; }
        public string Company { get; set; }
        public bool IsLocked { get; set; }

        internal EmployeesServiceDTo(Employee Employee) : base(Employee)
        {
            Name = Employee.Name;
        }
    }
}
