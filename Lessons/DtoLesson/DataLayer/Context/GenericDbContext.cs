using Microsoft.Extensions.Configuration;
using System.Collections.Generic;


namespace DataLayer.Context
{

    // ORM  

    public class GenericDbContext<TResponse> : DbContext

        where TResponse : class, new()
    {

        public List<TResponse> Data;

        internal GenericDbContext(IConfiguration configuration) : base(configuration)
        {

        }
    }

}
