using System.Collections.Generic;
using Octus.GetData;

namespace Octus.Models
{
    public class Especialista
    {
        public string Name { get; set; }

        public string LinkImage { get; set; }

        public Especializacao Specialization { get; set; }

        public List<MonthWithDays> Agenda { get; set; }
    }
}
