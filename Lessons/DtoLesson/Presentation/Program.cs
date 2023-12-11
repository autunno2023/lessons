using DataLayer.Dto.HR;
using Presentation.Controllers;
using System;

namespace Presentation
{
    internal class Program
    {
        static HRController controllers;

        static void Main(string[] args)
        {
            controllers = new HRController();


            EmployeesViewModelDTo? response = controllers.GetEmployee(
           new EmployeesViewModelDToReq()
           {
               Age = 10,
               Email = "bruno@gmail",
               //  CodiceFiscale = "FRRBRN82A14Z602H"
           });

            if (response?.Errors?.Count > 0)
            {
                foreach (var error in response.Errors)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(error);
                    Console.ResetColor();
                }
            }
            else
            {
                Utility.PrintGenericProps(response);

            }


            Console.Read();
        }

    }
}
