using System;

namespace AbstractClass
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }
    }

    abstract class FiguraGeometrica
    {
        public decimal Area;
        public decimal Perimetro;
        protected abstract decimal CalcArea();
        public decimal getArea()
        {
            return Area;
        }

    }
    class Cerchio : FiguraGeometrica
    {
        protected override decimal CalcArea()
        {
            //calc area cerchio 

            return 0m;
        }

    }
    class Square : FiguraGeometrica
    {

        public Square(decimal Base, decimal Altezza)
        {

        }
        protected override decimal CalcArea()
        {
            //calc area Square 
            // Area
            //Area = // Rissultato; 
            return 0m;
        }
        public virtual void getName()
        {
            Console.WriteLine("Square");
        }

    }
    class Square2 : Square
    {

        public Square2(decimal Base, decimal Altezza) : base(Base, Altezza)
        {

        }
        protected override decimal CalcArea()
        {
            //calc area Square 
            // Area
            //Area = // Rissultato; 
            return 0m;
        }
        public override void getName()
        {
            Console.WriteLine("Square2");
        }


    }

    class Person
    {
        public string name;
        public string surname;
        public string age;
        public string luogoNascita;

        public Person(string Name, string Surname)
        {
            name = Name;
            surname = Surname;
        }
        public string getName()
        {
            return name + " " + surname;
        }

    }
    class Citizen : Person
    {

        public string cf;

        public Citizen(string Name, string Surname, string CF) : base(Name, Surname)
        {
            name = Name;
            surname = Surname;
            cf = CF;
        }

    }
    class FiscalPerson : Citizen
    {
        //public string name;
        //public string Surname;
        //public string age;
        //public string luogoNascita;
        //public string cf;
        public new string name;
        public bool contract;
        public decimal salary;
        public string employer;



        public FiscalPerson(
            string Name,
            string Surname,
            //string Age,
            //string LuogoNascita,
            ////
            string CF,
            bool Contract
            //decimal Salary,
            //string Employer
            ) : base(Name, Surname, CF)
        {
            this.name = Name;
            base.name = Name;
            surname = Surname;
            //age = Age;
            //luogoNascita = LuogoNascita;
            //cf = CF;
            contract = Contract;
            //salary = Salary;
            //employer = Employer;


        }

    }
}
