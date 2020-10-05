using System.Text.RegularExpressions;

namespace PSoft.Libraryd.Presentation.Actions
{
    public class ValidatorActionFields
    {
        public static bool validateEmail(string email)
        {
            string patternEmail = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
            return Regex.IsMatch(email, patternEmail);
        }
        public static bool stringIsEmpy(string s)
        {
            return s == "";
        }
    }
}
