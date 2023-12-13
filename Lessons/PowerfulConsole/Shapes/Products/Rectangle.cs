
using System;
using PowerfulConsole.Abstract;

namespace PowerfulConsole.Products
{
    public class Rectangle : IShape
    {
        public void draw()
        {
            Console.WriteLine("Drow a Rectangle");
        }
    }
}

