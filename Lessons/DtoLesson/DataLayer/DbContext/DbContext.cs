using System.Collections.Generic;

namespace DataLayer.DbContext
{
    public abstract class DbContext
    {
        string _config;
        protected DbContext(string config)
        {
            _config = config;
        }
        public DbContext()
        {

        }
        protected List<T> ReadFromDb<T>(string config) where T : class, new()
        {
            // return ReadFromFile(_config);   ---> Dall'Utility che abbiamo creato
            return null;
        }
    }
}
