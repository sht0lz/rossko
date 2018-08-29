using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Api.Extensions
{
    public static class StringExtension
    {
        public static Boolean IsLatinAndNumberString(this String input)
        {
            return !Regex.IsMatch(input, "[^a-zA-Z0-9]");
        }
    }
}