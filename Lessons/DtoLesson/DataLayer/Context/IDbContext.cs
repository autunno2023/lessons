using System.Collections.Generic;

namespace DataLayer.Context
{
    internal interface IDbContext
    {
        List<T> ReadFromDb<T>() where T : class, new();
        void WriteData<T>(IEnumerable<T> data);
    }
}