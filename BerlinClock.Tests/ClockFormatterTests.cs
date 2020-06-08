using System;
using BerlinClock.Classes;
using Xunit;

namespace BerlinClock.Tests
{
    public class ClockFormatterTests
    {
        [Theory]
        [InlineData(true, "Y")]
        [InlineData(false, "O")]
        public void IsSecondOn_WorksAsExpected(bool seconds, string expectedValue)
        {
            var formatter = new ClockFormatter();
            var output = formatter.GetSeconds(seconds);
            Assert.Equal(output, expectedValue);
        }

        [Fact]
        public void GetBaseClock_IfTooManyLightsToSwitchOn_ThrowsException()
        {
            var formatter = new ClockFormatter();
            Assert.Throws<ArgumentException>(()=> formatter.GetBaseClock(999,'a', 10));
        }

        [Fact]
        public void GetBaseClock_whenAllLettersMustBeOn_ReturnLetters()
        {
            var formatter = new ClockFormatter();
            string x = formatter.GetBaseClock(4, 'a', 4);
            Assert.Equal(x, "aaaa");
        }

        [Fact]
        public void GetBaseClock_whenAllLettersMustBeOn_ReturnLettersWithPadding()
        {
            var formatter = new ClockFormatter();
            string x = formatter.GetBaseClock(2, 'a', 4);
            Assert.Equal(x, "aaOO");
        }

        [Theory]
        [InlineData(0, 0, "OOOOOOOOOOO\r\nOOOO")]
        [InlineData(2, 2, "YYOOOOOOOOO\r\nYYOO")]
        [InlineData(8, 3, "YYRYYRYYOOO\r\nYYYO")]
        [InlineData(2, 1, "YYOOOOOOOOO\r\nYOOO")]
        public void GetMinutes_WorksAsExpected(int upper, int lower, string expected)
        {
            var formatter = new ClockFormatter();
            string x = formatter.GetMinutes(upper, lower);
            Assert.Equal(x, expected);
        }

        [Theory]
        [InlineData(0, 0, "OOOO\r\nOOOO")]
        [InlineData(4, 4, "RRRR\r\nRRRR")]
        [InlineData(2, 3, "RROO\r\nRRRO")]
        public void GetHours_WorksAsExpected(int upper, int lower, string expected)
        {
            var formatter = new ClockFormatter();
            string x = formatter.GetHours(upper, lower);
            Assert.Equal(x, expected);
        }


    }
}
