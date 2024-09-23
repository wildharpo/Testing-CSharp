using System.Text.RegularExpressions;

namespace Testing.Client.Helpers
{
    public class NumberFormatter: INumberFormatter
    {
        public int GetFormattedNumber(string providedNumber)
        {
            // remove all non-numeric characters from the provided number value using regular expressions
            var formattedNumber = Convert.ToInt32(Regex.Replace(providedNumber, "[^0-9]", ""));

            // ensure that the number supplied begins with a "1" prefix. If not, prepend it
            if (Convert.ToString(formattedNumber)[0] != '1')
                formattedNumber = Convert.ToInt32('1' + Convert.ToString(formattedNumber));

            return formattedNumber;
        }
    }
}
