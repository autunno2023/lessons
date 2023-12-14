using DataLayer.Dto.HR;
using System.Collections.Generic;

namespace ServiceLayer.Services.HR
{
    public interface IHRService
    {
        List<EmployeesViewModelDTo> GetAllEmployees();
        List<EmployeesViewModelDTo> GetAllUnemployed();
        EmployeesViewModelDTo GetEmployee(EmployeesViewModelDToReq hRServiceDToReq);
    }
}