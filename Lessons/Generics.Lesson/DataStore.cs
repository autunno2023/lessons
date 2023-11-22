using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Generics.Lesson
{

    public class DataStore<T> where T : class, new()
    {

        public static void WriteonFile<T>(string path, List<T> ts) where T : class, new()
        {
            List<string> list = new List<string>();
            StringBuilder sb = new StringBuilder();
            var cols = ts[0].GetType().GetProperties();

            if (File.Exists(path))
            {
                File.Delete(path);
            }
            foreach (var col in cols)// cicla tutte le Entity della classe in oggetto
            {
                sb.Append(col.Name);
                sb.Append(',');
            }

            list.Add(sb.ToString().Substring(0, sb.Length - 1));
            foreach (var row in ts)
            {

                sb = new StringBuilder();
                foreach (var col in cols)// cicla tutte le Entity della classe in oggetto
                {

                    sb.Append(col.GetValue(row));
                    sb.Append(',');


                }
                list.Add(sb.ToString().Substring(0, sb.Length - 1));
            }
            File.AppendAllLines(path, list);
        }
        public static List<T> CreateObject<T>(List<string> lines) where T : class, new() //constraint 
        {
            List<T> list = new List<T>();
            string[] headers = lines.ElementAt(0).Split(',');
            lines.RemoveAt(0); // Rimuovo la prima riga (nome colonne) del mio datasource
            bool isDatset = true;
            bool p = true;
            T entry = new T(); // Creo istanza per poter estrarre le properties
            PropertyInfo[] prop = entry
                            .GetType() // Prendo il tipo
                                    .GetProperties(); // Prendo le sue properties 

            if (true)
            {
                //VERIFICO SE IL FILE CARICATO HA LA LO STESSO DATASET DELL'OGGETTO T
                for (int i = 0; i < prop.Length; i++) // Ciclo le properties dell'oggetto  T
                {
                    if (prop.ElementAt(i).Name == headers[i]) // ciclo le colonne e le properties insieme non col stesso index
                    {
                        continue;
                    }
                    else
                    {
                        isDatset = false; // Se fallisce almeno una volta , non il dataset. 
                    }
                }
            }
            if (isDatset)
            {
                // INIZIO AD ESTRARRE LE RIGHE CON I DATI  
                lines.RemoveAt(0); // Rimuovi la prima riga che raprensenta il HEADER [Name,Age]
                foreach (var line in lines)
                {
                    entry = new T();// Per ogni riga del CSV creo un nuovo oggetto di tipo T
                    #region eXTRACION
                    int j = 0;
                    string[] columns = line.Split(',');

                    foreach (var col in columns) // cicle le colonne del CSV
                    {
                        try
                        {
                            entry.GetType().GetProperty(headers[j]) // prendo  proprietà dell'oggetto Person  tramite i nomi delle colonne del file 
                              .SetValue(entry, // Vado a settare il valore predendo invece il valore della cella che corrisponde alla colonna 
                                 Convert.ChangeType(col, //   singola cella del CSV (il valore da settare )
                                     entry.GetType().GetProperty(headers[j])
                                       .PropertyType)//ritorna il tipo del property dell'oggetto. Mi server per convertire il valore che in qeusto momento non altro che una stringa dal file. 
                              );
                        }
                        catch
                        {
                            throw;
                        }


                        j++;
                    }
                    #endregion
                    list.Add(entry);
                }
            }
            else Console.WriteLine("le proprietà nel file non corrispondono a proprietà oggetto");

            return list;
        }



    }
    public class DataStore
    {

    }
}
