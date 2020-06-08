namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        private readonly ITimeProvider _timeProvider;
        public string convertTime(string aTime)
        {
            return _timeProvider.ToBerlinClockTime(aTime);
        }

        public TimeConverter(ITimeProvider timeProvider)
        {
            _timeProvider = timeProvider;
        }
    }
}
