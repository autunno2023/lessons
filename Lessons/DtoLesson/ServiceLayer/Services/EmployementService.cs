using DataLayer.DbContext;
using DataLayer.Models;
using System.Collections.Generic;
using System.Linq;

namespace ServiceLayer.Services
{
    public class EmployementService
    {

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


        static HumanResouresDbContext DbContext;

        public List<Employee> GetAllEmployees()
        {
            return DbContext.Employees.ToList();
        }
        public List<Employee> GetAllUnemployed()
        {
            return GetAllEmployees().Where(i => i.JobContractId is 0).ToList();
        }
        public Employee Get(int Id)
        {
            return GetAllEmployees().Where(i => i.Id == Id).FirstOrDefault();
        }
        public static List<Jobs> GetAllJobs()
        {
            return DbContext.Jobs.ToList();
        }
        public Jobs GetJobs(string Title)
        {
            return GetAllJobs().Where(i => i.Title == Title).FirstOrDefault();
        }
        //public static JobContract GetJobContract(int Id)
        //{
        //    return GetAllJobContract().Where(i => i.Id == Id).FirstOrDefault();
        //}

        //public static List<JobContract> GetAllJobContract()
        //{
        //    return DbContext.JobsContract.ToList();
        //}
    }

}
