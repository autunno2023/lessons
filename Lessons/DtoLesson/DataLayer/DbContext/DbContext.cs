using System.Collections.Generic;

namespace DataLayer.DbContext
{
    abstract internal class DbContext
    {

        public DbContext(string config)
        {

        }
        protected List<T> ReadFromDb<T>(string config) where T : class
        {
            // return ReadFromFile(_config);   ---> Dall'Utility che abbiamo creato
            return null;
        }
    }
}
