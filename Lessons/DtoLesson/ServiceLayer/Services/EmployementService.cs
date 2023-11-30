using DataLayer.DbContext;
using DataLayer.Dto;
using DataLayer.Models;
using ServiceLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServiceLayer.Services
{
    public class EmployementService
    {

        static HumanResouresDbContext DbContext;
        static EmployementService instance;
        EmployementService()
        {
            DbContext = new HumanResouresDbContext(@"D:\logs\");
        }

        public static EmployementService GetInstance()
        {
            if (instance is null)
            {
                instance = new EmployementService();
            }
            return instance;
        }
        public List<Employee> GetAllEmployees()
        {
            return DbContext.Employees.ToList();
        }
        public List<Employee> GetAllUnemployed()
        {
            return GetAllEmployees().Where(i => i.JobContractId is 0).ToList();
        }
        public EmployeesViewModelDTo GetEmployee(int Id)
        {
            return new EmployeesServiceDTo(GetAllEmployees().Where(i => i.Id == Id).FirstOrDefault());
        }
        public EmployeesViewModelDTo GetEmployeeAndContracts(int Id)
        {
            // Trasformo Il mio oggetto Employee in Dto EmployeesServiceDTo.
            // (Solo dismostrattivo. Questo esemio in realtà inutile poiche ho sempre accesso diretto all'aggetto 'Employee')
            EmployeesServiceDTo employeesServiceDTo = new EmployeesServiceDTo(GetAllEmployees().Where(i => i.Id == Id).FirstOrDefault());

            if (CheckAccount(employeesServiceDTo))
                return employeesServiceDTo;
            else
                return null;
        }
        public static List<Jobs> GetAllJobs()
        {
            return DbContext.Jobs.ToList();
        }
        public Jobs GetJob(string Title)
        {
            return GetAllJobs().Where(i => i.Title == Title).FirstOrDefault();
        }
        private static bool CheckAccount(EmployeesServiceDTo employees)
        {
            if (employees.IsLocked)
            {
                Console.WriteLine($"Log:User {employees.Id} is Locker ");
                return false;
            }
            return true;
        }


    }

}
