using System;

namespace AbstractClass
{
    abstract class Person
    {
        public string name;
        public string surname;
        public string age;
        public string luogoNascita;

        //public Person(string Name, string Surname)
        //{
        //    name = Name;
        //    surname = Surname;
        //}
        public abstract void getName();

    }
    class Citizen : Person
    {

        public string cf;

        //public Citizen(string Name, string Surname, string CF)
        //{
        //    name = Name;
        //    surname = Surname;
        //    cf = CF;
        //}  
        public override void getName()
        {
            Console.WriteLine(name + " " + surname);
        }

    }
    class Student : Person
    {
        string matricola;
        public override void getName()
        {
            Console.WriteLine(name + " " + surname + " " + matricola);

        }
    }
}

//class EUFiscalPerson : Citizen
//{
//    //public string name;
//    //public string Surname;
//    //public string age;
//    //public string luogoNascita;
//    //public string cf;
//    public new string name;
//    public bool contract;
//    public decimal salary;
//    public string employer;



//    public EUFiscalPerson(
//        string Name,
//        string Surname,
//        //string Age,
//        //string LuogoNascita,
//        ////
//        string CF,
//        bool Contract
//        //decimal Salary,
//        //string Employer
//        )
//    {
//        this.name = Name;
//        base.name = Name;
//        surname = Surname;
//        //age = Age;
//        //luogoNascita = LuogoNascita;
//        //cf = CF;
//        contract = Contract;
//        //salary = Salary;
//        //employer = Employer;


//    }

//}
//abstract class EntePublico
//{
//    protected string PIVA;
//    protected string Name;
//    protected string Address;
//    protected string Regione;
//    protected string Provincia;
//    protected string Comune;
//}
//class Comune : EntePublico
//{

//}

