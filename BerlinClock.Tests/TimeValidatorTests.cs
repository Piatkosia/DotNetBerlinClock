using System;
using BerlinClock.Classes;
using Xunit;

namespace BerlinClock.Tests
{
    public class TimeValidatorTests
    {
        [Theory]
        [InlineData("21:20:01")]
        [InlineData("24:00:00")]
        [InlineData("00:00:00")]
        [InlineData("06:34:12")]
        [InlineData("23:59:12")]
        [InlineData("14:21:43")]
        public void IfCorrectInput_DoesNotThrowExceptions(string data)
        {
            TimeValidator.Validate(data);
        }

        [Theory]
        [InlineData("29:20:01")]
        [InlineData("-2:00:00")]
        [InlineData("00:90:00")]
        [InlineData("06:34:12:12")]
        [InlineData("any string")]
        [InlineData("")]
        public void IfIncorrectInput_ThrowExceptions(string data)
        {
            Assert.Throws<ArgumentException>(() => TimeValidator.Validate(data));
        }


    }
}
