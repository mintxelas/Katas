using Xunit;

namespace RomanNumerals;

public class NumberShould
{
    [Theory]
    [InlineData(0, "")]
    [InlineData(1, "I")]
    [InlineData(2, "II")]
    [InlineData(3, "III")]
    [InlineData(4, "IV")]
    [InlineData(5, "V")]
    [InlineData(6, "VI")]
    [InlineData(7, "VII")]
    [InlineData(8, "VIII")]
    [InlineData(9, "IX")]
    [InlineData(10, "X")]
    [InlineData(11, "XI")]
    [InlineData(12, "XII")]
    [InlineData(13, "XIII")]
    [InlineData(14, "XIV")]
    [InlineData(15, "XV")]
    [InlineData(16, "XVI")]
    [InlineData(17, "XVII")]
    [InlineData(18, "XVIII")]
    [InlineData(19, "XIX")]
    [InlineData(20, "XX")]
    [InlineData(25, "XXV")]
    [InlineData(29, "XXIX")]
    [InlineData(30, "XXX")]
    [InlineData(39, "XXXIX")]
    [InlineData(40, "XL")]
    [InlineData(41, "XLI")]
    [InlineData(49, "XLIX")]
    [InlineData(50, "L")]
    [InlineData(69, "LXIX")]
    [InlineData(78, "LXXVIII")]
    [InlineData(89, "LXXXIX")]
    [InlineData(90, "XC")]
    [InlineData(99, "XCIX")]
    [InlineData(100, "C")]
    [InlineData(257, "CCLVII")]
    [InlineData(399, "CCCXCIX")]
    [InlineData(400, "CD")]
    [InlineData(499, "CDXCIX")]
    public void Convert(int arabic, string roman)
    {
        var number = new Number(arabic);
        var actual = number.ToRoman();
        Assert.Equal(roman, actual);
    }
}
