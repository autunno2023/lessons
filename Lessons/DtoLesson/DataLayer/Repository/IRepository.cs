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
    public class EmployeeRepository : IRepository<EmployeeResponseDTO> // Response
    {
        public List<EmployeeResponseDTO> GetAll()
        {
            using (var db = new HumanResourceContext("path\\Employees"))
            {
                return db.Employees.Select(i => new EmployeeResponseDTO(i)).ToList();
            }
        }
        public EmployeeResponseDTO Get(int id)
        {
            using (var db = new HumanResourceContext("path\\Employees"))
            {
                var obj = db.Employees.Where(i => i.id == id).FirstOrDefault();
                return new EmployeeResponseDTO(obj);
            }
        }
        public bool Update(EmployeeResponseDTO obj)
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
    #region Generic Repository <RepositoryType, Request and Response >
    public interface IRepository<T, RQ, RS>
    {
        public List<RQ> GetAll();
        public RS Get(int id);
        public bool Update(T obj);
        public bool Delete(int id);
    }
    #endregion

}
