using DataLayer.Models;

namespace DataLayer.Dto
{


    public class EmployeesServiceDTo : EmployeesViewModelDTo
    {
        public EmployeesViewModelDTo ViewModel { get; set; }

        public decimal? Salary { get; set; }
        public string? Company { get; set; }
        public bool IsLocked { get; set; }
        public int? JobContractId { get; set; }
        public string? Name { get; set; }
        public int? Id { get; set; }
        internal EmployeesServiceDTo(Employee? Employee) : base(Employee)
        {
            Id = Employee?.Id;
            IsLocked = false;
            Name = Employee?.Name;
            JobContractId = Employee?.ContactId ?? default(int); // In caso di null, restituisce il valore di default del tipo  
            Salary = Employee?.JobContract?.Salary ?? default(decimal);// In caso di null, restituisce il valore di default del tipo  
            Company = Employee?.JobContract?.Jobs?.CompanyName ?? string.Empty;// In caso di null, restituisce il valore di default del tipo  

        }
    }
}
