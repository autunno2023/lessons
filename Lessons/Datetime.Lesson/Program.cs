using System;
using System.Globalization;
using System.Threading;

namespace Datetime.Lesson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             Data e Ora Complete: Il formato completo è YYYY - MM - DDTHH:MM: SS, 
             dove YYYY è l'anno, MM è il mese,
             DD è il giorno, T è un separatore (che sta per Time),
             HH sono le ore, MM i minuti e SS i secondi.
             Fuso Orario: Il fuso orario può essere specificato aggiungendo un offset rispetto all'UTC (Coordinated Universal Time). Ad esempio, +02:00 indica due ore avanti rispetto all'UTC, -05:00 indica cinque ore indietro. Se l'ora è in UTC, si aggiunge Z (da Zulu) alla fine, come in YYYY-MM-DDTHH:MM:SSZ.
             Data senza Ora: Puoi anche rappresentare solo la data, come YYYY - MM - DD.
             Ora senza Data: È anche possibile rappresentare solo l'ora, come THH:MM:SS, THH:MM:SSZ, o THH:MM:SS+02:00.

             Esempi
             Data e Ora UTC: 2023 - 11 - 26T15: 20:30Z
             Data e Ora con Fuso Orario: 2023 - 11 - 26T10: 20:30 - 05:00(che indica le 10:20:30 del mattino nel fuso orario UTC - 5)
             Solo Data: 2023 - 11 - 26
             Solo Ora(UTC): T15: 20:30Z
            */
            DateTime dt = DateTime.UtcNow;
            //Console.WriteLine(dt);
            string iso8601DateTime = dt.ToString("o"); // Formattazione in ISO 8601
                                                       //Console.WriteLine(iso8601DateTime);

            //CalcDates();
            //TimeZonelist();
            // CreateTimeSpan();
            //AutomaticConvertion();
            CurrentCultureInfo();
        }

        static void CalcDates()
        {

            Console.WriteLine(DateTime.Now);

            DateTime berlin = new DateTime(1989, 11, 09);
            int yearBerlinWallFall = berlin.Year;
            int monthBerlinWallFall = berlin.Month;
            int dayBerlinWallFall = berlin.Day;

            int BerlinWallAniversary = DateTime.Now.Year - yearBerlinWallFall;

            Console.WriteLine(BerlinWallAniversary);
        }
        static void TimeZonelist()
        {
            TimeZoneInfo timeZoneNY = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            Console.WriteLine($"" +
                $"Pacific Standard Time: {TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, TimeZoneInfo.Local.Id, "Pacific Standard Time")}" +
               $"\nCentral Standard Time: {TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, TimeZoneInfo.Local.Id, "Central Standard Time")}" +
               $"\nIndia Standard Time: {TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, TimeZoneInfo.Local.Id, "India Standard Time")}" +
               $"\nEastern Standard Time: {TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, TimeZoneInfo.Local.Id, "Eastern Standard Time")}" +
               $"\nNY Time: {TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZoneNY)}" +
               $"\nTokyo Standard Time: {TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, TimeZoneInfo.Local.Id, "Tokyo Standard Time")}"


               );

        }
        static void GetDateFromInput()
        {
            //Console.WriteLine("Inserire una data:");
            //string input = Console.ReadLine();

            //DateTime result;

            //if (DateTime.TryParse(input, out result))
            //{
            //    Console.WriteLine($" TryParse da stringa a Data Riuscito: {result} ");
            //}
            //else
            //{
            //    Console.WriteLine(".....");
            //}
            #region DATE FORMATS
            //DateTime.Now.ToString("MM/dd/yyyy") --> 05 / 01 / 2015
            //DateTime.Now.ToString"dddd, dd MM(MM yyyy") --> Friday, 29 May 2015
            //DateTime.Now.ToString("dddd, dd MMMM yyyy") --> Friday, 29 May 2015 05:50
            //DateTime.Now.ToString("dddd, dd MMMM yyyy") --> Friday, 29 May 2015 05:50 AM
            //DateTime.Now.ToString("dddd, dd MMMM yyyy") --> Friday, 29 May 2015 5:50
            //DateTime.Now.ToString("dddd, dd MMMM yyyy") --> Friday, 29 May 2015 5:50 AM
            //DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss")    --> Friday, 29 May 2015 05:50:06
            //DateTime.Now.ToString("MM/dd/yyyy HH:mm") -->   05/ 29/2015 05:50
            //DateTime.Now.ToString("MM/dd/yyyy hh:mm tt") -->    05/29/ 2015 05:50 AM
            //DateTime.Now.ToString("MM/dd/yyyy H:mm") -->    05/29/2015 5:50
            //DateTime.Now.ToString("MM/dd/yyyy h:mm tt") --> 05/29/2015 5:50 AM
            //DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")  -->   05/29/2015 05:50:06
            //DateTime.Now.ToString("MMMM dd") -->    May 29
            //DateTime.Now.ToString("yyyy’-‘MM’-‘dd’T’HH’:’mm’:’ss.fffffffK") -->  2015 - 05 - 16T05: 50:06.7199222 - 04:00
            //DateTime.Now.ToString("ddd, dd MMM yyy HH’:’mm’:’ss ‘GMT’") -->  Fri, 16 May 2015 05:50:06 GMT
            //DateTime.Now.ToString("yyyy’-‘MM’-‘dd’T’HH’:’mm’:’ss") -->  2015 - 05 - 16T05: 50:06
            //DateTime.Now.ToString("HH:mm") -->  05:50
            //DateTime.Now.ToString("hh:mm tt") -->   05:50 AM
            //DateTime.Now.ToString("H:mm") -->   5:50
            //DateTime.Now.ToString("h:mm tt") -->    5:50 AM
            //DateTime.Now.ToString("HH:mm:ss") -->   05:50:06
            //DateTime.Now.ToString("yyyy MMMM")
            #endregion

            #region Force Specific Format and Culture  Expressed in string to DateTime Object

            string input2 = "mercoledì, 29 marzo 2023 02:30"; // > input utente
            string Dateformat = "dddd, dd MMMM yyyy HH:mm"; // Formato
            CultureInfo culture = new CultureInfo("It"); // > culture input
            DateTime output;


            if (DateTime.TryParseExact(input2, Dateformat, culture, DateTimeStyles.RoundtripKind, out output))
            {
                Console.WriteLine($"{output.ToString("dddd, dd MMMM yyyy HH:mm")} ");
            }
            else
            {
                Console.WriteLine("TryParse FAILED");
            }
            #endregion


        }
        static void CreateTimeSpan()
        {
            TimeSpan timeSpan = new TimeSpan(0, 23, 59, 59);

            DateTime myDate1 = DateTime.Now.Add(timeSpan);
            Console.WriteLine(myDate1);

            DateTime myDate2 = DateTime.Now.AddDays(120);
            Console.WriteLine(myDate2);

            DateTime myDate3 = myDate2.Subtract(timeSpan);
            Console.WriteLine(myDate3);
        }
        static void AutomaticConvertion()
        {
            string dateInUSA = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss", new CultureInfo("en-US"));
            string dateInFR = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss", new CultureInfo("fr-FR"));
            string dateInIT = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss", new CultureInfo("it"));
            string dateInDE = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss", new CultureInfo("de"));

            Console.WriteLine(dateInUSA);
            Console.WriteLine(dateInFR);
            Console.WriteLine(dateInIT);
            Console.WriteLine(dateInDE);
        }
        static void CurrentCultureInfo()
        {
            // Ottenere la cultura corrente del thread
            CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
            Console.WriteLine("Current Culture: " + currentCulture.Name);

            // Ottenere la cultura corrente dell'interfaccia utente
            CultureInfo currentUICulture = Thread.CurrentThread.CurrentUICulture;
            Console.WriteLine("Current UI Culture: " + currentUICulture.Name);

            // Oppure, utilizzando direttamente la classe CultureInfo
            CultureInfo directCurrentCulture = CultureInfo.CurrentCulture;
            Console.WriteLine("Direct Current Culture: " + directCurrentCulture.Name);
        }
    }
}
