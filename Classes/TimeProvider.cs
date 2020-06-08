using System;
using BerlinClock.Classes;
using static BerlinClock.Classes.Consts;
using static System.Environment;

namespace BerlinClock
{
    public class TimeProvider : ITimeProvider
    {
        private readonly IActiveLampCalculator _activeLampCalculator;
        private readonly ITimeReader _timeReader;
        private readonly IClockFormatter _timeUnitFormatter;

        public string ToBerlinClockTime(string aTime)
        {
            try
            {
                TimeSpan time = _timeReader.Read(aTime);
                return GetTimeText(time);
            }

            catch (Exception e)
            {
                return $"{ErrorMessage}{e.Message}";
            }
        }

        private string GetTimeText(TimeSpan time)
        {
            int hours = time.Hours;
            if (time.Days == 1)
            {
                hours = 24;
            }
            return $"{GetSeconds(time.Seconds)}{NewLine}{GetHours(hours)}{NewLine}{GetMinutes(time.Minutes)}";
        }

        private string GetHours(int hours)
        {
            int upperHours = _activeLampCalculator.GetUpperOnCount(hours);
            int lowerHours = _activeLampCalculator.GetLowerOnCount(hours);

            return _timeUnitFormatter.GetHours(upperHours, lowerHours);
        }

        private string GetMinutes(int minutes)
        {
            int upperMinutes = _activeLampCalculator.GetUpperOnCount(minutes);
            int lowerMinutes = _activeLampCalculator.GetLowerOnCount(minutes);

            return _timeUnitFormatter.GetMinutes(upperMinutes, lowerMinutes);
        }

        private string GetSeconds(int seconds)
        {
            bool isSecondActive = _activeLampCalculator.IsSecondsOn(seconds);
            return _timeUnitFormatter.GetSeconds(isSecondActive);
        }

        public TimeProvider(IActiveLampCalculator activeLampCalculator, ITimeReader timeReader, IClockFormatter timeUnitFormatter)
        {
            _activeLampCalculator = activeLampCalculator;
            _timeReader = timeReader;
            _timeUnitFormatter = timeUnitFormatter;
        }
    }
}