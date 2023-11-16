using System;

namespace InernatioanlPublicManagement
{
    public partial class State
    {
        private sealed partial class Regione
        {
            private sealed partial class Provincia : EUPublicAdminstration
            {

                Comune _comune;
                public string _name;
                public string Name { get => _name; set => _name = value; }
                public Provincia(string ProvinciaName)
                {
                    _name = ProvinciaName;
                }
                void AddComune(Comune Comune)
                {
                    _comune = Comune;
                }
                public void CreateComune(string ComuneName)
                {
                    _comune = new Comune(ComuneName);
                }
                public void ChangeComune(string Provincia, string Milano)// Milano
                {
                    //Aggiungno alla provincia di Milano passato come argomento+

                    // AddComune viene chimato su Milano. 
                    this.AddComune(this._comune); // _comune è il comune di Torino


                    // a questo punto il comune è gia associato all'altra provincia,
                    // posso cancellarlo da questa provincia
                    _comune = null;

                }
                public void ShowComune(string Comune)
                {
                    Console.WriteLine($"Provincia: {this._name}");
                }
                public override sealed void Welfare()
                {
                    Console.WriteLine($"Implemented by local entity Comune  {this._name}");
                }
            }
        }
    }
}
