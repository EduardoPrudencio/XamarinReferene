
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Octus.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {

        ViewModels.Login loginViewModel;

        public Login()
        {
            InitializeComponent();

            loginViewModel = new ViewModels.Login();
            loginViewModel.OnLoginOk += LoginViewModel_OnLoginOk;

            BindingContext = (loginViewModel);

            Shell.SetTabBarIsVisible(this, false);
            Shell.SetNavBarIsVisible(this, false);
        }

        private void LoginViewModel_OnLoginOk(object sender, System.EventArgs e)
        {
            Shell.SetTabBarIsVisible(this, true);
            Shell.SetNavBarIsVisible(this, true);
        }
    }
}