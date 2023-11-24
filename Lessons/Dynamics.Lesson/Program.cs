using System;

namespace Dynamics.Lesson
{
    internal class Program
    {

        static void Main(string[] args)
        {

            State italy = new State("Italy");



            //#region PublicInfo   
            //// Ritorno i membri publici dello State tramite Anonymous + dynamic 
            //Console.WriteLine("\n---- Ritorno i membri publici dello State tramite Anonymous + dynamic ----\n");

            //dynamic PublicInfo = italy.GetPublicInfoAnonymous();
            //Console.WriteLine(PublicInfo.Name);
            //Console.WriteLine(PublicInfo.Population);
            //Console.WriteLine(PublicInfo.Regioni[0].Name);
            //Console.WriteLine(PublicInfo.Regioni[1].Name);
            //Console.WriteLine(PublicInfo.Regioni[1].Province[0].Name);
            //#endregion


            #region PrivateInfo  
            // Ritorno i membri privati dello State tramite Anonymous + dynamic 
            Console.WriteLine("\n----Ritorno i membri privati dello State tramite Anonymous + dynamic----\n");
            dynamic PrivateInfo = italy.GetPrivateInfoByAnonymous();
            Console.WriteLine(PrivateInfo._name);
            Console.WriteLine(PrivateInfo._population);
            Console.WriteLine(PrivateInfo._regioni[0].Name);
            Console.WriteLine(PrivateInfo._regioni[1].Name);
            Console.WriteLine(PrivateInfo._regioni[1].Province[0].Name);

            #region Soluzione 
            /* Anoynmous type non aggira le regole di visibilita dell'oggetto,
            ma crea al volo un oggetto anonimo ci chiave/valore di tipo stringa. 
            La sua crazione però a dei limiti.Se non si rispetta perfettamente la struttura degli oggetti (Ese: Annidati)
            si possono generare bug che sarannon poi visibili solo a runtime.
            */



            #region StateDynamic 
            // Ritorno tutto l'oggetto State tramite Dynamic

            Console.WriteLine("\n----GetStateDynamic Private Info ----\n");


            dynamic StateDynamic = italy.GetStateDynamic();
            Console.WriteLine(StateDynamic.Name);
            Console.WriteLine(StateDynamic.Population);
            Console.WriteLine(StateDynamic.Regioni[0].Name);
            Console.WriteLine(StateDynamic.Regioni[1].Name);
            Console.WriteLine(StateDynamic.Regioni[1].Province[0].Name);

            Console.WriteLine("         \n----StateDynamic Public  Info----\n");

            Console.WriteLine(StateDynamic._name);
            Console.WriteLine(StateDynamic._population);
            Console.WriteLine(StateDynamic._regioni[0].Name);
            Console.WriteLine(StateDynamic._regioni[1].Name);
            Console.WriteLine(StateDynamic._regioni[1].Province[0].Name);



            #endregion
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



