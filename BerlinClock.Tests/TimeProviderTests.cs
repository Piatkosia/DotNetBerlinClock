using BerlinClock.Classes;
using Xunit;

namespace BerlinClock.Tests
{
    public class TimeProviderTests
    {
        [Theory]
        [InlineData("00:00:00", "Y\r\nOOOO\r\nOOOO\r\nOOOOOOOOOOO\r\nOOOO")]
        [InlineData("24:00:00", "Y\r\nRRRR\r\nRRRR\r\nOOOOOOOOOOO\r\nOOOO")]
        [InlineData("14:23:00", "Y\r\nRROO\r\nRRRR\r\nYYRYOOOOOOO\r\nYYYO")]
        [InlineData("23:43:58", "Y\r\nRRRR\r\nRRRO\r\nYYRYYRYYOOO\r\nYYYO")]
        public void TimeProvider_WorksAsExpected(string time, string expectedValue)
        {
            ITimeProvider provider = new TimeProvider(new ActiveLampCalculator(), new TextTimeReader(Consts.TimeFormat), new ClockFormatter());
            var output = provider.ToBerlinClockTime(time);
            Assert.Equal(output, expectedValue);
        }

        [Theory]
        [InlineData("00:99:00")]
        [InlineData("03:-03:00")]
        [InlineData("21:51:72")]
        [InlineData("21:51:21:33")]
        [InlineData("de:32:bf:12")]
        [InlineData("any string")]
        public void TimeProvider_FailsAsExpected(string time)
        {
            ITimeProvider provider = new TimeProvider(new ActiveLampCalculator(), new TextTimeReader(Consts.TimeFormat), new ClockFormatter());
            var output = provider.ToBerlinClockTime(time);
            Assert.True(output.StartsWith(Consts.ErrorMessage));
        }
    }
}
