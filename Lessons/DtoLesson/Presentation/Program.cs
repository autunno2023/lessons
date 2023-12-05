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
            HRService employementService = HRService.GetInstance();


            #region Employed
            Console.WriteLine("\n--------------- Employed ---------------------\n");

            foreach (EmployeesViewModelDTo employee in employementService.GetAllEmployees())
            {

                if (string.IsNullOrEmpty(employee.Error))
                {
                    Console.WriteLine(employee.Name);

                }
                else
                {
                    //  Console.WriteLine(employee.Name);
                    Console.WriteLine($"this Employee {employee.Name} is locked!");

                }
                // PrintGenericProps(employee);
                Console.WriteLine();
            }
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
            HRServiceDToReq hRServiceDToReq = new HRServiceDToReq() { Age = 40, Country = "Italia", Salary = 20000M }
            EmployeesViewModelDTo viewModelDTo = employementService.GetEmployee(hRServiceDToReq);
            PrintGenericProps(viewModelDTo);
            Console.WriteLine($"Nome: {viewModelDTo?.Name ?? "<None>"}");
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
