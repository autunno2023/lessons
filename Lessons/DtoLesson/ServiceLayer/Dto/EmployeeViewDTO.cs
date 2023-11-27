namespace ServiceLayer.Dto
{
    public class EmployeeViewDTO : HRDto
    {
        internal string Employee { get; set; }
        internal string JobTitle { get; set; }
        internal string Company { get; set; }
        public EmployeeViewDTO(EmployeeResponseDTO employeeDTOs)
        {
            Employee = employeeDTOs.EmployeeFullName;
            JobTitle = employeeDTOs.JobTitle;
            Company = employeeDTOs.Company;
        }
    }
}
