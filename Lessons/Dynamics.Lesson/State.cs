namespace Dynamics.Lesson
{
    internal partial class State
    {

        string _name;
        int _population;
        Regione[] _regioni;


        string Name { get => _name; set => _name = value; }
        Regione[] Regioni { get => _regioni; set { _regioni = value; } }
        int Population { get; set; } = 600000;

        public State(string Name)
        {
            _name = Name;
            _regioni = createRegioni();
        }
        public dynamic GetStateDynamic()
        {
            return this; // ritorno tutto l'oggetto STATE
        }
        public dynamic GetPrivateInfoByAnonymous()
        {
            return new
            {
                _name,
                _population,
                _regioni
            };

        }
        public dynamic GetPublicInfoAnonymous()
        {

            return new
            {
                Name,
                Regioni,
                Population
            };
        }
        Regione[] createRegioni()
        {
            return new Regione[] { new Regione("Lombardia"), new Regione("Veneto") };
        }
        #region Nested Class
        public class Regione
        {
            string _name;
            int _poplation;
            Provincia[] _province;
            Comune[] _comuni;
            public string Name { get => _name; }
            public int Population { get => _poplation; }
            public Provincia[] Province { get => _province; set => _province = value; }
            public Comune[] Comuni { get => _comuni; set => _comuni = value; }

            public Regione(string Name)
            {
                _name = Name;
                _province = CreateProvince();

            }
            Provincia[] CreateProvince()
            {
                return new Provincia[] { new Provincia("Milano") };
            }
        }
        public class Provincia
        {
            string _name;
            int _poplation;
            Comune[] _comuni;
            Cittadino[] _cittanini;
            public string Name { get => _name; }
            public int Population { get => _poplation; }
            public Comune[] Comuni { get => _comuni; set => _comuni = value; }

            public Provincia(string Name)
            {
                _name = Name;
                _comuni = CreateComuni();

            }
            public Comune[] CreateComuni()
            {
                return new Comune[] { new Comune("Lodi") };
            }
        }
        public class Comune
        {
            string _name;
            int _population;
            Cittadino[] _cittanini;

            public string Name { get => _name; }
            public int Population { get => _population; }
            public Cittadino[] Cittanini { get => _cittanini; set => _cittanini = value; }

            public Comune(string Name)
            {
                _name = Name;
                _cittanini = CreateCittadini();
            }
            public Cittadino[] CreateCittadini()
            {
                return new Cittadino[] { new Cittadino("Bruno") };
            }


        }
        public class Cittadino
        {
            string _name;
            int _population;
            public string Name { get => _name; }
            public int Population { get => _population; }

            public Cittadino(string Name)
            {
                _name = Name;
            }

        }

        #endregion
    }


}
