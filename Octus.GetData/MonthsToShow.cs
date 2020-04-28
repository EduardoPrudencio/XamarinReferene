namespace Octus.GetData
{
    public class MonthsToShow
    {
        int _index = -1;
        string _monthName = string.Empty;

        public MonthsToShow(int index, string month)
        {
            _index = index;
            _monthName = month;
        }

        public int Index { get => _index; }

        public string MonthName { get => _monthName; }
    }
}
