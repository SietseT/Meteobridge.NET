using System;
using System.Globalization;

namespace Meteobridge.Helpers
{
    internal static class DataHelper
    {
        internal static bool GetBoolValue(object value)
        {
            if (value == null)
                return false;

            var stringValue = value.ToString();

            try
            {
                return Convert.ToBoolean(stringValue);
            }
            catch { }

            
            if (stringValue == "1")
                return true;

            if (stringValue == "0")
                return false;

            return false;
        }

        internal static double GetDoubleValue(object value, string seperator = ".")
        {
            if (value == null)
                return default(double);

            var provider = new NumberFormatInfo();
            provider.NumberDecimalSeparator = seperator;

            try
            {
                return Convert.ToDouble(value, provider);
            }
            catch(FormatException)
            {
                return 0;
            }            
        }

        internal static string DegreesToCardinal(double degrees)
        {
            string[] cardinals = { "N", "NO", "O", "ZO", "Z", "ZW", "W", "NW", "N" };
            return cardinals[(int)Math.Round((degrees % 360) / 45)];
        }
    }
}
