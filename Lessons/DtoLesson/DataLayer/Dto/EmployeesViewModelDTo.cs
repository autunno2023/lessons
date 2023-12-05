using DataLayer.Models;

namespace DataLayer.Dto
{
    public class EmployeesViewModelDTo : IEmployeesDTo
    {
        public string? Name { get; set; }
        public int? Id { get; set; }

        public EmployeesViewModelDTo(Employee? Employee)
        {
            Name = Employee?.Name;
            Id = Employee?.Id ?? default(int);
        }

    }

}
