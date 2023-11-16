using System;

namespace InernatioanlPublicManagement
{
    public partial class State
    {
        private sealed partial class Regione
        {
            private sealed partial class Provincia
            {
                private sealed class Comune : EUPublicAdminstration
                {
                    string _name;
                    EUID EUCitizen { get; set; }

                    public Comune(string Name)
                    {
                        _name = Name;
                    }
                    public void TerritoryManagement()
                    {
                        throw new NotImplementedException();
                    }
                    public override void Welfare()
                    {
                        Console.WriteLine($"Implemented by local  entity Comune  {this._name}");
                    }
                    public EUID CreateCitizen(Person Person)
                    {
                        EUCitizen = new EUID
                        {
                            Surname = Person.Name,
                            Name = Person.Name
                        };
                        return EUCitizen;
                    }
                }
            }
        }
    }



}
