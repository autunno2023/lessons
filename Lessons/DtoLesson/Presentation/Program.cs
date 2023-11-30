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
            foreach (Employee e in employementService.GetAllEmployees())
            {
                Console.WriteLine(e.Name);
            }


        }
    }
}
