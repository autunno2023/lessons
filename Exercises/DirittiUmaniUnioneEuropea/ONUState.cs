using Polimorfismo.Interfaces;

namespace Polimorfismo
{
    public class ONUState : State, IONU
    {
        public void PopulationControl() { }
        public void TerritoryControl() { }
        public ONUState(string Name, string State, string Government, string Constitution) :
           base(Name, State, Government, Constitution)
        {
           
        }
    }
} 

    