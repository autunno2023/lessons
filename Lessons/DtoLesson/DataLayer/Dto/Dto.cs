using DataLayer.Models;

namespace DataLayer.Dto
{

    public class EmployeesViewModelDTo
    {
        public string Name { get; set; }

        public EmployeesViewModelDTo(Employee Employee)
        {
            Name = Employee.Name;
        }
        public EmployeesViewModelDTo()
        {

        }
    }
    public class EmployeesServiceDTo : EmployeesViewModelDTo
    {
        public int Id { get; set; }
        public string Salary { get; set; }
        public string Company { get; set; }
        public bool IsLocked { get; set; }
        public int JobContractId { get; set; }

        internal EmployeesServiceDTo(Employee Employee) : base(Employee)
        {
            Name = Employee.Name;
            JobContractId = Employee.ContactId;

        }
        internal EmployeesServiceDTo()
        {

        }
    }

}
