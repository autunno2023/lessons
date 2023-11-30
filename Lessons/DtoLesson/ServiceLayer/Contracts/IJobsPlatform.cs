using DataLayer.Models;
using System.Collections.Generic;

namespace ServiceLayer.Contracts
{
    public interface IJobsPlatform : IHRPlatform
    {
        public Jobs Get(string Title);
        public List<Jobs> GetAll();

    }
}

