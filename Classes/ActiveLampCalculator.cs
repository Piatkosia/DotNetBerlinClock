namespace BerlinClock.Classes
{
    public class ActiveLampCalculator : IActiveLampCalculator
    {
        private int SmallTimeFactor = 2;
        private int BigTimeFactor = 5;
        public bool IsSecondsOn(int ticks)
        {
            return ticks % SmallTimeFactor == 0;
        }

        public int GetUpperOnCount(int ticks)
        {
            return ticks / BigTimeFactor;
        }

        public int GetLowerOnCount(int ticks)
        {
            return ticks % BigTimeFactor;
        }

    }
}
