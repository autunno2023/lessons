namespace DataLayer.Dto
{
    public class EmployeesViewModelDTo : IEmployeesDTo
    {
        public string? Name { get; set; }
        public int? Id { get; set; }
        public string? Error { get; set; } = string.Empty;

        public EmployeesViewModelDTo(HRServiceDToRes? Employee)
        {
            Name = Employee?.Name;
            Id = Employee?.Id ?? default(int);
        }
        public EmployeesViewModelDTo()
        {

        }

    }

}
