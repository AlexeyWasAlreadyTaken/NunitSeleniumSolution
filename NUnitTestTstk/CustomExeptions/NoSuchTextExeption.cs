using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTestTstk.CustomExeptions
{
    class NoSuchTextExeption : System.Exception
    {
        public NoSuchTextExeption(){}
        public NoSuchTextExeption(string text) : base($"Error: {text}") { }
    }
}
