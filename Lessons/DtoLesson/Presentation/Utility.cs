using System;
using System.Reflection;
using System.Text;

namespace Presentation
{
    class Utility
    {
        public static void PrintGenericProps(object obj)
        {
            if (obj == null) return;

            var sb = new StringBuilder();
            Type objType = obj.GetType();
            PropertyInfo[] properties = objType.GetProperties();

            foreach (var prop in properties)
            {
                object propValue = prop.GetValue(obj, null);
                sb.AppendLine($"{prop.Name}: {propValue}");
            }

            Console.WriteLine(sb.ToString()); ;
        }
    }
}
