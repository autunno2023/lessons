using System;

namespace AbstractClass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Citizen citizen = new Citizen();
            // Citizen Citizen = (Citizen) citizen;
            FiguraGeometrica
                 geometrica = new Square(20, 20);
            geometrica.CalcArea();
            //ComuneDiMilano(citizen);
        }
        public static void ComuneDiMilano(Citizen Person)// Upcasting automatico
        {

            Person person = Person;
        }
    }

    abstract class FiguraGeometrica
    {
        public decimal Area;
        public decimal Perimetro;
        public abstract void CalcArea();

    }
    class Circle : FiguraGeometrica
    {
        public override void CalcArea()
        {
            //calc area cerchio 

            Console.WriteLine("Calc area for Circle");

        }

    }
    class Retangle : FiguraGeometrica
    {

        public Retangle(decimal Base, decimal Altezza)
        {

        }
        public override void CalcArea()
        {
            Console.WriteLine("Calc area for Retangle");

        }

    }
    class Square : Retangle
    {

        public Square(decimal Base, decimal Altezza) : base(Base, Altezza)
        {

        }
        public override void CalcArea()
        {
            Console.WriteLine("Calc area for Square");

        }
    }

}
