using System;

namespace Pliance.SDK.Contract
{
    public class Birthdate
    {
        public int? Year { get; }
        public int? Month { get; }
        public int? Day { get; }

        public Birthdate(int? year, int? month, int? day)
        {
            Year = year;
            Month = month;
            Day = day;
        }
    }
}