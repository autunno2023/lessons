using DataLayer.DbContext;
using DataLayer.Models.HR;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer.Repository
{
    public class HRRepository<TResponse, TRequest> : IRepository<TResponse, TRequest>
    //where T : HR, new()
    where TResponse : class, new()
    {
        private readonly GenericDbContext<TResponse> Db;
        List<Employee> Employees;
        List<JobContract> JobContracts;
        List<Job> Jobs;
        public HRRepository(string path)
        {
            Db = new GenericDbContext<TResponse>(path);
            Employees = Db.ReadFromDb<Employee>(path + typeof(Employee).Name.ToString() + ".csv");
            JobContracts = Db.ReadFromDb<JobContract>(path + typeof(JobContract).Name.ToString() + ".csv");
            Jobs = Db.ReadFromDb<Job>(path + typeof(Job).Name.ToString() + ".csv");
            MergerData();
        }
        private void MergerData()
        {
            foreach (var employee in Employees)
            {
                JobContract? jobsContracts =
                    JobContracts.FirstOrDefault(x => x.EmployeeId == employee.Id);

                employee.JobContract = jobsContracts!;

                if (jobsContracts is not null)
                    jobsContracts.Employee = employee;
            }

            foreach (var job in Jobs)
            {
                JobContract? jobsContracts =
                    JobContracts.FirstOrDefault(x => x.JobId == job.Id);

                job.JobContract = jobsContracts;
                if (jobsContracts is not null)
                    jobsContracts.Jobs = job;
            }


        }
        public void UpdateEmployees(List<Employee> employees)
        {
            Db.WriteData<Employee>(employees);
        }
        public List<TResponse>? GetAllEmployees()
        {
            return Employees.Cast<TResponse>().ToList();
        }
        public TResponse? Get(TRequest rq)
        {
            var rqIdProperty = typeof(TRequest).GetProperty("Email");
            if (rqIdProperty == null)
            {
                throw new InvalidOperationException($"{typeof(TRequest).Name} type does not have an {rqIdProperty?.Name} property.");
            }

            var rqId = rqIdProperty.GetValue(rq);
            var result = Db.Data.FirstOrDefault(i => Equals(i.GetType().GetProperty("Email")?.GetValue(i), rqId));
            return result;
        }
    }

}

public interface IRepository<TResponse, TRequest>
{

    /*****  DB ***** */
    //public T Get(int Id);
    //public T Update();
    //public T GetAll();
    //public T Delete(int Id);
    public List<TResponse> GetAllEmployees();
    public void UpdateEmployees(List<Employee> employees);
}
