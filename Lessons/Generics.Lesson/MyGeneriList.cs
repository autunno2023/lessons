using System;
using System.Linq;

namespace Generics.Lesson
{
    public class MyGeneriList<T> where T : class, new()
    {
        static int index = 4;
        T[] _data = new T[index];
        static T entry = new T();
        public MyGeneriList()
        {

        }
        public void AddItem(T item)
        {

            if (_data.All(x => x is not null))
            {
                GetMoreSpace();
            }
            else
            {
                T ele = Array.Find(_data, i => i is null);
                var element = Array.IndexOf(_data, ele);
                _data[element] = item;
            }


        }
        private void GetMoreSpace()
        {
            T[] _newArray = new T[_data.Length + 4];
            Array.Copy(_data, _newArray, _data.Length);
            _data = _newArray;
        }

        #region Refletions
        public static void PrintProperties()
        {
            var campi = entry.GetType().GetProperties();

            foreach (var item in campi)
            {
                Console.WriteLine(item.Name);
            }
        }
        public static void ShowAllMethods()
        {

            var tm = typeof(Person);
            foreach (var mi in tm.GetMethods())
            {
                Console.WriteLine(mi.Name); ;
                foreach (var p in mi.GetParameters())
                {
                    Console.WriteLine($"\t{p.ParameterType.Name}");
                }
            }
        }
        #endregion





    }
}
