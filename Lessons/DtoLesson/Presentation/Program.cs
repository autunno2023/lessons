using DataLayer.Models;
using Presentation.Dto;
using ServiceLayer.Services;
using System;
using System.Collections.Generic;

namespace Presentation
{
    internal class Program
    {

        static List<EmployeeViewDTO> employeeViewDTOs;
        //EmployeeDTO employeeDTO;
        static void Main(string[] args)
        {
            employeeViewDTOs = new EmployeeService().GetAllEmployees();
            employeeViewDTOs = new HRServices<Employee, EmployeeServiceDTO, EmployeeViewDTO>().GetAll();
            foreach (var employeeViewDTO in employeeViewDTOs)
            {
                Console.WriteLine(employeeViewDTO.Company);
                Console.WriteLine(employeeViewDTO.Employee);
                Console.WriteLine(employeeViewDTO.JobTitle);

            }

        }
    }
}
