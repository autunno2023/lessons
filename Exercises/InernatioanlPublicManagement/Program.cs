using System;

namespace InernatioanlPublicManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string comune = "Merano"; // Il comune conteso


            State PeaseOrigine = new State("IT");
            string RegioneOrigine = "SudTirol";
            string ProvinciaOrigine = "Bolzano";

            State PeaseDestinazione = new State("AT");
            string RegioneDestinazione = "Tirolo";
            string ProvinciaDestinazione = "Innsbruck";

            ChangeComune(
                PeaseOrigine,
                PeaseDestinazione,
                RegioneOrigine,
                RegioneDestinazione,
                ProvinciaOrigine,
                ProvinciaDestinazione,
                comune);
        }

        static void ChangeComune(State PaeseOrigine, State PaeseDestinazione, string RegioneOrigine, string RegioneDestinazione, string ProvinciaOrigine, string ProvinciaDestinazione, string Comune)
        {

            State italy = new State("IT");
            italy.CreateRegione("SudTirolo");
            italy.CreateProvincia("SudTirolo", "Bolzano");
            italy.CreateComune("SudTirolo", "Bolzano", "Merano");
            italy.ShowComune("Merano");// Output 

            Console.WriteLine("--------------------------------");
            Console.WriteLine("CAMBIO COMUNE");
            Console.WriteLine("--------------------------------");
            State Austria = new State("AT");
            italy.ChangeComune(Austria, "Tirolo", "innsbruck", "Merano");
            italy.ShowComune("Merano");

            Console.ReadLine();
        }
    }
}
