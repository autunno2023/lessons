using DataLayer.Dto.HR;
using ServiceLayer.Services.HR;
using System.Linq;

namespace Presentation.Controllers
{
    internal class HRController
    {
        readonly ModelValidator Modelvalidator;

        readonly HRValidator validator;
        readonly Service employementService;
        public HRController()
        {
            employementService = new Service();
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
