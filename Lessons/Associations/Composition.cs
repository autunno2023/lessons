namespace Associations
{
    internal class Company
    {
        CEO _CEO;

        public Company()
        {
            _CEO = new CEO("Bruno", "", this);
        }
    }
    class CEO
    {
        string _name;
        string _stipendio;
        Company _company;
        public CEO(string Name, string Stipendio, Company Company)
        {
            _name = Name;
            _stipendio = Stipendio;
            _company = Company;
        }

    }
}
