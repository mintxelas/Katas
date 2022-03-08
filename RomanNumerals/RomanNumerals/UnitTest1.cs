using Xunit;

namespace RomanNumerals
{
    public class ConverterShould
    {
        [Theory]
        [InlineData(1, "I")]
        [InlineData(2, "II")]
        [InlineData(3, "III")]
        [InlineData(4, "IV")]
        [InlineData(5, "V")]
        [InlineData(6, "VI")]
        [InlineData(7, "VII")]
        [InlineData(9, "IX")]
        public void ConvertArabicToRoman(int arabic, string roman)
        {
            string result = Convert(arabic);
            Assert.Equal(roman, result);
        }

        public string Convert(int arabic)
        {
            if (arabic == 9) return romans[5];
            if (arabic > 5) return romans[4] + Convert(arabic - 5);
            return romans[arabic-1];
        }

        private static readonly string[] romans = { "I", "II", "III", "IV", "V", "IX" };
    }
}