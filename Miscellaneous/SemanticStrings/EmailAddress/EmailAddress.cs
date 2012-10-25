using System.Text.RegularExpressions;

namespace Miscellaneous.SemanticStrings.EmailAddress
{
public partial struct EmailAddress
{
    public static string TransformEmailAddress(string str)
    {
        if (string.IsNullOrWhiteSpace(str))
        {
            return null;
        }

        const string pattern = @"^[A-Z0-9._%-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$";
        if (Regex.IsMatch(str, pattern, RegexOptions.IgnoreCase))
        {
            return str.ToLower();
        }

        //add logging
        //Console.WriteLine("The string '{0}' is not a valid email address", str);
        return null;
    }
    }
}