using DataLayer.Dto.HR;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace ServiceLayer.Services.HR
{
    public class HRService : IHRService
    {
        private readonly IConfiguration _configuration;

        readonly IRepository<EmployeesViewModelDToReq, HRServiceDToRes> repository;
        ModelValidator Modelvalidator;
        HRValidator validator;
        public HRService(IRepository<EmployeesViewModelDToReq, HRServiceDToRes> Repository)
        {
            repository = Repository;
            Modelvalidator = new ModelValidator();
            validator = new HRValidator();
        }
        public List<EmployeesViewModelDTo> GetAllEmployees()
        {
            return repository.GetAllEmployees().Select(i => new EmployeesViewModelDTo(i)).ToList();
        }
        public List<EmployeesViewModelDTo> GetAllUnemployed()
        {
            //return DbContext.GetAllEmployees
            //    .Where(i => i.Salary == 0).Select(i => new EmployeesViewModelDTo(i)).ToList(); 
            return null;

        }
        public EmployeesViewModelDTo GetEmployee(EmployeesViewModelDToReq hRServiceDToReq)
        {
            #region Validation
            //try
            //{
            //    //var results = validator.Validate(hRServiceDToReq);

            //    var results = Modelvalidator.ValidateModel(hRServiceDToReq);

            //    if (Modelvalidator.ValidateModel(hRServiceDToReq).Count > 0)
            //    {
            //        return new EmployeesViewModelDTo() { Errors = results.Select(i => i.ErrorMessage).ToList() };
            //    }
            //    else
            //    {
            //        return new EmployeesViewModelDTo(repository.Get(hRServiceDToReq));
            //    }
            //}
            //catch
            //{
            //    throw;
            //}   
            #endregion
            try
            {
                return new EmployeesViewModelDTo(repository.Get(hRServiceDToReq));
            }
            catch (System.Exception)
            {

                throw;
            }
        }

    }
}


