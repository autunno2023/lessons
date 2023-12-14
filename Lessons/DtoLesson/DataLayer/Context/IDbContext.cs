using System.Collections.Generic;

namespace DataLayer.Context
{
    public interface IDbContext<TResponse>
    {
        List<T> ReadFromDb<T>() where T : class, new();
        void WriteData<T>(IEnumerable<T> data);
    }
}