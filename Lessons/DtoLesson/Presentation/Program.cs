using DataLayer.Dto;
using DataLayer.Models;
using ServiceLayer.Services;
using System;

namespace Presentation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EmployementService employementService = EmployementService.GetInstance();




            foreach (Employee employee in employementService.GetAllEmployees())
            {
                Console.Write($"Nome:{employee.Name} | SocialNumber: {employee.SocialNumber}");
                Console.WriteLine();
            }

            Console.WriteLine("\n--------------- Unemployed ---------------------\n");
            foreach (Employee employee in employementService.GetAllUnemployed())
            {
                Console.Write($"Nome:{employee.Name} | SocialNumber: {employee.SocialNumber}");
                Console.WriteLine();

            }



            //#region 
            EmployeesViewModelDTo viewModelDTo = employementService.GetEmployee(1);
            Console.WriteLine($"Nome:" + viewModelDTo.Name);



            Console.Read();




        }
    }
}
