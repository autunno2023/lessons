using System;

namespace InernatioanlPublicManagement
{
    public partial class State : EUPublicAdminstration
    {
        string _name;
        Regione _regione;
        public string Name { get => _name; set => _name = value; }

        public State(string NomePaese)
        {
            Name = NomePaese;
        }
        void AddRegione(Regione regione)
        {
            _regione = regione;
        }
        public void CreateRegione(string NomeRegione)
        {
            _regione = new Regione(NomeRegione);
        }
        public void ChangeRegione(State paese)
        {
            paese.AddRegione(_regione);
        }
        public void CreateProvincia(string Regione, string NomeProvincia)
        {
            _regione.ChangeProvincia(NomeProvincia);
        }
        public void ChangeProvincia(string Regione, string Provincia)
        {
            Regione regione = new Regione(Regione);
            regione.ChangeProvincia(Provincia);
        }
        public void CreateComune(string Regione, string Provincia, string Comune)
        {
            _regione.CreateComune(Comune, Provincia);
        }
        public void ChangeComune(State paeseDest, string RegioneDest, string Provincia, string Comune)
        {
            this.Name = paeseDest.Name;
            paeseDest._regione = new Regione(RegioneDest);// Tirolo
            _regione.ChangeComune(Provincia, Comune);

        }
        public void ShowComune(string Comune)
        {
            Console.WriteLine($"Il comune di {Comune} in questo momento appartiente a: ");
            Console.WriteLine($"Paese: {this.Name}");
            _regione.ShowComune(Comune);

        }
        public override void Welfare()
        {
            throw new NotImplementedException(); // Delegate to regions 
        }
    }
}
