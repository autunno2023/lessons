namespace DataLayer.Dto
{
    public class EmployeesViewModelDTo : IEmployeesDTo
    {
        public string? Name { get; set; }
        public int? Id { get; set; }

        public EmployeesViewModelDTo(EmployeesServiceDTo? Employee)
        {
            Name = Employee?.Name;
            Id = Employee?.Id ?? default(int);
        }

    }

}
