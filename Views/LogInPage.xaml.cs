using BagrutProject_2027.Models;
using BagrutProject_2027.Services;

namespace BagrutProject_2027.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private async void OnLoginClicked(object? sender, EventArgs e)// this method is called when the login button is clicked
    {
        string email = EmailEntry.Text ?? "";
        string password = PasswordEntry.Text ?? "";

        // 1. check that fields are not empty
        if (email == "")
        {
            MessageLabel.TextColor = Colors.Red;
            MessageLabel.Text = "Please enter an email";
            return;
        }
        if (password == "")
        {
            MessageLabel.TextColor = Colors.Red;
            MessageLabel.Text = "Please enter a password";
            return;
        }

        if (!email.EndsWith("@gmail.com", StringComparison.OrdinalIgnoreCase))
        {
            MessageLabel.TextColor = Colors.Red;
            MessageLabel.Text = "Email must end with @gmail.com";
            return;
        }

        // 2. look for the user in the list
        User? user = DataRepo.Login(email, password);

        if (user == null)// if the user is not found, display an error message
        {
            MessageLabel.TextColor = Colors.Red;
            MessageLabel.Text = "Wrong email or password";
        }
        else// if the user is found, navigate to the main page
        {
            MessageLabel.TextColor = Colors.Green;
            MessageLabel.Text = "Login successful!";
            await Task.Delay(1000);   // wait 1 second
            await Shell.Current.GoToAsync("//MainPage");
        }
    }
    private void btnShowPassword3(object sender, EventArgs e)//it shows the password by making isPassword go from true to false for password entery
    {
        PasswordEntry.IsPassword = !PasswordEntry.IsPassword;
    }

    private async void OnRegisterClicked(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//RegisterPage");// this will navigate to the RegisterPage when the register button is clicked
    }
}