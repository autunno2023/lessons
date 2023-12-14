using Microsoft.Extensions.Configuration;
using System.Collections.Generic;


namespace DataLayer.Context
{

    // ORM  

    public class GenericDbContext<TResponse> : DbContext<TResponse>

    where TResponse : class, new()
    {

        //  public List<TResponse> Data;

        public GenericDbContext(IConfiguration configuration) : base(configuration)
        {

        }

        public List<T> ReadFromDb<T>() where T : class, new()
        {
            throw new System.NotImplementedException();
        }

        public void WriteData<T>(IEnumerable<T> data)
        {
            throw new System.NotImplementedException();
        }
        public void DoWork()
        {

        }
    }

}
