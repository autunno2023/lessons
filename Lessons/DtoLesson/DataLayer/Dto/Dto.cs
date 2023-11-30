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
    }

}
