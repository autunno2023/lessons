using DataLayer.Models;

namespace ServiceLayer.Dto
{
    public class HRViewModelDto
    {

        public string Employee { get; set; }
        public string JobTitle { get; set; }
        public string Company { get; set; }

        public HRViewModelDto(Employee employee)
        {
            Employee = employee.Name;
            JobTitle = employee.Jobs.Title;
            Company = employee.Jobs.Company;
        }
    }
}
