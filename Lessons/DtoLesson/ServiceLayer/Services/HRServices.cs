using DataLayer.Models;
using DataLayer.Repository;
using ServiceLayer.Dto;
using System;
using System.Collections.Generic;


namespace ServiceLayer.Services
{

    public class HRServices<T, S, V>
        where T : HR, new()
        where V : HRDto, new()

    {
        readonly IRepository<T, S> Repository;
        public HRServices()
        {
            Repository = new GenericRepository<T, S>();
        }
        public List<V> GetAll()
        {
            List<V> ViewDTO = new();  // V -> ViewDto
            List<S> ServiceDTO = Repository.GetAll(); // S -> ServiceDto

            foreach (S item in ServiceDTO)
            {
                //  ViewDTO.Add(new S(item));    
                V instance = (V)Activator.CreateInstance(typeof(V), new object[] { item });
                ViewDTO.Add(instance);

            }
            return ViewDTO;
        }
        //public List<EmployeeViewDTO> GetAllEmployeesByCompany(string companyName)
        //{
        //    List<EmployeeViewDTO> EmployeeViewDTO = new();
        //    List<EmployeeResponseDTO> EmployeeDTO = Repository.GetAll().ToList();

        //    foreach (var item in EmployeeDTO.Where(i => i.Company == companyName))
        //    {
        //        EmployeeViewDTO.Add(new EmployeeViewDTO(item));
        //    }
        //    return EmployeeViewDTO;
        //}
        //public List<EmployeeViewDTO> GetAllEmployeeByName(string Name)
        //{
        //    List<EmployeeViewDTO> EmployeeViewDTO = new();
        //    List<EmployeeResponseDTO> EmployeeDTO = Repository.GetAll().ToList();

        //    foreach (var item in EmployeeDTO.Where(i => i.Name == Name))
        //    {
        //        EmployeeViewDTO.Add(new EmployeeViewDTO(item));
        //    }
        //    return EmployeeViewDTO;
        //}
    }

}
