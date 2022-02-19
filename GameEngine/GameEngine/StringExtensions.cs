using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine
{
    public static class StringExtensions
    {
        public static string ToTitleCase(this string value)
        {
         return value.Replace(value.Substring(0, 1), value.Substring(0, 1).ToUpper());
        }
    }
}
