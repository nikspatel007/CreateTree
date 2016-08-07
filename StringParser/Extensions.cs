using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StringParser
{

    public static class Extensions
    {
        /// <summary>
        /// Extension to Parse string and return it in Tree format to write it to persistence mechanisms.
        /// </summary>
        /// <param name="value">raw string to be formatted into the tree like string.</param>
        /// <returns>tree like string.</returns>
        public static string ParseString(this string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                var parser = new Parser(value);
                value = parser.Parse().ToString();
            }
            return value;
        }
    }
}
