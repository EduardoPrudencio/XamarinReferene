using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Octus.GetData;
using Octus.Models;
using Xamarin.Forms;

namespace Octus.ViewModels
{
    public class Agenda : ViewModelBase
    {
        private string _title = "Agendamentos";
        private Especialista especialista;
        private ObservableCollection<AgendamentoRealizados> _agendamentoDoUsuario;

        public Agenda()
        {
            _agendamentoDoUsuario = new ObservableCollection<AgendamentoRealizados>();


            MessagingCenter.Subscribe<Agendar, DayToShow>(this, "NovoAgendamento", async
                (sender, args) =>
                {
                    await App.Current.MainPage.DisplayAlert("Alerta!", $"Confirmando o gendamento para o dia " +
                        $"{sender.DiaSelecionado.Day} de {sender.MesCorrente} no intervalo " +
                        $"{sender.DiaSelecionado.Interval} com { sender.EspecialistaSelecionado.Name}","Ok");

                    _agendamentoDoUsuario.Add(new AgendamentoRealizados(sender.DiaSelecionado, sender.MesCorrente, sender.EspecialistaSelecionado));
                });
        }

        public ObservableCollection<AgendamentoRealizados> Agendamentos
        {
            get { return _agendamentoDoUsuario; }
            set
            {
                if (value != _agendamentoDoUsuario)
                {
                    _agendamentoDoUsuario = value;
                    OnPropertyChanges("Agendamentos");
                }
            }
        }

    }
}
