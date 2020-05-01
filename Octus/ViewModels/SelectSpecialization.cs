using Newtonsoft.Json;
using Octus.GetData;
using Octus.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Octus.ViewModels
{
    public class SelectSpecialization : ViewModelBase
    {

        SpecializationManager _specializationManager;
        bool _especializacaoPendenteDeEscolha = true;
        Especializacao _especializacaoSelecionada = null;
        ObservableCollection<Especializacao> _especializacoes;


        public SelectSpecialization()
        {
            _specializationManager = new SpecializationManager();
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

                    //_especializacaoSelecionada = value;
                    //EspecializacaoPendenteDeEscolha = _especializacaoSelecionada == null;
                    //GetSpecialistsBySpecialization(_especializacaoSelecionada);
                    //OnPropertyChanges("Especialistas");
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

        private void PrepairEspecializations()
        {
            List<Especializacao> especializacoes = JsonConvert.DeserializeObject<List<Especializacao>>(_specializationManager.GetSpecializations());
            _especializacoes = new ObservableCollection<Especializacao>(especializacoes);
        }

    }
}
