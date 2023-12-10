using DataLayer.Models.HR;

namespace DataLayer.Dto.HR
{


    public class HRServiceDToRes : IEmployeesDTo
    {

        public decimal? Salary { get; set; }
        public string? Company { get; set; }
        public bool IsLocked { get; set; }
        public int? JobContractId { get; set; }
        public string? Name { get; set; }
        public int? Id { get; set; }
        public string? Email { get; set; }

        public HRServiceDToRes(Employee? Employee)
        {
            Id = Employee?.Id;
            IsLocked = false;
            Name = Employee?.Name;
            JobContractId = Employee?.ContactId ?? default(int); // In caso di null, restituisce il valore di default del tipo  
            Salary = Employee?.JobContract?.Salary ?? default(decimal);// In caso di null, restituisce il valore di default del tipo  
            Company = Employee?.JobContract?.Jobs?.CompanyName ?? string.Empty;// In caso di null, restituisce il valore di default del tipo  
            Email = Employee?.Email ?? string.Empty;
        }
        public HRServiceDToRes()
        {

        }

    }


}
