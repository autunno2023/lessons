using AutoMapper;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DataLayer.DbContext
{

    // ORM  

    internal class GenericDbContext<T, Res> : DbContext
        where T : HR, new()
        where Res : class, new()
    {
        private readonly IMapper _mapper;
        public List<Res> Data; // EmployeesServiceDTo
        public GenericDbContext(string path) : base(path)
        {

            var dataFromDb = ReadFromDb<T>(path + typeof(T).Name.ToString() + ".csv");

            // Assuming Res has a constructor that accepts a T instance
            Data = dataFromDb.Select(item => Activator.CreateInstance(typeof(Res), item)).Cast<Res>().ToList();
        }

    }
}
