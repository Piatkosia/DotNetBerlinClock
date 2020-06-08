namespace BerlinClock.Classes
{
    public interface IActiveLampCalculator
    {
        bool IsSecondsOn(int ticks);
        int GetUpperOnCount(int ticks);
        int GetLowerOnCount(int ticks);
    }
}