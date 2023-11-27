using System.Collections.Generic;

namespace DataLayer.Db
{
    abstract internal class DbContext
    {
        string _config;

        public DbContext(string config)
        {
            _config = config;
        }
        public List<T> ReadFromDb<T>() where T : class
        {
            // return ReadFromFile(_config); 
            return null;
        }
    }
}
