using DataLayer.Dto.HR;
using ServiceLayer.Services.HR;
using System.Linq;

namespace Presentation.Controllers
{
    internal class HRController : IHRController
    {
        readonly ModelValidator Modelvalidator;

        readonly HRValidator validator;
        readonly IHRService employementService;
        public HRController(IHRService hRService)
        {
            employementService = hRService;
            Modelvalidator = new ModelValidator();
            validator = new HRValidator();
        }
        public EmployeesViewModelDTo? GetEmployee(EmployeesViewModelDToReq hRDToReq)
        {
            try
            {
                var validatorResults = validator.Validate(hRDToReq);

                // var validatorResults = Modelvalidator.ValidateModel(hRDToReq);

                if (validatorResults.Errors.Count > 0)
                {
                    return new EmployeesViewModelDTo()
                    {
                        Errors = validatorResults.Errors.Select(i => i.ErrorMessage).ToList()
                    };
                }
                else
                {
                    return employementService.GetEmployee(hRDToReq);
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
