﻿using Newtonsoft.Json;
using System;

namespace Dynamics.Lesson
{
    internal class Program
    {

        static void Main(string[] args)
        {
            #region Distrubiuto 
            //getDto();
            getDynamicObj();
            #endregion


            State italy = new State("Italy");
            #region PublicInfo   
            // Ritorno i membri PUBLIC dello State tramite Anonymous + dynamic 
            Console.WriteLine("\n---- Ritorno i membri publici dello State tramite Anonymous + dynamic ----\n");

            dynamic PublicInfo = italy.GetPublicInfoAnonymous();

            Console.WriteLine(PublicInfo.Name);
            Console.WriteLine(PublicInfo.Population);
            Console.WriteLine(PublicInfo.Regioni[0].Name);
            Console.WriteLine(PublicInfo.Regioni[1].Name);
            Console.WriteLine(PublicInfo.Regioni[1].Province[0].Name);
            #endregion
            #region PrivateInfo  
            // Ritorno i membri PRIVATE dello State tramite Anonymous + dynamic 
            Console.WriteLine("\n----Ritorno i membri privati dello State tramite Anonymous + dynamic----\n");

            dynamic PrivateInfo = italy.GetPrivateInfoByAnonymous();

            Console.WriteLine(PrivateInfo._name);
            Console.WriteLine(PrivateInfo._population);
            Console.WriteLine(PrivateInfo._regioni[0].Name);
            Console.WriteLine(PrivateInfo._regioni[1].Name);
            Console.WriteLine(PrivateInfo._regioni[1].Province[0].Name);
            #region Considerazioni 
            /*  Anoynmous type non aggira le regole di visibilita dell'oggetto,
                ma crea al volo un oggetto anonimo ci chiave/valore di tipo stringa. 
                Il suo uso però a dei LIMITI. Se non si rispetta perfettamente la struttura degli oggetti (Ese: Annidamento)
                si possono generare bug che saranno poi rilevabili solo a Runtime.

            */
            #endregion

            #endregion
            #region StateDynamic 
            // Ritorno tutto l'oggetto State tramite Dynamic

            Console.WriteLine("\n----GetStateDynamic Private Info ----\n");


            dynamic StateDynamic = italy.GetStateDynamic();


            Console.WriteLine(StateDynamic.Name);
            Console.WriteLine(StateDynamic.Population);
            Console.WriteLine(StateDynamic.Regioni[0].Name);
            Console.WriteLine(StateDynamic.Regioni[1].Name);
            Console.WriteLine(StateDynamic.Regioni[1].Province[0].Name);

            Console.WriteLine("         \n----StateDynamic Private  Info----\n");

            Console.WriteLine(StateDynamic._name);
            Console.WriteLine(StateDynamic._population);
            Console.WriteLine(StateDynamic._regioni[0].Name);
            Console.WriteLine(StateDynamic._regioni[1].Name);
            Console.WriteLine(StateDynamic._regioni[1].Province[0].Name);



            #endregion


            Console.Read();
        }

        static Person? getDto()
        {
            string jsonString = "{\"Name\":\"John\", \"Age\":30}";
            Person? person = JsonConvert.DeserializeObject<Person>(jsonString);
            Console.WriteLine($"Name: {person?.Name},\n Age: {person?.Age}");
            return person;
        }
        static Person? getDynamicObj()
        {
            string jsonString = "{\"Fullname\":\"John Doe\", \"Age\":30}";
            dynamic person = JsonConvert.DeserializeObject<Person>(jsonString); //  non Piu tipizzato ma Dinamico
            Console.WriteLine($"Name: {person?.Name ?? person?.Fullname}, Age: {person?.Age}");  // Coalescing Operators
            return person;
        }


    }
    class Person
    {

        public string? Name { get; set; }
        public int? Age { get; set; }

    }

}



