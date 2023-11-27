﻿namespace ServiceLayer.Dto
{
    public class EmployeeViewDTO : HRDto
    {
        public string Employee { get; set; }
        public string JobTitle { get; set; }
        public string Company { get; set; }
        internal EmployeeViewDTO(EmployeeResponseDTO employeeDTOs)
        {
            Employee = employeeDTOs.EmployeeFullName;
            JobTitle = employeeDTOs.JobTitle;
            Company = employeeDTOs.Company;
        }
    }
}
