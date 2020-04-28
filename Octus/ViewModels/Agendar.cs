using Octus.GetData;
using Octus.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace Octus.ViewModels
{
    public class Agendar : ViewModelBase
    {
        ScheduleManager scheduleManager;

        bool _profissionalSelecionado = false;
        string _mesAnterior = string.Empty;
        string _mesCorrente = string.Empty;
        string _proximoMes = string.Empty;
        int _indexMonthSelected = 0;

        Especializacao _especializacaoSelecionada = null;

        ObservableCollection<Especializacao> _especializacoes;

        ICommand nextMonthCommand;
        ICommand previewMonthCommand;

        List<MonthsToShow> months;

        public Agendar()
        {
            _especializacoes = new ObservableCollection<Especializacao>();
            nextMonthCommand = new Command(OnNextMonth);
            previewMonthCommand = new Command(OnPreviewMonth);

            scheduleManager = new ScheduleManager();
            RefreshMonts();
            PrepairEspecializations();
        }

        private void RefreshMonts(int month = 0)
        {
            month = (month == 0) ? DateTime.Now.Month : month;

            months = scheduleManager.GetMonthTranslated(3, month - 1);

            this.MesAnterior = (months.Count == 3) ? months[0].MonthName : string.Empty;
            this.MesCorrente = months[1].MonthName;
            this.ProximoMes = (months[1].Index < months[2].Index) ? months[2].MonthName : string.Empty;
        }

        private void PrepairEspecializations()
        {
            _especializacoes.Add(new Especializacao("Especialização 1"));
            _especializacoes.Add(new Especializacao("Especialização 2"));
            _especializacoes.Add(new Especializacao("Especialização 3"));
            _especializacoes.Add(new Especializacao("Especialização 4"));
            _especializacoes.Add(new Especializacao("Especialização 5"));
            _especializacoes.Add(new Especializacao("Especialização 6"));
            _especializacoes.Add(new Especializacao("Especialização 7"));
            _especializacoes.Add(new Especializacao("Especialização 8"));
            _especializacoes.Add(new Especializacao("Especialização 9"));
            _especializacoes.Add(new Especializacao("Especialização 10"));
            _especializacoes.Add(new Especializacao("Especialização 11"));
            _especializacoes.Add(new Especializacao("Especialização 12"));
            _especializacoes.Add(new Especializacao("Especialização 13"));
            _especializacoes.Add(new Especializacao("Especialização 14"));
            _especializacoes.Add(new Especializacao("Especialização 15"));
            _especializacoes.Add(new Especializacao("Especialização 16"));
            _especializacoes.Add(new Especializacao("Especialização 17"));
            _especializacoes.Add(new Especializacao("Especialização 18"));
            _especializacoes.Add(new Especializacao("Especialização 19"));

        }

        public bool ProfissionalSelecionado
        {
            get { return _profissionalSelecionado; }
            set
            {
                if (value != _profissionalSelecionado)
                {
                    _profissionalSelecionado = value;
                    OnPropertyChanges("ProfissionalSelecionado");
                }
            }
        }

        public ObservableCollection<Especializacao> Especializacoes
        {
            get
            {
                return _especializacoes;
            }
            set
            {
                if (_especializacoes != value)
                {
                    _especializacoes = value;
                    OnPropertyChanges("Especializacoes");
                }
            }
        }

        public Especializacao EspecializacaoSelecionada
        {
            get
            {
                return _especializacaoSelecionada;
            }
            set
            {
                if (_especializacaoSelecionada != value)
                {
                    _especializacaoSelecionada = value;
                }
            }
        }

        public string MesCorrente
        {
            get { return _mesCorrente; }
            set
            {
                if (value != _mesCorrente)
                {
                    _mesCorrente = value;
                    OnPropertyChanges("MesCorrente");
                }
            }
        }

        public string MesAnterior
        {
            get { return _mesAnterior; }
            set
            {
                if (value != _mesAnterior)
                {
                    _mesAnterior = value;
                    OnPropertyChanges("MesAnterior");
                }
            }
        }

        public string ProximoMes
        {
            get { return _proximoMes; }
            set
            {
                if (value != _proximoMes)
                {
                    _proximoMes = value;
                    OnPropertyChanges("ProximoMes");
                }
            }
        }

        public List<DayToShow> DiasDoMes
        {
            get
            {
                _indexMonthSelected = (_indexMonthSelected == 0) ? DateTime.Now.Month : _indexMonthSelected;
                return scheduleManager.GetDaysTranslated(DateTime.Now.Year, _indexMonthSelected);
            }

            set
            {
                DiasDoMes = value;
                OnPropertyChanges("DiasDoMes");
            }
        }


        void OnNextMonth(object s)
        {
            MonthsToShow monthSelected = months.FirstOrDefault(x => x.MonthName.Equals(_proximoMes));


            if (!string.IsNullOrWhiteSpace(_proximoMes))
            {

                _indexMonthSelected = (monthSelected.Index + 1);

                if ((monthSelected.Index + 1) <= 11)
                    RefreshMonts(monthSelected.Index + 1);

                else if ((monthSelected.Index + 1) == 12)
                {
                    this.MesAnterior = this.MesCorrente;
                    this.MesCorrente = this.ProximoMes;
                    this.ProximoMes = string.Empty;
                }

                OnPropertyChanges("DiasDoMes");
            }
        }

        void OnPreviewMonth(object s)
        {
            MonthsToShow monthSelected = months.FirstOrDefault(x => x.MonthName.Equals(_mesAnterior));

            if (!string.IsNullOrWhiteSpace(_mesAnterior))
            {
                _indexMonthSelected = (monthSelected.Index + 1);

                if (monthSelected.Index > 0)
                    RefreshMonts(monthSelected.Index + 1);

                else if (monthSelected.Index == 0)
                {
                    this.ProximoMes = MesCorrente;
                    this.MesCorrente = this.MesAnterior;
                    this.MesAnterior = string.Empty;
                }

                OnPropertyChanges("DiasDoMes");
            }
        }

        public ICommand NextMonthCommand
        {
            get { return nextMonthCommand; }
        }

        public ICommand PreviewMonthCommand
        {
            get { return previewMonthCommand; }

        }
    }
}
