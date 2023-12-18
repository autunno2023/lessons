using System;
using System.Threading;

namespace Lesson.Delegates
{

    public delegate void HealthDataDelegate();// 
    public delegate string DataDelegate();// 

    internal class Program
    {
        static void Main(string[] args)
        {
            EUDigitalWallet eUDigitalWallet = new EUDigitalWallet("RTERYEHTHTRHTHRTY");


            HealthDataDelegate healthData = eUDigitalWallet.GetTaxInfo;
            AssicurazioneSanitaria.CreateNewAssurance(healthData);


            // MultiDelegate 
            DataDelegate datiSanitari, datiLegali, datiFiscali, multiDelegate;
            // datiSanitari = eUDigitalWallet.getClinicalStatus;
            datiLegali = eUDigitalWallet.GetPenalStatus;
            datiFiscali = eUDigitalWallet.GetTaxInfo;

            //multiDelegate = datiSanitari;
            //multiDelegate += datiLegali;
            //multiDelegate += datiFiscali;

            // multiDelegate();// all 

            //foreach (var del in multiDelegate.GetInvocationList())
            //{
            //    del.DynamicInvoke(); // One by one
            //}

            //multiDelegate += () =>
            //{
            //    string s = "Ciao Mondo";
            //    Console.WriteLine(s);
            //    return s;
            //};



            // Action -> get parameter - void (T t)
            // Func ->   T (T1, T1, T2, T3)
            // Prediate -> bool (T ) 


            Action action = () => { Console.WriteLine("Ciao"); };
            Action<string, int> actionS = (s, n) => { Console.WriteLine(s); };
            Action<string> actionS2 = delegate (string s) { Console.WriteLine(s); };

            // Func 

            Func<int, int, bool, string> Randomfunc = (x, y, proceed) =>
            {
                Random rdn = new Random();
                return proceed ? rdn.Next(x, y).ToString() : string.Empty;
            };


            string result = Randomfunc(10, 100, true);

            // Predicate 
            int[] ages = new int[] { 10, 20, 50 };
            Predicate<int> filter = delegate (int age)
            {
                return age > 40 ? true : false;
            };

            int index = Array.IndexOf(ages, Array.Find(ages, filter));

            TimerCallback timerCallback = new TimerCallback(Printtime);
            Timer timer = new Timer(timerCallback, "Hello", 5000, 3000);

        }
        public static void Printtime(object state)
        {
            Console.WriteLine("Time is {0}, Parameter is: {1}", DateTime.Now.ToLongTimeString(), state.ToString());
        }

    }

    public class EUDigitalWallet
    {
        string _owner;
        string _diploma = "Maturità";
        string _taxInfo;
        string _penalStatus;
        string _clinicalstatus = "Situazione sanitaria è OK";
        public EUDigitalWallet(string CF)
        {
            _owner = CF;
        }

        public string GetPenalStatus()
        {
            Console.WriteLine(_penalStatus); ;
            return _penalStatus;
        }
        public void getClinicalStatus()
        {
            Console.WriteLine(_clinicalstatus); ;

        }
        public string GetTaxInfo()
        {
            Console.WriteLine(_taxInfo); ;
            return _taxInfo;
        }
        public string GetEducationInfo()
        {
            Console.WriteLine(_diploma); ;
            return _diploma;
        }
    }
    class AssicurazioneSanitaria
    {
        public AssicurazioneSanitaria()
        {

        }
        public static void CreateNewAssurance(Func<string> eUDigitalWallet)
        {
            eUDigitalWallet(); //callback 
        }
    }
}
