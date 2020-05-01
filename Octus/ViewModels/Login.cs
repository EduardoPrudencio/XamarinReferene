using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Octus.ViewModels
{
    public class Login : ViewModelBase
    {
        private string _loginText = string.Empty;
        private string _senha = string.Empty;

        public event EventHandler OnLoginOk;


        public Login()
        {

#if DEBUG
            this.LoginText = "Admin";
            this.Senha = "123456";
#endif
            LoginCommand = new Command(
                execute: () =>
                {
                    if (LoginText.Trim().Equals("Admin") && Senha.Trim().Equals("123456"))
                    {
                        LoginOk();
                        //App.Current.MainPage.Navigation.PushAsync(new Views.Agendar());
                        App.Current.MainPage.Navigation.PushAsync(new Views.SelectSpecialization());
                        Shell.Current.CurrentItem.Items.RemoveAt(0);
                    }
                    else
                        App.Current.MainPage.DisplayAlert("Alerta", "Não foi possível realizar o login com os dados informados", "Fechar");
                },
                canExecute: () => { return true; });
        }

        private void LoginOk()
        {
            if (OnLoginOk != null)
                OnLoginOk(this, EventArgs.Empty);
        }

        public string LoginText
        {
            get
            {
                return _loginText;
            }
            set
            {
                if (!_loginText.Equals(value))
                {
                    _loginText = value;
                    OnPropertyChanges("LoginText");
                }
            }
        }

        public string Senha
        {
            get
            {
                return _senha;
            }
            set
            {
                if (!_senha.Equals(value))
                {
                    _senha = value;
                    OnPropertyChanges("Senha");
                }
            }
        }

        public ICommand LoginCommand { get; private set; }
    }
}
