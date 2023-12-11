using System.Collections.Generic;
namespace DataLayer.Dto.HR
{
    public class EmployeesViewModelDTo : IEmployeesDTo
    {
        public string? Name { get; set; }
        public int? Id { get; set; }
        public List<string>? Errors;

        public EmployeesViewModelDTo(HRServiceDToRes? Employee)
        {
            Name = Employee?.Name;
            Id = Employee?.Id ?? default;
        }
        public EmployeesViewModelDTo()
        {

        }
    }
    public class EmployeesViewModelDToReq
    {


        //[Required]
        //[Range(18, 65)]
        public int? Age { get; set; }


        //[Required]
        //[EmailAddress]
        public string? Email { get; set; }
        public string? CodiceFiscale { get; set; }
        public EmployeesViewModelDToReq()
        {

        }

    }

}
