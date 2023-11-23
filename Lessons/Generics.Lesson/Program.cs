using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Generics.Lesson
{
    internal class Program
    {
        static void Main(string[] args)
        {


            #region Generic FileWriter  

            string path = @"D:\logs\people.csv";

            List<Person> Persons = new List<Person>();
            Persons.Add(new() { Name = "Bruno", Age = 40 });
            Persons.Add(new() { Name = "Marco", Age = 30 });
            Persons.Add(new() { Name = "Diego", Age = 20 });
            Persons.Add(new() { Name = "Anna", Age = 10 });
            Persons.Add(new() { Name = "Maria", Age = 24 });
            Persons.Add(new() { Name = "Laura", Age = 50 });

            DataStore<Person>.WriteonFile(path, Persons);

            #endregion

            #region Generic FileReader 

            List<string> lines = File.ReadAllLines(path).ToList();//  leggi i dati dal file CSV

            List<Person> data = DataStore<Person>.CreateObject(lines);

            foreach (var p in data)
            {
                Console.Write(p.Name);
                Console.Write("|");
                Console.WriteLine(p.Age);
            }
            #endregion
        }
    }
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
