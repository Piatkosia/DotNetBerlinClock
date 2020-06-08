using System;
using static BerlinClock.Classes.Consts;
using static System.Environment;

namespace BerlinClock.Classes
{
    public class ClockFormatter : IClockFormatter
    {
        private const char Off = 'O';
        private const char On = 'Y';
        private const char HourOn = 'R';
        private const string SpecialMinuteOn = "YYR";
        private const int LowerMinuteLights = 4;
        private const int UpperMinuteLights = 11;
        private const int LowerHourLights = 4;
        private const int UpperHourLights = 4;

        public string GetSeconds(bool isActive)
        {
            return (isActive ? On : Off).ToString();
        }

        public string GetMinutes(int upperLights, int lowerLights)
        {
            string upper = GetUpperMinutes(upperLights);
            string lower = GetBaseClock(lowerLights, On, LowerMinuteLights);
            return GetText(upper, lower);
            
        }

        private string GetText(string upper, string lower)
        {
            return $"{upper}{NewLine}{lower}";
        }

        private string GetUpperMinutes(int upperLights)
        {
            var basePart = GetBaseClock(upperLights, On, UpperMinuteLights);
            return basePart.Replace(new string(On, SpecialMinuteOn.Length), SpecialMinuteOn);
        }

        public string GetHours(int upperLights, int lowerLights)
        {
            string upper = GetBaseClock(upperLights, HourOn, UpperHourLights);
            string lower = GetBaseClock(lowerLights, HourOn, LowerHourLights);
            return GetText(upper, lower);
        }

        public string GetBaseClock(int lightsOn, char baseChar, int size)
        {
            if (size < lightsOn)
            {
                throw new ArgumentException($"{lightsOn} < {size}. {Uncreatable}");
            }
            else
            {
                return new string(baseChar, lightsOn).PadRight(size, Off);
            }
        }
    }
}
