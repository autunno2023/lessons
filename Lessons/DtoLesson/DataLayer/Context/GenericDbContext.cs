using Microsoft.Extensions.Configuration;
using System.Collections.Generic;


namespace DataLayer.Context
{

    // ORM  

    public class GenericDbContext<TResponse> : DbContext<TResponse>

    where TResponse : class, new()
    {
        public List<TResponse> Data;

        public GenericDbContext(IConfiguration configuration) : base(configuration)
        {

        }

    }

}
