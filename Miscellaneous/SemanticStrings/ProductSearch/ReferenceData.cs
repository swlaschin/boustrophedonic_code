using System;
using System.Text.RegularExpressions;

namespace Miscellaneous.SemanticStrings.ProductSearch
{
    static internal class ReferenceData
    {
        public static ProductCode ProductCodeX = "PRODUCT123".ToProductCode();
        public static ProductCode ProductCodeY = "PRODUCT456".ToProductCode();
        public static ProductCode ProductCodeZ = "PRODUCT789".ToProductCode();

        public static SupplierCode SupplierCodeA = SupplierCode.New("SUPPLIERA");   //shows the explicit method instead
        public static SupplierCode SupplierCodeB = SupplierCode.New("SUPPLIERB");
        public static SupplierCode SupplierCodeC = SupplierCode.New("SUPPLIERC");

        public static CurrencyCode Usd = "USD".ToCurrencyCode();
        public static CurrencyCode Gbp = "GBP".ToCurrencyCode();

        public static string TransformProductCode(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return null;
            }

            const string pattern = @"PRODUCT\d+";
            if (Regex.IsMatch(str, pattern, RegexOptions.IgnoreCase))
            {
                return str.ToUpper();
            }
            else
            {
                //add logging
                Console.WriteLine("The string '{0}' must start with the word PRODUCT followed by one or more digits", str);
                return null;
            }
        }
    }
}