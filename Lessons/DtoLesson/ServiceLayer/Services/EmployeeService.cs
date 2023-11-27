using DataLayer.Repository;
using ServiceLayer.Dto;
using System.Collections.Generic;
using System.Linq;

namespace ServiceLayer.Services
{
    public class EmployeeService
    {

        readonly EmployeeRepository Repository;
        public EmployeeService()
        {
            Repository = new EmployeeRepository();
        }
        public List<EmployeeViewDTO> GetAllEmployees()
        {
            List<EmployeeViewDTO> EmployeeViewDTO = new();
            List<EmployeeResponseDTO> EmployeeDTO = Repository.GetAll().ToList();

            foreach (var item in EmployeeDTO)
            {
                EmployeeViewDTO.Add(new EmployeeViewDTO(item));
            }
            return EmployeeViewDTO;
        }
        public List<EmployeeViewDTO> GetAllEmployeesByCompany(string companyName)
        {
            List<EmployeeViewDTO> EmployeeViewDTO = new();
            List<EmployeeResponseDTO> EmployeeDTO = Repository.GetAll().ToList();

            foreach (var item in EmployeeDTO.Where(i => i.Company == companyName))
            {
                EmployeeViewDTO.Add(new EmployeeViewDTO(item));
            }
            return EmployeeViewDTO;
        }
        public List<EmployeeViewDTO> GetAllEmployeeByName(string Name)
        {
            List<EmployeeViewDTO> EmployeeViewDTO = new();
            List<EmployeeResponseDTO> EmployeeDTO = Repository.GetAll().ToList();

            foreach (var item in EmployeeDTO.Where(i => i.Name == Name))
            {
                EmployeeViewDTO.Add(new EmployeeViewDTO(item));
            }
            return EmployeeViewDTO;
        }
    }
}

