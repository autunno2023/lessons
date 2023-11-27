using System;

namespace Presentation
{
    internal class Program
    {

        static EmployeeViewDTO employeeViewDTO;
        //EmployeeDTO employeeDTO;
        static void Main(string[] args)
        {
            employeeViewDTO = new EmployeeViewDTO();
            Console.WriteLine(employeeViewDTO.Company);
            Console.WriteLine(employeeViewDTO.Employee);
            Console.WriteLine(employeeViewDTO.JobTitle);
            ;
        }
    }
}
