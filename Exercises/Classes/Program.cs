using System;

namespace Classes
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string product = null; // compiler error - this is a non-nullable type
            string? product2 = null; // no error - this is a nullable type
            Console.WriteLine(product);
            Console.WriteLine(product2);

            Person person1 = new Person(
                "Bruno",
                "Ferreira",
                40,
                92,
                29,
                false,
                0,
                false,
                true,
                900000M
                );

            person1.getValues();

            person1.Universita = 28;
            Console.WriteLine(person1.Bonus);

        }
        internal class Person
        {
            static int counter = 0;
            string _name;
            string _surname;
            int _age;
            bool _isAdult;
            bool _bonus;
            decimal _pilComune;
            int _maturita;
            int _universita;
            bool _fedinaPenale;
            int _figli;
            bool _militare;
            bool _debiti;
            int _punteggio;
            const int indeceBonus = 35;

            public string Name { get { return _name; } }
            public string Surname { get { return _surname; } }
            public string FullName { get { return _name + " " + _surname; } }
            public bool IsAdult { get { return _isAdult; } }

            public decimal PilComune
            {
                get { return _pilComune; }
                set
                {
                    if (value < 1000)
                    {
                        _punteggio += 4;
                    }
                    _pilComune = value;
                }
            }

            public int Maturita
            {
                get => _maturita;
                set
                {
                    if (_maturita >= 90)
                    {
                        _punteggio += 7;
                    }
                    _maturita = value;
                }
            }

            public int Universita
            {
                get => _universita;
                set
                {
                    if (_universita >= 28)
                    {
                        _punteggio += 6;

                    }
                    _universita = value;
                }
            }

            public bool Bonus
            {
                get
                {
                    SetBonus();
                    return _bonus;
                }
                private set => _bonus = value;
            }

            public bool FedinaPenale { get => _fedinaPenale; set => _fedinaPenale = value; }

            public Person(

                string Name,
                string Surname,
                int Age,
                int Maturita,
                int Universita,
                bool FedinaPenale,
                int Figli,
                bool Militare,
                bool Debiti,
                decimal PilComune
                ) // firma del costruttore
            {
                _name = Name;
                _surname = Surname;


                // variabili per il BONUS 
                _age = Age;
                this.Maturita = Maturita;
                this.Universita = Universita;
                this.FedinaPenale = FedinaPenale;
                _figli = Figli;
                _militare = Militare;
                _debiti = Debiti;
                _pilComune = PilComune;
                this.PilComune = PilComune;
                setIsAdult();
            }
            public void getValues()
            {
                //Console.WriteLine(
                //$"Nome:{_name}\n " +
                //$"Cognome:{_surname}\n" +
                //$"Age:{_age}" +
                //$"Maturita:{_maturita}" +
                //$"FedinaPenale:{_fedinaPenale}" +
                //$"Debiti: {_debiti}"
                //);

                Console.WriteLine($"Age:{_age}");
                Console.WriteLine($"Maturita:{Maturita}");
                Console.WriteLine($"Debiti:{_debiti}");
                Console.WriteLine($"FedinaPenale:{_fedinaPenale}");
                Console.WriteLine($"Militare:{_militare}");
                Console.WriteLine($"Figli:{_figli}");
            }
            public int getCounter()
            {
                return counter;
            }

            private void setIsAdult()
            {
                if (_age > 18)
                {
                    _isAdult = true;
                }
                else
                {
                    _isAdult = false;
                }
            }
            private void SetBonus()
            {
                if (_punteggio >= 30)
                {
                    _bonus = true;
                }
            }

        }

    }
}
