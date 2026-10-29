using System;
using System.Threading.Tasks;
using BagrutProject_2027.Services;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace BagrutProject_2027.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _email = string.Empty;
        private string _password = string.Empty;
        private string _message = string.Empty;
        private Color _messageColor = Colors.White;
        private bool _isPasswordHidden = true;

        public LoginViewModel()
        {
            LoginCommand = new Command(
                async () => await LoginAsync());

            GoToRegisterCommand = new Command(
                async () => await GoToRegisterAsync());

            TogglePasswordCommand =
                new Command(TogglePassword);
        }

        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        public Color MessageColor
        {
            get => _messageColor;
            set => SetProperty(ref _messageColor, value);
        }

        public bool IsPasswordHidden
        {
            get => _isPasswordHidden;
            set
            {
                if (SetProperty(ref _isPasswordHidden, value))
                {
                    OnPropertyChanged(
                        nameof(PasswordToggleText));
                }
            }
        }

        public string PasswordToggleText =>
            IsPasswordHidden ? "Show" : "Hide";

        public Command LoginCommand { get; }
        public Command GoToRegisterCommand { get; }
        public Command TogglePasswordCommand { get; }

        private void TogglePassword()
        {
            IsPasswordHidden = !IsPasswordHidden;
        }

        private async Task LoginAsync()
        {
            string email = Email.Trim();
            string password = Password;

            if (string.IsNullOrWhiteSpace(email))
            {
                ShowMessage(
                    "Please enter an email",
                    Colors.Red);

                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                ShowMessage(
                    "Please enter a password",
                    Colors.Red);

                return;
            }

            if (!email.EndsWith(
                "@gmail.com",
                StringComparison.OrdinalIgnoreCase))
            {
                ShowMessage(
                    "Email must end with @gmail.com",
                    Colors.Red);

                return;
            }

            var user = DataRepo.Login(email, password);

            if (user == null)
            {
                ShowMessage(
                    "Wrong email or password",
                    Colors.Red);

                return;
            }

            ShowMessage(
                "Login successful!",
                Colors.Green);

            await Task.Delay(700);

            await Shell.Current.GoToAsync("//MainPage");
        }

        private async Task GoToRegisterAsync()
        {
            await Shell.Current.GoToAsync("//RegisterPage");
        }

        private void ShowMessage(
            string message,
            Color color)
        {
            Message = message;
            MessageColor = color;
        }
    }
}