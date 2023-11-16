using System;

namespace InernatioanlPublicManagement
{
    public partial class State
    {
        private sealed partial class Regione : EUPublicAdminstration
        {

            string _name;
            Provincia _provincia;
            public string Name { get => _name; set => _name = value; }

            public Regione(string Name)
            {
                _name = Name;
            }

            void AddProvincia(Provincia provincia)
            {
                _provincia = provincia;
            }
            public void CreateProvincia(string provincia)
            {
                _provincia = new Provincia(provincia);
            }
            public void ChangeProvincia(string Regione)
            {
                Regione regione = new Regione(Regione); // Nella 
                regione.AddProvincia(_provincia);
            }
            public void CreateComune(string NomeComune, string NomeProvincia)
            {
                _provincia = new Provincia(NomeProvincia);
                _provincia.CreateComune(NomeComune);// innsbruck
            }
            public void ChangeComune(string Provincia, string Comune)
            {
                _provincia = new Provincia(Provincia);
                _provincia.ChangeComune(Provincia, Comune);
            }
            public void ShowComune(string Comune)
            {
                Console.WriteLine($"Regione: {this._name}");
                _provincia.ShowComune(Comune);
            }
            public override sealed void Welfare()
            {
                Console.WriteLine($" Implemented by  region : {this._name}");
            }
        }
    }
}
