using System;

namespace Dynamics.Lesson
{
    internal class Program
    {

        static void Main(string[] args)
        {
            State italy = new State();
            var request = new { Name = "Lombardia" };
            var response = italy.CreateRegion(request);
            Console.WriteLine(response.Name);
            Console.WriteLine(response.Population);
            for (int i = 0; i < response.Province.Length; i++)
            {
                dynamic province = response.Province[i];
                Console.WriteLine(province.Population);
            }

            Console.Read();
        }
    }


}
