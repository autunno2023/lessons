using System;

namespace Classes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bank Ing = new();
            Ing.Balance = 1000; // Error: Setter is private
            Console.WriteLine($" Your balance is: {Ing.Balance}");
            Console.WriteLine($" Your balance is: {Ing.Balance}");
        }
    }
    public class Bank
    {
        private decimal _balance = 1000m;
        private decimal _interestRate = 5;
        private decimal _interests = 50m;
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
        decimal calcInterests()
        {
            return _balance / 100 * _interestRate;
        }
    }
}
