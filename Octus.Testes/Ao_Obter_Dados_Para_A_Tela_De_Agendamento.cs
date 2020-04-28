using Microsoft.VisualStudio.TestTools.UnitTesting;
using Octus.GetData;
using System;
using System.Collections.Generic;

namespace Octus.Testes
{
    [TestClass]
    public class Ao_Obter_Dados_Para_A_Tela_De_Agendamento
    {
        [TestMethod]
        public void Ao_Obter_3_Meses_A_Partir_Do_0_Deve_Retornar_Jsneiro_Fevereiro_E__Marco()
        {
            ScheduleManager sc = new ScheduleManager();
            var meses = sc.GetMonthTranslated(3, 0);
            Assert.IsTrue(meses[0].MonthName.Equals("Janeiro"));
            Assert.IsTrue(meses[1].MonthName.Equals("Fevereiro"));
            Assert.IsTrue(meses[2].MonthName.Equals("Março"));

        }


        [TestMethod]
        public void Ao_Obter_3_Meses_A_Partir_Do_4_Deve_Retornar_Aril_Maio_Junho()
        {
            ScheduleManager sc = new ScheduleManager();
            var meses = sc.GetMonthTranslated(3, 4);
            Assert.IsTrue(meses[0].MonthName.Equals("Abril"));
            Assert.IsTrue(meses[1].MonthName.Equals("Maio"));
            Assert.IsTrue(meses[2].MonthName.Equals("Junho"));
        }

        [TestMethod]
        public void Ao_Obter_3_Meses_A_Partir_Do_11_Deve_Retornar_Apenas_Novembro_E_Dezembro()
        {
            ScheduleManager sc = new ScheduleManager();
            var meses = sc.GetMonthTranslated(3, 11);
            Assert.IsTrue(meses.Count == 2);
            Assert.IsTrue(meses[0].MonthName.Equals("Novembro"));
            Assert.IsTrue(meses[1].MonthName.Equals("Dezembro"));
        }

        [TestMethod]
        public void Ao_Obter_3_Meses_A_Partir_Do_12_Deve_Retornar_Apenas_Dezembro()
        {
            ScheduleManager sc = new ScheduleManager();
            var meses = sc.GetMonthTranslated(3, 12);
            Assert.IsTrue(meses.Count == 1);
            Assert.IsTrue(meses[0].MonthName.Equals("Dezembro"));
        }

        [TestMethod]
        public void Ao_Obter_3_Meses_A_Partir_Do_13_Deve_Retornar_Apenas_Dezembro()
        {
            ScheduleManager sc = new ScheduleManager();
            var meses = sc.GetMonthTranslated(3, 13);
            Assert.IsTrue(meses.Count == 1);
            Assert.IsTrue(meses[0].MonthName.Equals("Dezembro"));
        }

        [TestMethod]
        public void Ao_Obter_12_Meses_A_Partir_Do_1_Deve_Retornar_De_Janeiro_A__Dezembro()
        {
            ScheduleManager sc = new ScheduleManager();
            var meses = sc.GetMonthTranslated(12, 1);
            Assert.IsTrue(meses.Count == 12);
        }

        [TestMethod]
        public void Ao_Obter_14_Meses_A_Partir_Do_Menos_3_Deve_Retornar_De_Janeiro_A__Dezembro()
        {
            ScheduleManager sc = new ScheduleManager();
            var meses = sc.GetMonthTranslated(14, -3);
            Assert.IsTrue(meses.Count == 12);
        }

        [TestMethod]
        public void Ao_Obter_Os_Dias_De_Fevereiro_Deve_Retornar_Menos_De_Trinta()
        {
            ScheduleManager sc = new ScheduleManager();
            List<DayToShow> days = sc.GetDaysTranslated(DateTime.Now.Year, 2);
            int ulfimoDia = days[days.Count - 1].Day;

            Assert.IsTrue(ulfimoDia < 30);
        }
    }
}

