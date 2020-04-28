using System;

namespace Octus.GetData
{
    public class DayToShow
    {
        string _daysOfWeek = string.Empty;
        string _interval = string.Empty;
        int _day = 0;

        public DayToShow(int day, string dayOfWeek, string interval)
        {
            _daysOfWeek = dayOfWeek;
            _day = day;
            _interval = interval;
        }

        public string Interval { get { return _interval; } set { _interval = value; } }
        public string DayOsWeek { get { return _daysOfWeek; } }

        public int Day { get { return _day; } }
    }
}
