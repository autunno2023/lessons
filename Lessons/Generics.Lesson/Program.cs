using System.Collections.Generic;

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
        }
    }
}
