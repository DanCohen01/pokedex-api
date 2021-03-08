using System;
using System.Collections.Generic;
using System.Text;

namespace pokedex.Application.Helpers
{
    public static class StringFormatter
    {
        public static string FormatString(string input)
        {
           
            var formatted = input?.Replace("\n", " ").Replace("\f", " ");
            return formatted;
        }
    }
}
