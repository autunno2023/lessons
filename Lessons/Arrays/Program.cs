using System;
using System.Linq;

namespace Arrays
{
    internal class Program
    {

        static void Main(string[] args)
        {
            //Car car = new Car("FIAT", 5);
            //car.addOwner("Bruno");
            //car.addOwner("Bruno");
            //car.addOwner("Bruno");
            //car.addOwner("Bruno");
            //car.addOwner("Bruno");
            //car.addOwner("Bruno");
            LambdaFucntions();


            Console.ReadKey();
        }
        static void DichiarazioneStatica()
        {
            string[] strings = new string[5];
            Array array = strings;

            string a = "a";
            string b = "b";
            string c = "c";
            string d = "d";
            string e = "e";
            string f = "e";

            strings[0] = a;
            strings[1] = b;
            strings[2] = c;
            strings[3] = d;
            strings[4] = e;
            strings[5] = f;
        }
        static void DichiarazioneDinamica()
        {
            string[] strings = new string[] { "a", "b", "c", "d", "e", "f", "g" };

            strings[3] = "z";
            Console.WriteLine(strings[3]);
        }
        public static void ArrayIteration()
        {
            int[] numbers = new int[] { 0, 1, 2 };

            foreach (var item in numbers) // IEnumerable
            {
                Console.WriteLine(item);
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i]);
            }


            int[,] matrice2D = new int[3, 2]
            {
                    { 1, 2 },
                    { 4, 5 },
                    { 4, 5 }
            };

            for (int riga = 0; riga < matrice2D.GetLength(0); riga++)
            {
                Console.WriteLine($"sono in riga {riga}");

                for (int colonna = 0; colonna < matrice2D.GetLength(1); colonna++)
                {
                    Console.WriteLine($"sono in colonna {colonna}");
                    Console.WriteLine($"Il valore è in colonna {matrice2D[riga, colonna]}");


                }

            }

            int[,,] matrice3D = new int[2, 2, 2]
            {
                {
                      {1000,2000 },
                      {4000,6000 }
                },
                {
                      {8000,16000 },
                      {24000,30000 }
                }
            };
            foreach (var items in matrice3D)
            {
                Console.WriteLine(items);
            }

            for (int dim1 = 0; dim1 < matrice3D.GetLength(0); dim1++)
            {

                for (int dim2 = 0; dim2 < matrice3D.GetLength(1); dim2++)
                {

                    for (int dim3 = 0; dim3 < matrice3D.GetLength(1); dim3++)
                    {
                        Console.WriteLine($"sono in colonna {dim3}");
                        Console.WriteLine($"Il valore è in colonna {matrice3D[dim1, dim2, dim3]}");
                    }
                }
            }

            // iterare tutti gli elenmenti dell'array a patto che rispetti la dimensione max dell'array! 
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i]);
            }
            foreach (var item in numbers)
            {
                Console.WriteLine(item);

            }
            Console.WriteLine(numbers.Rank);
        }
        static void LinqFunction()
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5 };

            numbers.Max();
            numbers.Min();
            numbers.Sum();

        }
        static void FindItem()
        {

            string[] items = new string[] { "Bruno", "Marco", "Elena", "Fabio" };
            var index = Array.IndexOf(items, "Bruno"); // Arrow Function
            //Console.WriteLine(result);

        }
        static void SelctByLenght()
        {
            string[] items = new string[] { "Bruno", "Marco", "Elena", "Mario" };
            var result = Array.FindAll(items, i => i.Length == 5);
        }
        static void FindPosition()
        {
            string[] items = new string[] { "Bruno", "Marco", "Elena", "Mario" };
            int index = Array.IndexOf(items, "Bruno");
            Console.WriteLine(items[index]);
        }
        static void LambdaFucntions()
        {
            Post post1 = new Post() { id = 2, social = "Facebook", comments = new string[] { "", "", "", "" } };
            Post post2 = new Post() { id = 2, social = "Facebook", comments = new string[] { "", "", "", "" } };
            Post post3 = new Post() { id = 3, social = "Facebook", comments = new string[] { "", "", "", "" } };
            Post post4 = new Post() { id = 4, social = "instagram", comments = new string[] { "", "", "", "" } };
            Post post5 = new Post() { id = 5, social = "instagram", comments = new string[] { "", "", "", "" } };
            Post post6 = new Post() { id = 6, social = "Google", comments = new string[] { "", "", "", "" } };

            Post[] posts = new Post[6];
            posts[0] = post1;
            posts[1] = post2;
            posts[2] = post3;
            posts[3] = post4;
            posts[4] = post5;
            posts[5] = post6;

            var Groups = posts.GroupBy(i => i.social); // 


            foreach (var group in Groups) // 3 gruppi 
            {

                Console.WriteLine(group.Key.ToUpper());


                foreach (var item in group)
                {
                    Console.WriteLine(" post id:{0} ", item.id);

                    for (int i = 0; i < item.comments.Length; i++)
                    {
                        Console.WriteLine($"        Comment #{new Random().Next(100, 1000)}");
                    }
                }


                Console.WriteLine("\n\n");
            }

        }
    }
}
public class Post
{
    public int id;
    public string social;
    public string[] comments;
    public Post()
    {


    }

}
public class Comments
{
    public int id;
}
class Car
{
    //const int TotOwners = 4; // di istanza 
    string _name;
    int counter;
    string[] _owners;
    public Car(string Name, int totOwners)
    {
        _name = Name;
        _owners = new string[totOwners]; // 5
    }

    public void addOwner(string Name)
    {

        if (counter < _owners.Length)
        {
            _owners[counter] = Name;
            counter++;
        }
    }
    public void RemoveOwner(string Name)
    {
        Person[] items = new Person[] {
                new Person() { Name = "Bruno" },
                new Person() { Name = "Elena" },
                new Person() { Name = "Elena" },
                new Person() { Name = "Mario" },
                new Person() { Name = "Fabio" },
               };

        var result = items.Where(i => i.Name == "Elena").ToArray();



        var index = Array.IndexOf(items, result);

        Person[] items2 = new Person[10];
        Array.Copy(items, items2, items.Length);
    }
}
class Person
{
    Person[] persons = new Person[10];
    public string Name { get; set; }
    public string Surname { get; set; }
}

