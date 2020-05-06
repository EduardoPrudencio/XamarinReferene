using System;

namespace Octus.GetData
{
    public class DayToShow
    {
        string _daysOfWeek = string.Empty;
        int _day = 0;
        int _intialHour;
        int _finalHour;
        bool _reserved = false;

        public DayToShow(int day, string dayOfWeek, int initialHour, int finalHour)
        {
            _daysOfWeek = dayOfWeek;
            _day = day;
            _intialHour = initialHour;
            _finalHour = finalHour;
        }

        public int InitialHour { get { return _intialHour; } }
        public int FinalHour { get { return _finalHour; } }
        public string Interval { get { return $"{_intialHour}:00 - {_finalHour}:00"; }}
        public string DayOfWeek { get { return _daysOfWeek; } }
        public bool Reserved { get { return _reserved; } set { _reserved = value; } }
        public int Day { get { return _day; } }
    }
}
