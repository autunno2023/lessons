using System;

namespace Associations
{
    internal class CoffeeMachine
    {
        public CoffeeMachine()
        {

        }
        public void makeCoffee(Coffee coffee)
        {
            Console.WriteLine($" I'm making some coffee with {coffee.name} ");
        }

    }
    class Coffee
    {
        public string name = "Dolce Gusto";
        public Coffee()
        {

        }
    }
}
