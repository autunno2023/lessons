namespace Dynamics.Lesson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            State italy = new State();
            var response = italy.CreateRegion("Name");
        }
    }

    internal class State
    {
        internal Region CreateRegion(string Name)
        {
            return new Region(Name);
        }

        #region Nested Class
        private class Region
        {
            string _name;
            public string Name { get => _name; }

            public Region(string Name)
            {
                _name = Name;
            }

        }
        #endregion

    }
}
