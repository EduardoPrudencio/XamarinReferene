
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Octus.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Agendar : ContentPage
    {
        public Agendar()
        {
            InitializeComponent();

            BindingContext = new ViewModels.Agendar();
        }
    }
}