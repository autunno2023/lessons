using System;

namespace Classes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bank Intesa = new("Intesa", "str bla bla", "UK305949545", "Bruno"); ;
            Bank Ing = new("Ing", "str bla bla", "UK305949545", "Bruno"); ;
            Bank unicredit = new("unicredit", "str bla bla", "UK305949545", "Bruno"); ;
            Bank Revolut = new("Revolut", "str bla bla", "UK305949545", "Bruno"); ;
            //Intesa.Balance = 1000; // Error: Setter is private
            Console.WriteLine($" Your balance is: {Intesa.Balance}");
            Console.WriteLine($" The Bank's name is: {Intesa._name}");
            Console.WriteLine($" The Bank's _address is: {Intesa._address}");
            Console.WriteLine($" The Bank's _vatNumber is: {Intesa._vatNumber}");
            Console.WriteLine($" The Bank's _CEO is: {Intesa._CEO}");
        }
    }
    public class Bank
    {
        public string _name;
        public string _address;
        public string _vatNumber;
        public string _CEO;
        private decimal _balance = 1000m;
        private decimal _interestRate = 5;
        private decimal _interests = 50m;

        public Bank(string Name, string Address, string VatNumber, string CEO)
        {
            _name = Name;
            _address = Address;
            _vatNumber = VatNumber;
            _CEO = CEO;
        }
        public decimal Balance
        {
            get
            {
                return calcInterests();
            }
            private set
            {
                // logic
                _balance = value;
            }
        }
        private decimal calcInterests()
        {
            return _balance / 100 * _interestRate;
        }
    }
}
