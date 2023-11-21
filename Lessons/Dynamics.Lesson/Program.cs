using System;
using static Dynamics.Lesson.State;

namespace Dynamics.Lesson
{
    internal class Program
    {

        static void Main(string[] args)
        {
            State italy = new State();
            italy.Name = "Italy";

            StateDto Regione = italy.CreateRegione("Lombardia");
            PrintDynamic(Regione);


            Console.Read();
        }



        static void PrintDynamic(dynamic dto)
        {
            if (dto != null)
            {
                foreach (var property in dto.GetType().GetProperties())
                {
                    var propertyValue = property.GetValue(dto, null);

                    if (!property.PropertyType.IsArray)
                    {
                        if (propertyValue != null)
                        {
                            Console.WriteLine($" : {property.Name}: {propertyValue}");
                        }
                    }
                    else
                    {
                        foreach (var element in propertyValue)
                        {
                            Console.WriteLine(element.GetType().Name.ToUpper());
                            PrintDynamic(element);
                        }
                    }
                }
            }
        }
    }
}



