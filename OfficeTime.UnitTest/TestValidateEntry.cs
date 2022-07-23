using Xunit;
using OfficeTime.Test.Services;

namespace OfficeTime.UnitTest
{
    public class TestValidateEntry
    {
        [Theory]
        [InlineData("RENE=MO10:00-12:00,TU10:00-12:00,TH01:00-03:00,SA14:00-18:00,SU20:00-21:00", true)]
        [InlineData("RENE=MO10:00-12:00,", false)]
        [InlineData("=MO10:00-12:00,TU10:00-12:00,TH01:00-03:00,SA14:00-18:00,SU20:00-21:00", false)]
        [InlineData("RENE=MO10:00-12:00", true)]
        [InlineData("RENE=XX10:00-12:00,TU10:00-12:00,TH01:00-03:00,SA14:00-18:00,SU20:00-21:00", false)]
        [InlineData("RENE=MO10:00-25:00,TU10:00-12:00,TH01:00-03:00,SA14:00-18:00,SU20:00-21:00", false)]
        [InlineData("RENE=MO10:00-12:60,TU10:00-12:00,TH01:00-03:00,SA14:00-18:00,SU20:00-21:00", false)]
        [InlineData("RENE=", false)]
        [InlineData("", false)]
        [InlineData("RENEMO10:00-12:00,TU10:00-12:00,TH01:00-03:00,SA14:00-18:00,SU20:00-21:00", false)]
        [InlineData("RENE=10:00-12:00,TU10:00-12:00,TH01:00-03:00,SA14:00-18:00,SU20:00-21:00", false)]

        public void ValidateEntry(string entry_line, bool result)
        {
            ValidateEntry test_validate_entry = new ValidateEntry();
            bool isValid = test_validate_entry.IsValid(entry_line);

            Assert.Equal(result, isValid);
        }
    }
}
