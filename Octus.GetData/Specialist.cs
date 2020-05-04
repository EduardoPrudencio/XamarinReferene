using System;
using System.Collections.Generic;

namespace Octus.GetData
{
    public class Specialist
    {
        List<MonthWithDays> _agenda;
        ScheduleManager scheduleManager;

        public Specialist(string name, string urlImage, Specialization specialization)
        {
            Name = name;
            LinkImage = urlImage;
            Specialization = specialization;
            Id = Guid.NewGuid();
            _agenda = new List<MonthWithDays>();
            scheduleManager = new ScheduleManager();
            GetAgenda();
        }

        public Guid Id { get; }

        public string Name { get; set; }

        public string LinkImage { get; set; }

        public Specialization Specialization { get; set; }

        public List<MonthWithDays> Agenda { get { return _agenda; }}


        private void GetAgenda()
        {
            for (int i = 0; i < 3; i++)
            {
                int monthToAdd = DateTime.Now.Month + i;

                List<DayToShow> daysOfMont = scheduleManager.GetDaysTranslated(DateTime.Now.Year, monthToAdd);
                _agenda.Add(new MonthWithDays(monthToAdd, daysOfMont));
            }
        }
    }
}
