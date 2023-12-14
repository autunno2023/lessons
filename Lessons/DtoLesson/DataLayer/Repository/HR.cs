using DataLayer.Context;
using DataLayer.Models.HR;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer.Repository
{
    public class HRRepository<TRequest, TResponse> : IRepository<TRequest, TResponse>
    where TRequest : class, new()
    where TResponse : class, new()
    {
        private readonly GenericDbContext<TResponse> Db;


        List<Employee> Employees;
        List<JobContract> JobContracts;
        List<Job> Jobs;
        public HRRepository(GenericDbContext<TResponse> genericDbContext)
        {
            Db = genericDbContext;
            Employees = Db.ReadFromDb<Employee>();
            JobContracts = Db.ReadFromDb<JobContract>();
            Jobs = Db.ReadFromDb<Job>();
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
            var result = Employees.FirstOrDefault(i => Equals(i.GetType().GetProperty("Email")?.GetValue(i), rqId));
            return (TResponse?)Activator.CreateInstance(typeof(TResponse), result);
        }
    }

}

public interface IRepository<TRequest, TResponse>
{

    /*****  DB ***** */
    public TResponse Get(TRequest request);
    //public T Update();
    //public T GetAll();
    //public T Delete(int Id);
    public List<TResponse> GetAllEmployees();
    public void UpdateEmployees(List<Employee> employees);
}
