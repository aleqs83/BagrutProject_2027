using BagrutProject_2027.Models;
using BagrutProject_2027.Services;

namespace BagrutProject_2027.Views;

public partial class RegisterPage : ContentPage
{
	public RegisterPage()
	{
		InitializeComponent();

	}
    // shows a red error message
    private void ShowError(string text)
    {
        MessageLabel.TextColor = Colors.Red;
        MessageLabel.Text = text;
    }

    private async void OnRegisterClicked(object? sender, EventArgs e)
    {
        // get the values from the entries
        string name = NameEntry.Text ?? "";
        string email = EmailEntry.Text ?? "";
        string pname = PNameEntry.Text ?? "";
        string fname = FNameEntry.Text ?? "";
        string password = PasswordEntry1?.Text ?? "";
        string confirm = ConfirmEntry.Text ?? "";
        DateTime birth = Convert.ToDateTime(BirthDatePicker.Date);// get the date from the date picker

        // check one thing at a time - stop at the first error
        if (name == "" || email == "" || pname == "" || fname == "")// check that all fields are filled
        {
            ShowError("Please fill in all the fields");
            return;
        }

        if (!email.EndsWith("@gmail.com", StringComparison.OrdinalIgnoreCase) || email.Length <= 10)// check that the email is valid (must be something@gmail.com)
        {
            ShowError("Email must be something@gmail.com");
            return;
        }

        if (DataRepo.EmailExists(email))
        {
            ShowError("This email is already registered");
            return;
        }

        if (birth > DateTime.Today)
        {
            ShowError("Birth date cannot be in the future");
            return;
        }

        if (password.Length < 6)
        {
            ShowError("Password must be at least 6 characters");
            return;
        }

        if (password != confirm)
        {
            ShowError("Passwords do not match");
            return;
        }

        // everything is OK - create the user and add to the list
        User newUser = new User();
        newUser.Name = name;
        newUser.Email = email;
        newUser.PName = pname;
        newUser.FName = fname;
        newUser.Password = password;
        newUser.BirthDate = birth;

        DataRepo.Add(newUser);
        // clear the entries
        NameEntry.Text = "";
        EmailEntry.Text = "";
        PNameEntry.Text = "";
        FNameEntry.Text = "";
        PasswordEntry1.Text ="";
        ConfirmEntry.Text = "";
        MessageLabel.Text = "";

        MessageLabel.TextColor = Colors.Green;
        MessageLabel.Text = "Registered successfully!";
        await Task.Delay(1000);   // wait 1 second
        await Shell.Current.GoToAsync("//LoginPage");
    }

    private void btnShowPassword1(object sender, EventArgs e)//it shows the password by making isPassword go from true to false for password entery
    {
        PasswordEntry1.IsPassword = !PasswordEntry1.IsPassword;
    }
    private void btnShowPassword2(object sender, EventArgs e)//it shows the password by making isPassword go from true to false for password confirm entery
    {
        ConfirmEntry.IsPassword = !ConfirmEntry.IsPassword;
    }

    private async void OnBackClicked(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//LoginPage");
    }
}