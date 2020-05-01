
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Octus.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectSpecialization : ContentPage
    {
        public SelectSpecialization()
        {
            InitializeComponent();

            BindingContext = new ViewModels.SelectSpecialization();
        }
    }
}