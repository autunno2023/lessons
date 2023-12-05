using DataLayer.DbContext;
using DataLayer.Dto;
using DataLayer.Models;
using System.Collections.Generic;

namespace DataLayer.Repository
{


    public class HRRepository<T, Rq, Rs> : IRepository<T> where T : HR, new()
    {
        private readonly GenericDbContext<T, Rs> Db;

        public HRRepository(string path)
        {
            Db = new GenericDbContext<T, Rs>();
        }
        public void UpdateEmployees(List<T> employees)
        {
            Db.WriteData<T>(employees);
        }
        public List<Rs> GetAllEmployees()
        {
            return Db.Data;
        }
        public Rs GetByName(Rs rs)
        {
            return null;
        }

        List<T> IRepository<T>.GetAllEmployees()
        {
            throw new System.NotImplementedException();
        }
    }
    public class SocialMediaRepository : IHRRepository
    {
        private readonly HumanResouresDbContext Db;

        public HRRepository(string path)
        {
            Db = new HumanResouresDbContext(path);
        }
        public void UpdateEmployees(List<Employee> employees)
        {
            Db.WriteData<Employee>(employees);
        }
        public List<HRServiceDToRes> GetAllEmployees()
        {
            return Db.GetEmployees;
        }
    }
}

internal interface IRepository<T>
{

    /*****  DB ***** */
    //public T Get(int Id);
    //public T Update();
    //public T GetAll();
    //public T Delete(int Id);
    public List<T> GetAllEmployees();
    public void UpdateEmployees(List<T> employees);
}
