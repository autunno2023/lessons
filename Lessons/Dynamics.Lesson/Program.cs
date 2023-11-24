using System;

namespace Dynamics.Lesson
{
    internal class Program
    {

        static void Main(string[] args)
        {

            State italy = new State();
            italy.Name = "Italy";

            dynamic RegioneFlatObj = italy.CreateRegione();

            //Console.WriteLine(RegioneFlatObj.Name);
            //Console.WriteLine(RegioneFlatObj.Population);
            //Console.WriteLine(RegioneFlatObj.Regioni[0].Name); // Non è chaive chiave/valore[string]
            //Console.WriteLine(RegioneFlatObj.Regioni[1].Name); // Non è chaive chiave/valore[string]
            //Console.WriteLine(RegioneFlatObj.Regioni[1].Province[0].Name); // Non è chaive chiave/valore[string]



            foreach (var regione in RegioneFlatObj._regioni)
            {
                Console.WriteLine($"regione:{regione.Name} ");
                Console.WriteLine(regione.Population);
                foreach (var provincia in regione.Province)
                {
                    Console.WriteLine($"    provincia:{provincia.Name} ");
                }
            }

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



