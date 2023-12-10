using DataLayer.Dto.HR;
using ServiceLayer.Services.HR;
using System;
using System.Reflection;
using System.Text;

namespace Presentation
{
    internal class Program
    {
        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]

        public class SensitiveAttribute : Attribute { }
        static void Main(string[] args)
        {
            Service employementService = new Service();


            #region Employed
            //Console.WriteLine("\n--------------- Employed ---------------------\n");

            //foreach (EmployeesViewModelDTo employee in employementService.GetAllEmployees())
            //{

            //    if (employee is not null)
            //    {
            //        PrintGenericProps(employee);
            //    }
            //    else
            //    {
            //        //  Console.WriteLine(employee.Name);
            //        Console.WriteLine($"this Employee {employee.Name} is locked!");

            //    }
            //    // PrintGenericProps(employee);
            //    Console.WriteLine();
            //}
            #endregion

            #region Unemployed
            //Console.ForegroundColor = ConsoleColor.Red;
            //Console.WriteLine("\n--------------- Unemployed ---------------------\n");
            //Console.ResetColor();
            //foreach (EmployeesViewModelDTo employee in employementService.GetAllUnemployed())
            //{

            //    PrintGenericProps(employee);
            //    Console.WriteLine();

            //}
            #endregion


            #region EmployedByID   
            Console.WriteLine("\n--------------- Unemployed BY QUERY ---------------------\n");
            EmployeesViewModelDToReq hRDToReq = new EmployeesViewModelDToReq()
            {
                Age = 18,
                Email = "bruno@gmail",
                CodiceFiscale = "FRRBRN82A14Z602H"
            };
            try
            {
                EmployeesViewModelDTo viewModelDTo = employementService.GetEmployee(hRDToReq);

                if (viewModelDTo?.Errors?.Count > 0)
                {
                    foreach (var error in viewModelDTo.Errors)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(error);
                        Console.ResetColor();
                    }
                }
                else
                {
                    PrintGenericProps(viewModelDTo);
                }
            }
            catch (System.ComponentModel.DataAnnotations.ValidationException ex)
            {
                Console.WriteLine(ex.Message);

            }


            // Console.WriteLine($"Nome: {viewModelDTo?.Name ?? "<None>"}");
            #endregion


            Console.Read();
        }
        public static void PrintGenericProps(object obj)
        {
            if (obj == null) return;

            var sb = new StringBuilder();
            Type objType = obj.GetType();
            PropertyInfo[] properties = objType.GetProperties();

            foreach (var prop in properties)
            {
                object propValue = prop.GetValue(obj, null);
                sb.AppendLine($"{prop.Name}: {propValue}");
            }

            Console.WriteLine(sb.ToString()); ;
        }
    }
}
