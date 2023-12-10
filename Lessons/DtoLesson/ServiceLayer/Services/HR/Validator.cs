using DataLayer.Dto.HR;
using FluentValidation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
namespace ServiceLayer.Services.HR
{
    public class ModelValidator
    {
        public List<ValidationResult> ValidateModel(EmployeesViewModelDToReq model)
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(model, serviceProvider: null, items: null);
            Validator.TryValidateObject(model, validationContext, validationResults, true);
            return validationResults;
        }
    }

    #region fLUENTvALIDATOR
    public class HRValidator : AbstractValidator<EmployeesViewModelDToReq>
    {
        public HRValidator()
        {


            RuleFor(req => req.Age)
                .InclusiveBetween(18, 30).WithMessage("L'età deve essere compresa tra 18 e 30 anni.");

            RuleFor(req => req.Email)
                .NotEmpty()
                .EmailAddress().WithMessage("L'email inserita non è valida.");

            #region Custom Validators


            RuleFor(req => req.CodiceFiscale)
           .Must(BeAValidCodiceFiscale).WithMessage("Formato del codice fiscale non valido");
        }
        private bool BeAValidCodiceFiscale(string codiceFiscale)
        {
            if (string.IsNullOrWhiteSpace(codiceFiscale))
                return false;

            var regex = new Regex(@"^[A-Z]{6}\d{2}[A-Z]\d{2}[A-Z]\d{3}[A-Z]$");
            return regex.IsMatch(codiceFiscale);
        }
        #endregion
    }
    #endregion

    //public class ServiceValidatorException : Exception
    //{
    //    public List<string> Errors { get; }
    //    public ServiceValidatorException(IEnumerable<ValidationResult> failures) : base("One or more validation failures have occurred.")
    //    {
    //        Errors = failures.Select(i => i.ErrorMessage).ToList();
    //        //.ToList(e => e.ErrorMessage)
    //        //.ToList(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
    //    }
    //}
}
