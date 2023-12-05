using DataLayer.Dto;
using DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServiceLayer.Services
{
    public class EmployementService
    {

        static HRRepository _HRrepository;
        static EmployementService instance;
        EmployementService()
        {
            _HRrepository = new HRRepository(@"D:\logs\");
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
            return _HRrepository.GetAllEmployees().Select(i => new EmployeesViewModelDTo(i)).ToList();
        }
        public List<EmployeesViewModelDTo> GetAllUnemployed()
        {
            //return DbContext.GetAllEmployees
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
