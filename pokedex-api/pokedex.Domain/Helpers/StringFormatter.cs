using System;
using System.Collections.Generic;
using System.Text;

namespace pokedex.Domain.Helpers
{
    public static class StringFormatter
    {
        public static string FormatString(string input)
        {
            var formatted = input;
            formatted = formatted?.Replace("\n", " ");
            formatted = formatted?.Replace("\f", " ");
            return formatted;
        }
    }
}
