using System;
using System.Threading.Tasks;
using BagrutProject_2027.Models;
using BagrutProject_2027.Services;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace BagrutProject_2027.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        private string _name = string.Empty;
        private string _email = string.Empty;
        private string _firstName = string.Empty;
        private string _lastName = string.Empty;
        private DateTime _birthDate = DateTime.Today;
        private string _password = string.Empty;
        private string _confirmPassword = string.Empty;
        private string _message = string.Empty;
        private Color _messageColor = Colors.White;
        private bool _isPasswordHidden = true;
        private bool _isConfirmPasswordHidden = true;

        public RegisterViewModel()
        {
            RegisterCommand = new Command(
                async () => await RegisterAsync());

            GoToLoginCommand = new Command(
                async () => await GoToLoginAsync());

            TogglePasswordCommand =
                new Command(TogglePassword);

            ToggleConfirmPasswordCommand =
                new Command(ToggleConfirmPassword);
        }

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        public string FirstName
        {
            get => _firstName;
            set => SetProperty(ref _firstName, value);
        }

        public string LastName
        {
            get => _lastName;
            set => SetProperty(ref _lastName, value);
        }

        public DateTime BirthDate
        {
            get => _birthDate;
            set => SetProperty(ref _birthDate, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public string ConfirmPassword
        {
            get => _confirmPassword;
            set => SetProperty(ref _confirmPassword, value);
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

        public bool IsConfirmPasswordHidden
        {
            get => _isConfirmPasswordHidden;
            set
            {
                if (SetProperty(ref _isConfirmPasswordHidden, value))
                {
                    OnPropertyChanged(
                        nameof(ConfirmPasswordToggleText));
                }
            }
        }

        public string PasswordToggleText =>
            IsPasswordHidden ? "Show" : "Hide";

        public string ConfirmPasswordToggleText =>
            IsConfirmPasswordHidden ? "Show" : "Hide";

        public Command RegisterCommand { get; }
        public Command GoToLoginCommand { get; }
        public Command TogglePasswordCommand { get; }
        public Command ToggleConfirmPasswordCommand { get; }

        private void TogglePassword()
        {
            IsPasswordHidden = !IsPasswordHidden;
        }

        private void ToggleConfirmPassword()
        {
            IsConfirmPasswordHidden =
                !IsConfirmPasswordHidden;
        }

        private async Task RegisterAsync()
        {
            string name = Name.Trim();
            string email = Email.Trim();
            string firstName = FirstName.Trim();
            string lastName = LastName.Trim();
            string password = Password;
            string confirmPassword = ConfirmPassword;
            DateTime birth = BirthDate.Date;

            // Check required fields.
            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(firstName) ||
                string.IsNullOrWhiteSpace(lastName))
            {
                ShowMessage(
                    "Please fill in all the fields",
                    Colors.Red);

                return;
            }

            // Check the email format required by this project.
            if (!email.EndsWith(
                "@gmail.com",
                StringComparison.OrdinalIgnoreCase) ||
                email.Length <= 10)
            {
                ShowMessage(
                    "Email must be something@gmail.com",
                    Colors.Red);

                return;
            }

            // Check for an existing account.
            if (DataRepo.EmailExists(email))
            {
                ShowMessage(
                    "This email is already registered",
                    Colors.Red);

                return;
            }

            // Check the birth date.
            if (birth > DateTime.Today)
            {
                ShowMessage(
                    "Birth date cannot be in the future",
                    Colors.Red);

                return;
            }

            // Check password length.
            if (password.Length < 6)
            {
                ShowMessage(
                    "Password must be at least 6 characters",
                    Colors.Red);

                return;
            }

            // Check confirmation.
            if (password != confirmPassword)
            {
                ShowMessage(
                    "Passwords do not match",
                    Colors.Red);

                return;
            }

            // Create the new user.
            var newUser = new User
            {
                Name = name,
                Email = email,
                PName = firstName,
                FName = lastName,
                Password = password,
                BirthDate = birth
            };

            DataRepo.Add(newUser);

            // Clear the form after registration.
            Name = string.Empty;
            Email = string.Empty;
            FirstName = string.Empty;
            LastName = string.Empty;
            Password = string.Empty;
            ConfirmPassword = string.Empty;
            BirthDate = DateTime.Today;

            IsPasswordHidden = true;
            IsConfirmPasswordHidden = true;

            ShowMessage(
                "Registered successfully!",
                Colors.Green);

            await Task.Delay(700);

            await Shell.Current.GoToAsync("//LoginPage");
        }

        private async Task GoToLoginAsync()
        {
            await Shell.Current.GoToAsync("//LoginPage");
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