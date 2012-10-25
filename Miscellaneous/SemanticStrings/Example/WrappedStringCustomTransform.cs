using System;
using System.Text.RegularExpressions;

namespace Miscellaneous.SemanticStrings.Example
{
    partial struct WrappedStringCustomTransform
    {
        static string MyCustomTransform(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return null;
            }

            const string pattern = @"CUSTOM\d+";
            if (Regex.IsMatch(str, pattern, RegexOptions.IgnoreCase))
            {
                return str.ToUpper();
            }
            else
            {
                //add logging
                Console.WriteLine("The string '{0}' must start with the word CUSTOM", str);
                return null;
            }
        }
    }
}
