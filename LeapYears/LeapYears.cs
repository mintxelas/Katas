using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeapYears
{
    [TestClass]
    public class LeapYearShould
    {
        [DataTestMethod]
        [DataRow(2000)]
        [DataRow(2400)]
        [DataRow(1600)]
        public void BeTrueWhenIsDivisibleBy400(int value)
        {
            var year = new Year() { Value = value };
            bool result = year.IsLeapYear();
            Assert.IsTrue(result);
        }

        [DataTestMethod]
        [DataRow(1700)]
        [DataRow(1800)]
        [DataRow(1900)]
        [DataRow(2100)]
        public void BeFalseWhenIsDivisibleBy100ButNotBy400(int value)
        {
            var year = new Year() { Value = value };
            bool result = year.IsLeapYear();
            Assert.IsFalse(result);
        }

        [DataTestMethod]
        [DataRow(2008)]
        [DataRow(2012)]
        [DataRow(2016)]
        public void BeTrueWhenIsDivisibleBy4ButNotBy100(int value)
        {
            var year = new Year() { Value = value };
            bool result = year.IsLeapYear();
            Assert.IsTrue(result);
        }


        [DataTestMethod]
        [DataRow(2017)]
        [DataRow(2018)]
        [DataRow(2019)]
        public void BeFalseWhenIsNotDivisibleBy4(int value)
        {
            var year = new Year() { Value = value };
            bool result = year.IsLeapYear();
            Assert.IsFalse(result);
        }
    }

    public class Year
    {
        public int Value { get; set; }

        public bool IsLeapYear()
        {
            if (IsDivisibleBy(400)) return true;
            if (IsDivisibleBy(100) && !IsDivisibleBy(400)) return false;
            if (IsDivisibleBy(4) && !IsDivisibleBy(100)) return true;
            if (!IsDivisibleBy(4)) return false;
            return false;
        }
        private bool IsDivisibleBy(int divisor)
        {
            return Value % divisor == 0;
        }
    }
}