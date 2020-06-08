using System;

namespace BerlinClock.Classes
{
    public interface ITimeReader
    {
       TimeSpan Read(string timeToRead);
    }
}