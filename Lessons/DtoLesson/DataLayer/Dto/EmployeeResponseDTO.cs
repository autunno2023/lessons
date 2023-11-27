﻿using DataLayer.Models;

namespace ServiceLayer.Dto
{
    public class HRDto
    {

    }
    public class EmployeeResponseDTO : HRDto
    {
        internal int id;
        internal string firstName;
        internal string lastName;
        internal string email;
        internal Company company;

        public string Name { get { return firstName; } }
        public string EmployeeFullName { get { return firstName + " " + lastName; } }
        public string JobTitle { get { return firstName + " " + lastName; } }
        public string Company { get { return company.Email; } }

        internal EmployeeResponseDTO(Employee employee)
        {
            firstName = employee.Name;
            lastName = employee.lastName;
            email = employee.Contacts.Email;
            company = employee.Jobs.Company;
        }
    }
}
