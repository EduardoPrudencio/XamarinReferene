﻿using System;
using System.Collections.Generic;

namespace Octus.GetData
{
    public class ScheduleManager
    {
        private List<string> _monthsInPortuguese;
        private List<string> _daysOfWeekIOnPortuguese;

        List<MonthsToShow> months;
        Dictionary<string, string> diasDaDemanaEnglishPortuguese;

        public ScheduleManager()
        {
            _monthsInPortuguese = new List<string>
            {
                "Janeiro",
                "Fevereiro",
                "Março",
                "Abril",
                "Maio",
                "Junho",
                "Julho",
                "Agosto",
                "Setembro",
                "Outubro",
                "Novembro",
                "Dezembro",
            };

            diasDaDemanaEnglishPortuguese = new Dictionary<string, string>();

            diasDaDemanaEnglishPortuguese.Add("Monday", "Segunda-feira");
            diasDaDemanaEnglishPortuguese.Add("Tuesday", "Terça-feira");
            diasDaDemanaEnglishPortuguese.Add("Wednesday", "Quarta-Feira");
            diasDaDemanaEnglishPortuguese.Add("Thursday", "Quinta-feira");
            diasDaDemanaEnglishPortuguese.Add("Friday", "Sexta-feira");


            _daysOfWeekIOnPortuguese = new List<string>
            {
                "Segunda-Feira",
                "Terça-Feira",
                "Quarta-Feira",
                "Quinta-Feira",
                "Sexta-Feira",
                "Sábado",
                "Domingo",
            };
        }

        public List<MonthsToShow> GetMonthTranslated(int count, int monthToInitialize)
        {
            months = new List<MonthsToShow>();

            if (count < 1)
                count = 1;

            if (monthToInitialize > 12)
                monthToInitialize = 12;

            if (monthToInitialize < 1)
                monthToInitialize = 1;

            int _monthToAdd = monthToInitialize - 1;

            months.Add(new MonthsToShow(_monthToAdd, _monthsInPortuguese[_monthToAdd]));


            if (count > 1 && monthToInitialize <= 12)
            {
                int monthsInserteds = 1;
                int _index = (_monthToAdd + monthsInserteds);

                while (monthsInserteds < count && _index < 12)
                {
                    months.Add(new MonthsToShow(_index, _monthsInPortuguese[_monthToAdd + monthsInserteds]));
                    monthsInserteds++;
                    _index = (_monthToAdd + monthsInserteds);
                }
            }

            return months;
        }

        public List<DayToShow> GetDaysTranslated(int year, int month)
        {
            List<DayToShow> diasDoMes = new List<DayToShow>();
            var countDaysOfMonth = DateTime.DaysInMonth(year, month);

            for (int i = 1; i <= countDaysOfMonth; i++)
            {
                DateTime d = new DateTime(year, month, i);

                bool podeInserir = (d.DayOfWeek != DayOfWeek.Saturday) && (d.DayOfWeek != DayOfWeek.Sunday);


                if (podeInserir)
                {
                    diasDoMes.Add(new DayToShow(i, diasDaDemanaEnglishPortuguese[d.DayOfWeek.ToString()], 8,9));
                    diasDoMes.Add(new DayToShow(i, diasDaDemanaEnglishPortuguese[d.DayOfWeek.ToString()], 9,10));
                    diasDoMes.Add(new DayToShow(i, diasDaDemanaEnglishPortuguese[d.DayOfWeek.ToString()], 10,11));
                    diasDoMes.Add(new DayToShow(i, diasDaDemanaEnglishPortuguese[d.DayOfWeek.ToString()], 11,12));
                    diasDoMes.Add(new DayToShow(i, diasDaDemanaEnglishPortuguese[d.DayOfWeek.ToString()], 12,13));
                    diasDoMes.Add(new DayToShow(i, diasDaDemanaEnglishPortuguese[d.DayOfWeek.ToString()], 13,14));
                    diasDoMes.Add(new DayToShow(i, diasDaDemanaEnglishPortuguese[d.DayOfWeek.ToString()], 14,15));
                    diasDoMes.Add(new DayToShow(i, diasDaDemanaEnglishPortuguese[d.DayOfWeek.ToString()], 15,16));
                    diasDoMes.Add(new DayToShow(i, diasDaDemanaEnglishPortuguese[d.DayOfWeek.ToString()], 16,17));
                    diasDoMes.Add(new DayToShow(i, diasDaDemanaEnglishPortuguese[d.DayOfWeek.ToString()], 17,18));
                }
            }

            return diasDoMes;
        }
    }
}
