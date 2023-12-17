using System;

namespace Lesson.Delegates
{
    public delegate string HealthDataDelegate();

    internal class Program
    {
        static void Main(string[] args)
        {
            EUDigitalWallet eUDigitalWallet = new EUDigitalWallet("RTERYEHTHTRHTHRTY");
            HealthDataDelegate healthData = eUDigitalWallet.getClinicalStatus;

            AssicurazioneSanitaria.CreateNewAssurance(healthData);
        }
    }

    public class EUDigitalWallet
    {
        string _owner;
        string _diploma = "Maturità";
        string _taxInfo;
        bool _penalStatus;
        string _clinicalstatus = "Situazione sanitaria è OK";
        public EUDigitalWallet(string CF)
        {
            _owner = CF;
        }

        public bool GetPenalStatus()
        {
            Console.WriteLine(_penalStatus); ;
            return _penalStatus;
        }
        public string getClinicalStatus()
        {
            Console.WriteLine(_clinicalstatus); ;
            return _clinicalstatus;
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
        public static void CreateNewAssurance(HealthDataDelegate eUDigitalWallet)
        {
            eUDigitalWallet();
        }
    }
}
