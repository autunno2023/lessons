using DataLayer.Dto;
using DataLayer.Models;
using System.Collections.Generic;
using System.Linq;


namespace DataLayer.DbContext
{

    // ORM  

    internal class GenericDbContext<T, Rq> : DbContext
    {
        public List<Rq> Data; // EmployeesServiceDTo
        public GenericDbContext()
        {
            Data = ReadFromDb<T>("" + typeof(T).Name.ToString() + ".csv");
        }
    }
    internal class HumanResouresDbContext : DbContext
    {
        public List<Employee> Employees { get; set; }

        public List<HRServiceDToRes> GetEmployees
        {
            get
            {
                return Employees.Select(emp => new HRServiceDToRes(emp)).ToList();
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
    internal class SocialMediaDbContext : DbContext
    {
        public List<User> Users { get; set; }
        public List<Post> Posts { get; set; }
        public List<Comment> Comments { get; set; }

        public List<SocialMediaDto> GetEmployees
        {
            get
            {
                return Users.Select(User => new SocialMediaDto(User)).ToList();
            }

        }



        public SocialMediaDbContext(string Path) : base(Path)
        {

            Users = ReadFromDb<Users>(Path + typeof(Users).Name.ToString() + ".csv");

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
