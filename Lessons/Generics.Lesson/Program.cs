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
            List<Person> list = new List<Person>();
            list.Add(new Person());
            list.Add(new Person());
            list.Add(new Person());
            list.Add(new Person());
            list.Add(new Person());
            list.Add(new Person());


            #region Generic List
            MyGeneriList<Person> people = new MyGeneriList<Person>();
            people.AddItem(new() { Name = "Bruno", Age = 40 });
            people.AddItem(new() { Name = "Marco", Age = 30 });
            people.AddItem(new() { Name = "Diego", Age = 20 });
            people.AddItem(new() { Name = "Anna", Age = 10 });
            people.AddItem(new() { Name = "Maria", Age = 24 });
            people.AddItem(new() { Name = "Laura", Age = 50 });
            #endregion

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

            List<string> lines = File.ReadAllLines(path).ToList();

            var data = DataStore<Person>.CreateObject<Person>(lines);
            foreach (var p in data)
                Console.WriteLine(p.Age);
            #endregion
        }
    }
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
