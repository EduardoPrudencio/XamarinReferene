using Newtonsoft.Json;
using Octus.GetData;
using Octus.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Octus.ViewModels
{
    public class SelectSpecialist : ViewModelBase
    {
        SpecializationManager _specializationManager;

        Especialista _especialistaSelecionado = null;
        ObservableCollection<Especialista> _especialistas;
        bool _profissionalSelecionado = false;

        public SelectSpecialist(Especializacao especializacao)
        {
            _specializationManager = new SpecializationManager();
            GetSpecialistsBySpecialization(especializacao);
        }

        private void GetSpecialistsBySpecialization(Especializacao especialista)
        {
            List<Especialista> listChanged = JsonConvert.DeserializeObject<List<Especialista>>(_specializationManager.GetSpecialists(especialista.Name));
            _especialistas = new ObservableCollection<Especialista>(listChanged);
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
                    OnPropertyChanges("EspecializacaoPendenteDeEscolha");
                }
            }
        }

        public ObservableCollection<Especialista> Especialistas
        {
            get
            {
                return _especialistas;
            }
            set
            {
                if (_especialistas != value)
                {
                    _especialistas = value;
                    OnPropertyChanges("Especialistas");
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
                    App.Current.MainPage.Navigation.PushAsync(new Views.Agendar(value));
                }
            }
        }
    }
}
