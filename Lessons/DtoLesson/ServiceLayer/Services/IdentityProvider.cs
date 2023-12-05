using DataLayer.Dto;

namespace ServiceLayer.Services
{
    internal class IdentityProvider
    {

        public static bool IsRegistered(HRServiceDToRes employeesServiceDTo)
        {
            return employeesServiceDTo.IsLocked;
        }

    }
}
