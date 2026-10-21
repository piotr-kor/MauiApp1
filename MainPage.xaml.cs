namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnSubmitClicked(object? sender, EventArgs e)
        {
            string email = EmailEntry.Text?.Trim() ?? "";
            string password = PasswordEntry.Text ?? "";
            string repeatPassword = RepeatPasswordEntry.Text ?? "";

            NextButton.IsVisible = false;

            if (!email.Contains('@') || !email.Contains('.'))
            {
                MessageLabel.Text = "Nieprawidłowy adres e-mail";
            }
            else if (string.IsNullOrWhiteSpace(password))
            {
                MessageLabel.Text = "Podaj hasło";
            }
            else if (password != repeatPassword)
            {
                MessageLabel.Text = "Hasła się różnią";
            }
            else
            {
                MessageLabel.Text = $"Witaj {email}";
                NextButton.IsVisible = true;
            }
        }

        private async void OnNextClicked(object? sender, EventArgs e)
        {
            var data = new Dictionary<string, object>
            {
                ["Email"] = EmailEntry.Text?.Trim() ?? ""
            };

            await Shell.Current.GoToAsync(
                nameof(PersonalDataPage), data);
        }
    }
}