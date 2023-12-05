using DataLayer.Dto;
using DataLayer.Models;
using DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServiceLayer.Services
{
    public class HRService
    {

        readonly HRRepository<Employee, HRServiceDToReq, HRServiceDToRes> _HRrepository;

        static HRService instance;
        HRService()
        {
            _HRrepository = new HRRepository<Employee, HRServiceDToReq, HRServiceDToRes>(@"D:\logs\");
        }
        public static HRService GetInstance()
        {
            if (instance is null)
            {
                instance = new HRService();
            }
            return instance;
        }
        public List<EmployeesViewModelDTo> GetAllEmployees(int page)
        {

            var Result = _HRrepository.GetAllEmployees().Select(i => new EmployeesViewModelDTo(i)).ToList();

            ///  Se tutte le utenze sono libere, allora ritorna true;   
            ///    

            foreach (var item in _HRrepository.GetAllEmployees())
            {
                if (item.IsLocked)
                {
                    //EmployeesViewModelDTo response = new EmployeesViewModelDTo()
                    //{
                    //    Error = "Non tutti gli utenti sono abilitati!",
                    //};  
                    new HRCustomException("Non tutti gli utenti sono abilitati!");
                }
            }

            if (_HRrepository.GetAllEmployees().Count > 10)
            {
                int result = _HRrepository.GetAllEmployees().Count / page;
            }
        }
        public List<EmployeesViewModelDTo> GetAllUnemployed()
        {
            //return DbContext.GetAllEmployees
            //    .Where(i => i.Salary == 0).Select(i => new EmployeesViewModelDTo(i)).ToList(); 
            return null;

        }
        public EmployeesViewModelDTo GetEmployee(HRServiceDToReq hRServiceDToReq)
        {
            return new EmployeesViewModelDTo(_HRrepository.GetByName(hRServiceDToReq)
             .FirstOrDefault(i => i.Id == Id));
            return null;
        }
        public EmployeesViewModelDTo GetEmployeeyId(int Id)
        {
            return new EmployeesViewModelDTo(_HRrepository.GetByName(hRServiceDToReq)
             .FirstOrDefault(i => i.Id == Id));
            return null;
        }
        //public EmployeesViewModelDTo GetEmployeeAndContracts(int Id)
        //{

        //    //EmployeesServiceDTo employeesServiceDTo = DbContext.employeesServiceDTos.Where(i => i.Id == Id).FirstOrDefault();

        //    //if (CheckAccount(employeesServiceDTo))
        //    //    return new EmployeesViewModelDTo(employeesServiceDTo);
        //    //else
        //    //    return null; 
        //    return null;
        //}
        //private static bool CheckAccount(EmployeesServiceDTo employees)
        //{
        //    if (employees.IsLocked)
        //    {
        //        Console.WriteLine($"Log:User {employees.Id} is Locker ");
        //        return false;
        //    }
        //    return true;
        //}


    }

    public class HRCustomException : Exception
    {
        public HRCustomException(string msg) : base(msg)
        {

        }
    }

}
