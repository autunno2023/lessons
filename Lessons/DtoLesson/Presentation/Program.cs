using DataLayer.Dto;
using ServiceLayer.Services;
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
            EmployementService employementService = EmployementService.GetInstance();



            Console.WriteLine("\n--------------- Employed ---------------------\n");

            foreach (EmployeesViewModelDTo employee in employementService.GetAllEmployees())
            {
                Console.WriteLine(employee.Id);
                Console.WriteLine(employee.Name);
                // PrintEmployeesViewModelDTo(employee);
                Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n--------------- Unemployed ---------------------\n");
            Console.ResetColor();
            foreach (EmployeesViewModelDTo employee in employementService.GetAllUnemployed())
            {
                Console.WriteLine(employee.Id);
                Console.WriteLine(employee.Name);
                // PrintEmployeesViewModelDTo(employee);
                Console.WriteLine();

            }

            //EmployeesViewModelDTo viewModelDTo = employementService.GetEmployee(1);
            //PrintEmployeesViewModelDTo(viewModelDTo);
            //Console.WriteLine($"Nome: {viewModelDTo?.Name ?? "<None>"}");

            Console.Read();
        }
        public static void PrintEmployeesViewModelDTo(object obj)
        {
            if (obj == null) return;

            var sb = new StringBuilder();
            Type objType = obj.GetType();
            PropertyInfo[] properties = objType.GetProperties();

            foreach (var prop in properties)
            {
                // Check for the SensitiveAttribute on each property
                if (Attribute.IsDefined(prop, typeof(SensitiveAttribute)))
                {
                    continue; // Skip this property as it's marked sensitive
                }

                object propValue = prop.GetValue(obj, null);
                sb.AppendLine($"{prop.Name}: {propValue}");
            }

            Console.WriteLine(sb.ToString()); ;
        }
    }
}
