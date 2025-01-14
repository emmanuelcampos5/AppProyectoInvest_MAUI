using AppProyectoInvest_MAUI.Controllers;
using AppProyectoInvest_MAUI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AppProyectoInvest_MAUI.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string _email;
        private string _password;
        private string _errorMessage;
        private bool _hasError;

        public string Email
        {
            get => _email;
            set { _email = value; OnPropertyChanged(); }
        }

        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(); }
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set { _errorMessage = value; OnPropertyChanged(); }
        }

        public bool HasError
        {
            get => _hasError;
            set { _hasError = value; OnPropertyChanged(); }
        }

        public ICommand LoginCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await LoginAsync());
        }

        private async Task LoginAsync()
        {
            HasError = false;

            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
            {
                ErrorMessage = "Por favor, complete todos los campos.";
                HasError = true;
                return;
            }

            var userLogin = new UserLogin { Email = Email, Password = Password };
            var apiResponse = await ApiController.Login(userLogin);

            if (apiResponse.Success)
            {
                // Maneja el inicio de sesión exitoso
                // Navegar a otra página, por ejemplo
                ErrorMessage = apiResponse.Message;
                HasError = true;
            }
            else
            {
                ErrorMessage = apiResponse.Message;
                HasError = true;
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
