namespace Associations
{
    class Labor
    {
        public string name;
        public decimal stipendio = 1000M;
    }

    internal class Manager : Labor   // Giorgio
    {
        public Employee _employee; //Bruno
        public Manager()
        {

        }
        public void AddEmployee(Employee Employee)
        {
            _employee = Employee;
        }
        public void RemoveEmployee()
        {
            // Query 
            _employee = null;
        }
    }
    internal class Employee : Labor
    {
        public Manager _manager;

        public Employee(Manager manager, string Name)
        {
            _manager = manager;
            name = Name;
            manager.AddEmployee(this);
        }
        public Employee() { }
        public void ChangeManager(Manager manager) // Alessandro
        {
            _manager.RemoveEmployee();
            _manager = manager;

        }

    }
}
