using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp9
{
    public record Teacher(string FirstName, string LastName, int Grade)
        : Person(FirstName, LastName, new string[1]);


    public record Student(string FirstName, string LastName, int Grade)
        : Person(FirstName, LastName, new string[1]);
}
