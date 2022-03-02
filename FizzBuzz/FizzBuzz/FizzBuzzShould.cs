using Xunit;

namespace FizzBuzz
{
    public class FizzBuzzShould
    {
        private static readonly FizzBuzz fizzBuzz;

        static FizzBuzzShould()
        {
            fizzBuzz = new FizzBuzz();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(4)]
        [InlineData(13)]
        public void WriteTheGivenNumber(int number)
        {
            var result = fizzBuzz.Write(number);
            Assert.Equal(number.ToString(), result);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(6)]
        [InlineData(99)]
        public void WriteFizzForMultiplesOf3(int number)
        {
            var result = fizzBuzz.Write(number);
            Assert.Equal("Fizz", result);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(55)]
        public void WriteBuzzForMultiplesOf5(int number)
        {
            var result = fizzBuzz.Write(number);
            Assert.Equal("Buzz", result);
        }

        [Theory]
        [InlineData(15)]
        [InlineData(30)]
        [InlineData(45)]
        public void WriteFizzBuzzForMultiplesOf3And5(int number)
        {
            var result = fizzBuzz.Write(number);
            Assert.Equal("FizzBuzz", result);
        }
    }
}