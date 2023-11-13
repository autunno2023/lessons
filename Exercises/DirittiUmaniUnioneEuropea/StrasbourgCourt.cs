using Polimorfismo.Interfaces;
using System;

namespace Polimorfismo
{
    public class StrasbourgCourt
    {
        /*
        La corte di Strasbourgo deve poter vigilare su tutti i paesi del mondo che fanno parte dell'ONU.
        Ha una funzione di controllo e fa da garante a livello globale, concessa dall'ONU stessa.
        */
        public static void HumanRightsInvestigation(IONU ONUState) // UPCASTING
        {
            try
            {
                // Downcasting           
                CapitalPunishmentCountry capitalPunishmentONUcountry = (CapitalPunishmentCountry)ONUState;



                System.Console.WriteLine($"HumanRightsInvestigation - {capitalPunishmentONUcountry.Name} has NO Human Rights!");
                Console.WriteLine("--------------------------------");


            }
            catch (InvalidCastException ex)
            {
                ONUState country = (ONUState)ONUState; // DONWCASTING
                System.Console.WriteLine($"HumanRightsInvestigation - {country.Name} HAS Human Rights. - FREE ASSANGE !");
                Console.WriteLine("--------------------------------");

            }
        }
    }
}

