using DirittiUmaniUnioneEuropea.Interfaces;
using System;

namespace Polimorfismo
{
    abstract public class State : GeoArea, IAdministrationEntity
    {
        private string name;
        private string _government;
        private string _constitution;

        public string Name { get => name; set => name = value; }
        public string Government { get => _government; set => _government = value; }
        public string Constitution { get => _constitution; set => _constitution = value; }

        public State()
        {

        }
        public State(string Name, string State, string Government, string Constitution)
        {
            name = Name;
            _government = Government;
            _constitution = Constitution;
            ShowState();
        }
        void ShowState()
        {
            Console.WriteLine($"{Name} -  {Constitution}");
        }

    }
}
