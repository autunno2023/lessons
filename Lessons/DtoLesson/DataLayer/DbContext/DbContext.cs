using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DataLayer.DbContext
{


    #region Cos'è DataContext
    /*
      Il Datacontext  è'un ORM: In contesti di database e Object-Relational Mapping (ORM), 
      il datacontext può riferirsi a una classe che incapsula la logica per connettersi 
      a un database, eseguire query e gestire le entità del database. In questo senso, 
      funge da ponte tra il database e il livello di applicazione, consentendo agli 
      sviluppatori di lavorare con oggetti del dominio del problema invece di scrivere query SQL dirette.
     */
    #endregion
    #region ORM
    /*
      Un ORM (Object-Relational Mapping) è uno strumento di programmazione che permette di convertire 
      i dati tra sistemi incompatibili utilizzando un linguaggio di programmazione orientato agli oggetti.
      In pratica, un ORM consente agli sviluppatori di manipolare i dati di un database usando gli oggetti
      della loro lingua di programmazione, invece di dover scrivere codice SQL complesso
     */
    #endregion

    public abstract class DbContext
    {
        string _config; // Solitamente la configurazione per accedere al DstaSrc
        protected DbContext(string config)
        {
            _config = config;
        }
        public DbContext()
        {

        }
        #region Services 
        protected List<T> ReadFromDb<T>(string config) where T : class, new()
        {
            List<string> lines = File.ReadAllLines(config).ToList();
            return CreateObject<T>(lines);
        }
        public static List<T> CreateObject<T>(List<string> lines) where T : class, new()
        {
            List<T> list = new List<T>();
            string[] headers = lines.ElementAt(0).Split(',');
            lines.RemoveAt(0); // Rimuovo la prima riga (nome colonne) del mio datasource
            bool corretto = false;
            bool p = true;
            T entry = new T(); // Creo istanza per poter estrarre le properties
            PropertyInfo[] prop = entry
                            .GetType() // Prendo il tipo
                                    .GetProperties(); // Prendo le sue properties 

            if (true)
            {
                for (int i = 0; i < headers.Length; i++) // Ciclo le properties dell'oggetto  T
                {
                    PropertyInfo prp = entry.GetType().GetProperty(headers[i]);
                    if (prp is not null) // ciclo le colonne e le properties insieme
                    {
                        corretto = true;
                    }
                    else p = false; // S eha fallito almeno una volta, setto a false
                }
            }
            if (corretto && p)
            {
                for (int i = 0; i < lines.Count; i++)
                {
                    int j = 0;
                    string[] columns = lines[i].Split(',');
                    entry = new T();

                    foreach (var item in headers)
                    {


                        var e = entry.GetType().GetProperty(headers[j]);
                        if (e != null)
                        {
                            Type targetType = Nullable.GetUnderlyingType(e.PropertyType) ?? e.PropertyType;

                            //var t = Convert.ChangeType(col, entry.GetType().GetProperty(headers[j].Trim()).PropertyType);
                            //e.SetValue(entry, t);


                            // Custom conversion for nullable types  
                            var isNull = columns[j] == null ? true : false;
                            var isEmpty = string.IsNullOrEmpty(columns[j]) ? true : false;
                            var data = columns[j];

                            object convertedValue = (columns[j] == null || columns[j].Trim().Equals(string.Empty)) ? null : Convert.ChangeType(columns[j], targetType);
                            e.SetValue(entry, convertedValue);






                        }
                        j++;
                    }
                    list.Add(entry);

                }

            }
            else Console.WriteLine("le proprietà nel file non corrispondono a proprietà oggetto");

            return list;
        }
        public void WriteData<T>(IEnumerable<T> data)
        {

            List<string> list = new List<string>();
            StringBuilder sb = new StringBuilder();
            var cols = data.GetEnumerator().GetType().GetProperties();

            if (File.Exists(_config))
            {
                File.Delete(_config);
            }
            foreach (var col in cols)// cicla tutte le Entity della classe in oggetto
            {
                sb.Append(col.Name);
                sb.Append(',');
            }

            list.Add(sb.ToString().Substring(0, sb.Length - 1));
            foreach (var row in data)
            {

                sb = new StringBuilder();
                foreach (var col in cols)// cicla tutte le Entity della classe in oggetto
                {

                    sb.Append(col.GetValue(row));
                    sb.Append(',');


                }
                list.Add(sb.ToString().Substring(0, sb.Length - 1));
            }
            File.AppendAllLines(_config, list);
        }
        #endregion


    }
}
