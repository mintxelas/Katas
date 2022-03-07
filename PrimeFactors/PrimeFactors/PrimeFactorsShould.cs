using FluentAssertions;
using Xunit;

namespace PrimeFactors
{
    public class PrimeFactorsShould
    {
        [Theory]
        [InlineData(1, new int[] { })]
        [InlineData(2, new[] { 2 })]
        [InlineData(3, new[] { 3 })]
        [InlineData(4, new[] { 2, 2 })]
        [InlineData(5, new[] { 5 })]
        [InlineData(6, new[] { 2, 3 })]
        [InlineData(7, new[] { 7 })]
        [InlineData(8, new[] { 2, 2, 2 })]
        [InlineData(9, new[] { 3, 3 })]
        [InlineData(10, new[] { 2, 5 })]
        [InlineData(11, new[] { 11 })]
        [InlineData(27720, new[] { 2, 2, 2, 3, 3, 5, 7, 11 })]
        [InlineData(int.MaxValue-1, new []{ 2, 3, 3, 7, 11, 31, 151, 331 })]
        public void GetPrimeFactorsOf(int number, int[] factors)
        {
            var engine = new PrimeFactors();
            var primeFactors = engine.GetPrimeFactors(number);
            primeFactors.Should().BeEquivalentTo(factors);
        }
    }
}