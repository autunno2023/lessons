
using System;
using PowerfulConsole.Abstract;

namespace PowerfulConsole.Products
{
    public class Square : IShape
    {
        public void draw()
        {
            Console.WriteLine("Drow a Square");
        }
    }
}

