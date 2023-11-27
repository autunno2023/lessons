using System;
using System.Collections.Generic;


namespace DataLayer.DbContext
{
    internal class GenericContext<T> : DbContext, IDisposable
    {
        //public List<Employee> Employees { get; set; }
        //public List<Jobs> Jobs { get; set; }

        // Crea uuna nuova istanza del Db ogni volta che la classe viene genereato 
        // Crea  un nuova istanza ogni che il file config cambia
        public GenericContext(string config) : base(config)
        {
            //  Employees =  read from File; 
            //  Jobs =  read from File; 
        }
        public List<T> GetAll()
        {
            // return ReadFromDb()

            return null;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
