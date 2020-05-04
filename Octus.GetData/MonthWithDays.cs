using System;
using System.Collections.Generic;

namespace Octus.GetData
{
    public class MonthWithDays
    {
        int _month;
        List<DayToShow> _days;

        public MonthWithDays(int month, List<DayToShow> days)
        {
            _month = month;
            _days = days;
        }

        public int Month { get { return _month; } }

        public List<DayToShow> Days { get { return _days; } }
    }
}
