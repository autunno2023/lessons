using DataLayer.Models;
using DataLayer.Repository;
using ServiceLayer.Dto;
using System.Collections.Generic;
using System.Linq;


namespace ServiceLayer
{

    internal class HRServices
    {
        readonly HrReposity hrReposity;
        public HRServices()
        {
            hrReposity = new HrReposity();
        }
        public HRViewModelDto GetAllByContry(County county)
        {
            List<Employee> Employees = hrReposity.GetAllEmployess().ToList();

            if ()
                return new HRViewModelDto(Employees.Where(i => i.County == county).FirstOrDefault());
        }
    }

}
