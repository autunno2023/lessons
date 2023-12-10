using DataLayer.Dto.HR;

namespace ServiceLayer.Services.IdentityProvider
{
    internal class Service
    {
        public static bool IsRegistered(HRServiceDToRes employeesServiceDTo)
        {
            return employeesServiceDTo.IsLocked;
        }

    }
}
