﻿using Octus.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Octus.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Agendar : ContentPage
    {
        ViewModels.Agendar agendar;

        public Agendar()
        {
            InitializeComponent();

            agendar = new ViewModels.Agendar();
            BindingContext = agendar;

        }

        public Agendar(Especialista especialista)
        {
            InitializeComponent();

            agendar = new ViewModels.Agendar(especialista);
            BindingContext = agendar;

        }

    }
}