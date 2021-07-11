using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp9
{
    public static class Extensions
    {
        public static IEnumerator<T> GetEnumerator<T>(this IEnumerator<T> enumerator) => enumerator;


        public static void GetEnumeratorSupport()
        { 
            IEnumerator<string> countryEnumerator = (IEnumerator<string>)new List<string> { "France", "Canada", "Japan" };

          //  countryEnumerator.GetEnumerator();

            // Before C# 9: Error CS1579  foreach statement cannot operate on variables of type 'IEnumerator<string>' 
            // because 'IEnumerator<string>' does not contain a public instance or extension definition for 'GetEnumerator'
            foreach (var country in countryEnumerator)
            {
                Console.WriteLine($"{country} is a beautiful country");
            }
        }
    }
}
