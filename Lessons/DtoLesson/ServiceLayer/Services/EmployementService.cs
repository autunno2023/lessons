using DataLayer.DbContext;
using DataLayer.Dto;
using DataLayer.Models;
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
        public List<EmployeesViewModelDTo> GetAllEmployees()
        {
            return DbContext.GetEmployees.Select(i => new EmployeesViewModelDTo(i)).ToList();
            /// return DbContext.GetEmployees.Select(i => i).Cast<EmployeesViewModelDTo>().ToList();
        }
        public List<EmployeesViewModelDTo> GetAllUnemployed()
        {
            //return DbContext.GetEmployees
            //    .Where(i => i.Salary == 0).Select(i => new EmployeesViewModelDTo(i)).ToList(); 
            return null;

        }
        public EmployeesViewModelDTo GetEmployee(int Id)
        {
            //return new EmployeesViewModelDTo(DbContext.employeesServiceDTos
            // .FirstOrDefault(i => i.Id == Id)); 
            return null;
        }
        public EmployeesViewModelDTo GetEmployeeAndContracts(int Id)
        {

            //EmployeesServiceDTo employeesServiceDTo = DbContext.employeesServiceDTos.Where(i => i.Id == Id).FirstOrDefault();

            //if (CheckAccount(employeesServiceDTo))
            //    return new EmployeesViewModelDTo(employeesServiceDTo);
            //else
            //    return null; 
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
