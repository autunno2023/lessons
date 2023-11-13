using Polimorfismo.Interfaces;
using System;

namespace Polimorfismo
{
    public class EUCountry : ONUState, IEuropeanUnion
    {
        // UE Contracts
        public void HumanRights() { }
        public void ConstitutionIntegration()
        {
            Constitution += "EU Costitution";
            Console.WriteLine($"{Name} -  {Constitution}");
        }

        public EUCountry(string Name, string State, string Government, string Constitution) :
            base(Name, State, Government, Constitution)
        {
            ConstitutionIntegration();
        }




        // ONU Contracts
        public virtual void PopulationControl()
        {


            Console.WriteLine("Polizia di Frontiera");
            Console.WriteLine("--------------------------------");

        }
        public virtual void TerritoryControl()
        {

            Console.WriteLine("ARMY");
            Console.WriteLine("--------------------------------");

        }
        public virtual void startpermesso()
        {

        }
    }

}

