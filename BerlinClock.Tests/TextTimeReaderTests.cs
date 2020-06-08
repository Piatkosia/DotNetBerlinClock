using System;
using BerlinClock.Classes;
using Xunit;

namespace BerlinClock.Tests
{
    public class TextTimeReaderTests
    {
        [Fact]
        public void TimeReader_WhenMidnight_HasOneDayInTimespan()
        {
            TextTimeReader reader = GetReader();
            var output = reader.Read(Consts.Midnight);
            Assert.Equal(output.Days, 1);
        }

        [Theory]
        [InlineData("I'm not a time")]
        [InlineData("03:-03:00")]
        [InlineData("21:51:99")]
        public void TimeReader_WhenWrongValue_ThrowsException(string data)
        {
            TextTimeReader reader = GetReader();
            Assert.Throws<ArgumentException>(() => reader.Read(data));
        }

        [Theory]
        [InlineData("00:00:00", 0)]
        [InlineData("03:03:00", 3)]
        [InlineData("21:51:00", 51)]
        public void TimeReader_MinutesParseCorrectly(string time, int expected)
        {
            TextTimeReader reader = GetReader();
            var output = reader.Read(time);
            Assert.Equal(output.Minutes, expected);
        }

        [Theory]
        [InlineData("00:04:00", 0)]
        [InlineData("03:07:00", 3)]
        [InlineData("21:00:00", 21)]
        public void TimeReader_HoursParseCorrectly(string time, int expected)
        {
            TextTimeReader reader = GetReader();
            var output = reader.Read(time);
            Assert.Equal(output.Hours, expected);
        }

        [Theory]
        [InlineData("00:04:13", 13)]
        [InlineData("03:07:21", 21)]
        [InlineData("21:00:42", 42)]
        public void TimeReader_SecondsParseCorrectly(string time, int expected)
        {
            TextTimeReader reader = GetReader();
            var output = reader.Read(time);
            Assert.Equal(output.Seconds, expected);
        }


        private TextTimeReader GetReader()
        {
            return new TextTimeReader(Consts.TimeFormat);
        }
    }
}
