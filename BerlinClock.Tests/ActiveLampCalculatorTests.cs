using BerlinClock.Classes;
using Xunit;

namespace BerlinClock.Tests
{
    public class ActiveLampCalculatorTests
    {
        [Theory]
        [InlineData(0, true)]
        [InlineData(3, false)]
        [InlineData(16, true)]
        [InlineData(13, false)]
        [InlineData(28, true)]
        public void IsSecondOn_WorksAsExpected(int seconds, bool expectedValue)
        {
            var calculator = new ActiveLampCalculator();
            var output = calculator.IsSecondsOn(seconds);
            Assert.Equal(output, expectedValue);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(16, 3)]
        [InlineData(4, 0)]
        [InlineData(12, 2)]
        [InlineData(24, 4)]
        public void GetUpperOnCount_WorksAsExpected(int ticks, int expectedValue)
        {
            var calculator = new ActiveLampCalculator();
            var output = calculator.GetUpperOnCount(ticks);
            Assert.Equal(output, expectedValue);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(3, 3)]
        [InlineData(15, 0)]
        [InlineData(11, 1)]
        [InlineData(22, 2)]
        public void GetLowerOnCount_WorksAsExpected(int ticks, int expectedValue)
        {
            var calculator = new ActiveLampCalculator();
            var output = calculator.GetLowerOnCount(ticks);
            Assert.Equal(output, expectedValue);
        }


    }
}
