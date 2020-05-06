    
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Octus.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectSpecialist : ContentPage
    {
        public SelectSpecialist(Models.Especializacao especializacao)
        {
            InitializeComponent();

            BindingContext = new ViewModels.SelectSpecialist(especializacao);
        }

        void ListSpecialist_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
           
        }
    }
}