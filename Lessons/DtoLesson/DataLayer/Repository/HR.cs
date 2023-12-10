using DataLayer.DbContext;
using DataLayer.Models.HR;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer.Repository
{
    public class HRRepository<T, Rq, Rs> : IRepository<T, Rq, Rs>
    where T : HR, new()
    where Rs : class, new()
    {
        private readonly GenericDbContext<T, Rs> Db;

        public HRRepository(string path)
        {
            Db = new GenericDbContext<T, Rs>(path);
        }
        public void UpdateEmployees(List<T> employees)
        {
            Db.WriteData<T>(employees);
        }
        public List<Rs> GetAllEmployees()
        {
            return Db.Data;
        }
        public Rs? Get(Rq rq)
        {
            var rqIdProperty = typeof(Rq).GetProperty("Email");
            if (rqIdProperty == null)
            {
                throw new InvalidOperationException($"{typeof(Rq).Name} type does not have an {rqIdProperty?.Name} property.");
            }

            var rqId = rqIdProperty.GetValue(rq);
            var result = Db.Data.FirstOrDefault(i => Equals(i.GetType().GetProperty("Email")?.GetValue(i), rqId));
            return result;
        }
    }

}

public interface IRepository<T, Rq, Rs>
{

    /*****  DB ***** */
    //public T Get(int Id);
    //public T Update();
    //public T GetAll();
    //public T Delete(int Id);
    public List<Rs> GetAllEmployees();
    public void UpdateEmployees(List<T> employees);
}
