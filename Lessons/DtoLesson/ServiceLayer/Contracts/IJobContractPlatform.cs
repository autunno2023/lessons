using DataLayer.Models;
using System.Collections.Generic;

namespace ServiceLayer.Contracts
{
    public interface IJobContractPlatform : IHRPlatform
    {
        public List<JobContract> GetAll();
        public JobContract Get(int Id);
    }
}

