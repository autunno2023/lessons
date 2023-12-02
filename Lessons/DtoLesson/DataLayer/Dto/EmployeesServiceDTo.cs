using DataLayer.Models;

namespace DataLayer.Dto
{


    public class EmployeesServiceDTo : IEmployeesDTo
    {
        public EmployeesViewModelDTo ViewModel { get; set; }

        public decimal? Salary { get; set; }
        public string? Company { get; set; }
        public bool? IsLocked { get; set; }
        public int? JobContractId { get; set; }
        public string? Name { get; set; }
        public int? Id { get; set; }
        internal EmployeesServiceDTo(Employee? Employee)
        {
            Id = Employee?.Id;
            IsLocked = false;
            Name = Employee?.Name;
            JobContractId = Employee?.ContactId ?? default(int);
            Salary = Employee?.JobContract?.Salary ?? default(decimal);
            Company = Employee?.JobContract?.Jobs?.CompanyName ?? string.Empty;

        }

    }

}
