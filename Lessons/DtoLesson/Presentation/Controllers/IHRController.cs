using DataLayer.Dto.HR;

namespace Presentation.Controllers
{
    internal interface IHRController
    {
        EmployeesViewModelDTo? GetEmployee(EmployeesViewModelDToReq hRDToReq);
    }
}