using DataLayer.Db;
using DataLayer.Models;
using System.Collections.Generic;

namespace DataLayer.Repository
{
    public interface IRepository<T>
    {
        public List<T> GetAll();
        public T Get(int id);
        public bool Update();
        public bool Delete();
    }
    public class HrReposity
    {
        public List<Jobs> GetAllJobs()
        {
            using (var db = new HrContext("path\\Jobs"))
            {
                return db.Jobs;
            }
        }
        public List<Employee> GetAllEmployess()
        {
            using (var db = new HrContext("path\\Employees"))
            {
                return db.Employees;
            }
        }
    }


    #region Generic repository
    public class GenericRepository<T> : IRepository<T>
    {
        public bool Delete()
        {
            throw new System.NotImplementedException();
        }

        public T Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<T> GetAll()
        {
            using (var db = new GericContext<T>("path"))
            {
                return db.GetAll();
            }
        }

        public bool Update()
        {
            throw new System.NotImplementedException();
        }


    }

    #endregion
}
