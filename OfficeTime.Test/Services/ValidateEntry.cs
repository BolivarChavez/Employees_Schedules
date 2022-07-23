using System.Text.RegularExpressions;

namespace OfficeTime.Test.Services
{
    public class ValidateEntry
    {
        public bool IsValid(string file_line)
        {
            Regex checkline = new Regex(@"^[A-Z]+=((((?:SU|MO|TU|WE|TH|FR|SA?)(?:[01]?[0-9]|2[0-3]):[0-5][0-9])-((?:[01]?[0-9]|2[0-3]):[0-5][0-9]))+,)*(((?:SU|MO|TU|WE|TH|FR|SA?)(?:[01]?[0-9]|2[0-3]):[0-5][0-9])-((?:[01]?[0-9]|2[0-3]):[0-5][0-9]))+$");
            return checkline.IsMatch(file_line);
        }
    }
}
