namespace BerlinClock.Classes
{
    public interface IClockFormatter
    {
        string GetSeconds(bool isActive);
        string GetMinutes(int upperLights, int lowerLights);
        string GetHours(int upperLights, int lowerLights);
    }
}