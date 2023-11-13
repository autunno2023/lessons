using Polimorfismo.Interfaces;

namespace Polimorfismo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // upcasting 
            IONU USA = new CapitalPunishmentCountry("USA", "democratico", "Federale", "1789");
            IONU italy = new EuroZoneCountry("Italy", "democratico", "Parlamentare", "1947");
            IONU Argentina = new ONUState("Argentina", "democratico", "Parlamentare", "1922");


            EuroZoneCountry EuroItaly = (EuroZoneCountry)italy; // Downcasting


            EuroCentralBank.CalcSpread(EuroItaly);
            StrasbourgCourt.HumanRightsInvestigation(USA);
            StrasbourgCourt.HumanRightsInvestigation(italy);
            StrasbourgCourt.HumanRightsInvestigation(Argentina);


        }


    }
}

