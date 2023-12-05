using DataLayer.Models;

namespace DataLayer.Dto
{


    public class HRServiceDToRes : IEmployeesDTo
    {

        public decimal? Salary { get; set; }
        public string? Company { get; set; }
        public bool IsLocked { get; set; }
        public int? JobContractId { get; set; }
        public string? Name { get; set; }
        public int? Id { get; set; }
        internal HRServiceDToRes(Employee? Employee)
        {
            Id = Employee?.Id;
            IsLocked = false;
            Name = Employee?.Name;
            JobContractId = Employee?.ContactId ?? default(int); // In caso di null, restituisce il valore di default del tipo  
            Salary = Employee?.JobContract?.Salary ?? default(decimal);// In caso di null, restituisce il valore di default del tipo  
            Company = Employee?.JobContract?.Jobs?.CompanyName ?? string.Empty;// In caso di null, restituisce il valore di default del tipo  

        }
    }
    public class HRServiceDToReq
    {
        public decimal? Salary { get; set; }
        public string? Country { get; set; }
        public int? Age { get; set; }

    }

}
