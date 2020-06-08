using System;
using static BerlinClock.Classes.Consts;

namespace BerlinClock.Classes
{
    public class TimeValidator
    {
        public static void Validate(string timeCandidate)
        {
            if (timeCandidate != Midnight && !DateTime.TryParse(timeCandidate, out DateTime dateConverted))
            {
                throw new ArgumentException($"{timeCandidate}{TimeValidationErrorBody}");
            }
        }
    }

 
}
