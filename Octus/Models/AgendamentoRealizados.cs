using System;
using Octus.GetData;

namespace Octus.Models
{
    public class AgendamentoRealizados
    {
        private DayToShow _day;
        private string _month;
        private Especialista _especialista;

        public AgendamentoRealizados(DayToShow day, string month, Especialista especialista)
        {
            _day = day;
            _month = month;
            _especialista = especialista;
        }


        public DayToShow Dia
        {
            get
            {
                return _day;
            }
            set
            {
                if (_day != value)
                {
                    _day = value;
                }
            }
        }

        public string NomeEspecialista
        {
            get
            {
                return $"{_especialista.Name} - {Especialidade}";
            }
        }

        public string Especialidade { get { return _especialista.Specialization.Name; } }

        public string Agendamento { get { return $"{_day.Day} de {_month} no intevalo de {_day.Interval}"; } }
    }
}
