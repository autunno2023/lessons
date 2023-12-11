using System.Collections.Generic;


namespace DataLayer.DbContext
{

    // ORM  

    internal class GenericDbContext<TResponse> : DbContext

        where TResponse : class, new()
    {

        public List<TResponse> Data;
        public GenericDbContext(string path) : base(path)
        {

            //var dataFromDb = ReadFromDb<T>(path + typeof(T).Name.ToString() + ".csv");

            //// Assuming Res has a constructor that accepts a T instance
            //Data = dataFromDb.Select(item => Activator.CreateInstance(typeof(Res), item)).Cast<Res>().ToList();
        }
        //public class GenericDbContextMapping : Profile
        //{
        //    public IMapper mapper;
        //    MapperConfiguration config;

        //    public GenericDbContextMapping()
        //    {
        //        CreateMap<T, Res>(); // This is problematic with generic types
        //    }
        //}

        //public class GenericTypeConverter<T, Res> : ITypeConverter<T, Res>
        //{
        //    public HRServiceDToRes Convert(T source, HRServiceDToRes destination, ResolutionContext context)
        //    {
        //        destination = destination ?? new HRServiceDToRes();
        //        var sourceType = typeof(T);

        //        // Example of mapping
        //        destination.Id = (int?)sourceType.GetProperty("Id")?.GetValue(source);
        //        destination.Name = (string?)sourceType.GetProperty("Name")?.GetValue(source);
        //        // Map other properties similarly...

        //        return destination;
        //    }

        //    public Res Convert(T source, Res destination, ResolutionContext context)
        //    {
        //        destination = destination ?? new Res();
        //        var sourceType = typeof(T);

        //        foreach (var prop in destination.GetType().GetProperties())
        //        {
        //            var e = sourceType.GetType().GetProperty(prop.Name);
        //            if (e != null)
        //            {
        //                Type targetType = Nullable.GetUnderlyingType(e.PropertyType) ?? e.PropertyType;

        //                // Custom conversion for nullable types  
        //                var isNull = columns[j] == null ? true : false;
        //                var isEmpty = string.IsNullOrEmpty(columns[j]) ? true : false;
        //                var data = columns[j];

        //                object convertedValue = (columns[j] == null || columns[j].Trim().Equals(string.Empty)) ? null : Convert.ChangeType(columns[j], targetType);
        //                e.SetValue(entry, convertedValue);






        //            }
        //        }


        //    }



        //}


    }
    //internal class HumanResouresDbContext<T, Res> : GenericDbContext<T, Res> where T : HR, new()
    //{

    //    public List<Employee> Employees { get; set; }

    //    public List<HRServiceDToRes> GetEmployees
    //    {
    //        get
    //        {
    //            return Employees.Select(emp => new HRServiceDToRes(emp)).ToList();
    //        }

    //    }
    //    public List<JobContract> JobsContracts { get; set; }
    //    public List<Jobs> Jobs { get; set; }




    //    public HumanResouresDbContext(string Path) : base(Path)
    //    {

    //        Employees = ReadFromDb<Employee>(Path + typeof(Employee).Name.ToString() + ".csv");
    //        JobsContracts = ReadFromDb<JobContract>(Path + typeof(JobContract).Name.ToString() + ".csv");
    //        Jobs = ReadFromDb<Jobs>(Path + typeof(Jobs).Name.ToString() + ".csv");
    //        MergerData();

    //    }

    //    private void MergerData()
    //    {
    //        foreach (var employee in Employees)
    //        {
    //            JobContract? jobsContracts =
    //                JobsContracts.FirstOrDefault(x => x.EmployeeId == employee.Id);

    //            employee.JobContract = jobsContracts!;

    //            if (jobsContracts is not null)
    //                jobsContracts.Employee = employee;
    //        }

    //        foreach (var job in Jobs)
    //        {
    //            JobContract? jobsContracts =
    //                JobsContracts.FirstOrDefault(x => x.JobId == job.Id);

    //            job.JobContract = jobsContracts;
    //            if (jobsContracts is not null)
    //                jobsContracts.Jobs = job;
    //        }


    //    }

    //}
    //internal class SocialMediaDbContext : DbContext
    //{
    //    public List<User> Users { get; set; }
    //    public List<Post> Posts { get; set; }
    //    public List<Comment> Comments { get; set; }

    //    public List<SocialMediaDto> GetEmployees
    //    {
    //        get
    //        {
    //            return Users.Select(User => new SocialMediaDto(User)).ToList();
    //        }

    //    }



    //    public SocialMediaDbContext(string Path) : base(Path)
    //    {

    //        Users = ReadFromDb<Users>(Path + typeof(Users).Name.ToString() + ".csv");

    //        MergerData();

    //    }

    //    private void MergerData()
    //    {
    //        foreach (var employee in Employees)
    //        {
    //            JobContract? jobsContracts =
    //                JobsContracts.FirstOrDefault(x => x.EmployeeId == employee.Id);

    //            employee.JobContract = jobsContracts!;

    //            if (jobsContracts is not null)
    //                jobsContracts.Employee = employee;
    //        }

    //        foreach (var job in Jobs)
    //        {
    //            JobContract? jobsContracts =
    //                JobsContracts.FirstOrDefault(x => x.JobId == job.Id);

    //            job.JobContract = jobsContracts;
    //            if (jobsContracts is not null)
    //                jobsContracts.Jobs = job;
    //        }


    //    }

    //}

}
