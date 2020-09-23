using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExercises
{
    static class StringExtensionClass
    {
        public static string CapitalizeFirstLetter(this string value)
        {
            value = value[0].ToString().ToUpper() + value.Substring(1);
            return value;
        }
    }
}
