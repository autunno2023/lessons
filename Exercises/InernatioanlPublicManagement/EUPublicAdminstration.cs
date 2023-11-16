using InernatioanlPublicManagement.Contracts;
using System;

namespace InernatioanlPublicManagement
{
    public abstract class EUPublicAdminstration : AreaGoografica, IEUPublicAdminstration
    {
        public void PA_Education()
        {
            throw new NotImplementedException();
        }
        public void PA_HNS()
        {
            throw new NotImplementedException();
        }
        public void PA_Justice()
        {
            throw new NotImplementedException();
        }
        public void TerritoryManagement(State Claimer, State Dest)
        {
            EUParliament.ManageTerritoryConflict(Claimer, Dest);
        }
        public abstract void Welfare();

    }
}
