using DataLayer.DbContext;
using ServiceLayer.Dto;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer.Repository
{

    public interface IRepository<T>
    {
        public List<T> GetAll();
        public T Get(int id);
        public bool Update(T obj);
        public bool Delete(int id);
    }
    public class EmployeeRepository : IRepository<EmployeeServiceDTO> // Response
    {
        public List<EmployeeServiceDTO> GetAll()
        {
            using (var db = new HumanResourceContext("path\\Employees"))
            {
                return db.Employees.Select(i => new EmployeeServiceDTO(i)).ToList();
            }
        }
        public EmployeeServiceDTO Get(int id)
        {
            using (var db = new HumanResourceContext("path\\Employees"))
            {
                var obj = db.Employees.Where(i => i.id == id).FirstOrDefault();
                return new EmployeeServiceDTO(obj);
            }
        }
        public bool Update(EmployeeServiceDTO obj)
        {
            throw new System.NotImplementedException();
        }
        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }


    #region Generic repository
    public class GenericRepository<T> : IRepository<T>
    {
        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public T Get(int id)
        {
            throw new System.NotImplementedException();
        }
        public List<T> GetAll()
        {
            using (var db = new GenericContext<T>("path"))
            {
                return db.GetAll();
            }
        }

        public bool Update(T obj)
        {
            throw new System.NotImplementedException();
        }
    }

    #endregion
    #region Generic Repository <ContextType, Request and Response > 
    // 
    public interface IRepository<T, S>
    {
        public List<S> GetAll();
        public S Get(int id);
        public bool Update(T obj);
        public bool Delete(int id);
    }
    public class GenericRepository<T, S> : IRepository<T, S>
    {
        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public S Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<S> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public bool Update(T obj)
        {
            throw new System.NotImplementedException();
        }
    }
    #endregion

}
