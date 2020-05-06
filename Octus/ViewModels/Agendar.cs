using Newtonsoft.Json;
using Octus.GetData;
using Octus.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Octus.ViewModels
{
    public class Agendar : ViewModelBase
    {
        ScheduleManager scheduleManager;
        SpecializationManager _specializationManager;

        bool _especializacaoPendenteDeEscolha = true;
        string _mesAnterior = string.Empty;
        string _mesCorrente = string.Empty;
        string _proximoMes = string.Empty;
        int _indexMonthSelected = 0;

        Especializacao _especializacaoSelecionada = null;
        Especialista _especialistaSelecionado = null;
        DayToShow _diaSelecionado = null;
        ObservableCollection<Especializacao> _especializacoes;

        ICommand nextMonthCommand;
        ICommand previewMonthCommand;

        List<MonthsToShow> months;

        public Agendar()
        {
            PrepararDados();
        }

        public Agendar(Especialista especialista)
        {
            if (App.Current.MainPage != null && especialista == null)
                App.Current.MainPage.Navigation.PushAsync(new Views.SelectSpecialization());

            _especialistaSelecionado = especialista;

            PrepararDados();

            if (especialista != null)
            {
                _especializacaoPendenteDeEscolha = false;
                OnPropertyChanges("EspecializacaoPendenteDeEscolha");
            }
        }


        private void PrepararDados()
        {
            nextMonthCommand = new Command(OnNextMonth);
            previewMonthCommand = new Command(OnPreviewMonth);

            scheduleManager = new ScheduleManager();
            _specializationManager = new SpecializationManager();

            RefreshMonts();
            PrepairEspecializations();
        }

        private void RefreshMonts(int month = 0)
        {
            month = (month == 0) ? DateTime.Now.Month : month;

            months = scheduleManager.GetMonthTranslated(3, month - 1);

            this.MesAnterior = (month == DateTime.Now.Month) ? string.Empty : ((months.Count == 3) ? months[0].MonthName : string.Empty);
            this.MesCorrente = months[1].MonthName;
            this.ProximoMes = (months[1].Index < months[2].Index) ? months[2].MonthName : string.Empty;
        }

        private void PrepairEspecializations()
        {
            List<Especializacao> especializacoes = JsonConvert.DeserializeObject<List<Especializacao>>(_specializationManager.GetSpecializations());
            _especializacoes = new ObservableCollection<Especializacao>(especializacoes);
        }

        private async Task<bool> ConfirmarAgendamento()
        {
            bool answer = await App.Current.MainPage.DisplayAlert("Atenção", "Deseja confirmar esse ajendamento?", "Sim", "Não");

            if (answer)
            {
                MonthWithDays mwd = _especialistaSelecionado.Agenda
                                    .FirstOrDefault(x => x.Month == _indexMonthSelected);

                DayToShow day = mwd.Days.FirstOrDefault(d => d.InitialHour == _diaSelecionado.InitialHour);

                mwd.Days.Remove(day);

                day.Reserved = true;

                mwd.Days.Add(day);

                mwd.OrderDays();

                _diaSelecionado.Reserved = true;
                OnPropertyChanges("DiasDoMes");
            }


            return answer;
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
                    App.Current.MainPage.Navigation.PushAsync(new Views.SelectSpecialist(value));
                    OnPropertyChanges("Especializacoes");
                }
            }
        }

        public Especialista EspecialistaSelecionado
        {
            get
            {
                return _especialistaSelecionado;
            }
            set
            {
                if (_especialistaSelecionado != value)
                {
                    _especialistaSelecionado = value;
                }
            }
        }

        public DayToShow DiaSelecionado
        {
            get
            {
                return _diaSelecionado;
            }
            set
            {
                if (_diaSelecionado != value)
                {
                    _diaSelecionado = value;
                    var t = ConfirmarAgendamento();
                }
            }
        }



        public bool EspecializacaoPendenteDeEscolha
        {
            get
            {
                return _especializacaoPendenteDeEscolha;
            }
            set
            {
                if (_especializacaoPendenteDeEscolha != value)
                {
                    _especializacaoPendenteDeEscolha = value;
                    OnPropertyChanges("EspecializacaoPendenteDeEscolha");
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

                if (_especialistaSelecionado == null) return new List<DayToShow>();

                if(_especialistaSelecionado.Agenda.Max(x => x.Month) < _indexMonthSelected)
                    return new List<DayToShow>();

                _indexMonthSelected = (_indexMonthSelected == 0) ? DateTime.Now.Month : _indexMonthSelected;

                
                MonthWithDays monthWithDays = _especialistaSelecionado.Agenda
                                              .FirstOrDefault(a => a.Month == _indexMonthSelected);

                if (monthWithDays == null) return new List<DayToShow>();

                List<DayToShow> listaSemDiasPassados = monthWithDays.Days;

                listaSemDiasPassados = (_indexMonthSelected == DateTime.Now.Month)
                                        ? listaSemDiasPassados.Where(d => d.Day >= DateTime.Now.Day).ToList()
                                        : listaSemDiasPassados;

                return listaSemDiasPassados;
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
