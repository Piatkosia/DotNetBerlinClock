using System;
using static BerlinClock.Classes.Consts;

namespace BerlinClock.Classes
{
    public class TextTimeReader : ITimeReader
    {

        public TextTimeReader(string format)
        {
            Format = format;
        }

        public TimeSpan Read(string timeToRead)
        {
            TimeValidator.Validate(timeToRead);
            if (timeToRead == Midnight)
            {
                return new TimeSpan(24, 0, 0);
            }
            else
            {
                return TimeSpan.Parse(DateTime.Parse(timeToRead).ToString(Format));
            }
        }

        public string Format { get; }
    }
}
