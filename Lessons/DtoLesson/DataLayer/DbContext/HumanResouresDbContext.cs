using DataLayer.Dto;
using DataLayer.Models;
using System.Collections.Generic;
using System.Linq;


namespace DataLayer.DbContext
{

    // ORM
    public class HumanResouresDbContext : DbContext
    {
        List<Employee> Employees { get; set; }

        public List<EmployeesServiceDTo> GetEmployees
        {
            get
            {
                return Employees.Select(emp => new EmployeesServiceDTo(emp)).ToList();
            }

        }
        public List<JobContract> JobsContracts { get; set; }
        public List<Jobs> Jobs { get; set; }




        public HumanResouresDbContext(string Path) : base(Path)
        {

            Employees = ReadFromDb<Employee>(Path + typeof(Employee).Name.ToString() + ".csv");
            JobsContracts = ReadFromDb<JobContract>(Path + typeof(JobContract).Name.ToString() + ".csv");
            Jobs = ReadFromDb<Jobs>(Path + typeof(Jobs).Name.ToString() + ".csv");
            MergerData();

        }

        private void MergerData()
        {
            foreach (var employee in Employees)
            {
                JobContract? jobsContracts =
                    JobsContracts.FirstOrDefault(x => x.EmployeeId == employee.Id);

                employee.JobContract = jobsContracts!;

                if (jobsContracts is not null)
                    jobsContracts.Employee = employee;
            }

            foreach (var job in Jobs)
            {
                JobContract? jobsContracts =
                    JobsContracts.FirstOrDefault(x => x.JobId == job.Id);

                job.JobContract = jobsContracts;
                if (jobsContracts is not null)
                    jobsContracts.Jobs = job;
            }


        }

    }
}
