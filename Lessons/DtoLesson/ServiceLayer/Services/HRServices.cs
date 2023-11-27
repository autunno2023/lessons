using DataLayer.Repository;
using ServiceLayer.Dto;
using System;
using System.Collections.Generic;


namespace ServiceLayer.Services
{

    internal class HRServices<T, RQ, RP> where T : IRepository<T, RQ, RP>, new() where RQ : HRDto, new()
    {
        readonly T Repository;
        public HRServices()
        {
            Repository = new T();
        }
        public List<RP> GetAll()
        {
            List<RP> ViewDTO = new();
            List<RQ> ServiceDTO = Repository.GetAll();

            foreach (RQ item in ServiceDTO)
            {
                //  ViewDTO.Add(new RP(item));  
                ViewDTO.Add((RP)Activator.CreateInstance(typeof(RQ)));
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
