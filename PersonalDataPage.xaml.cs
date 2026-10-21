namespace MauiApp1
{
    public partial class PersonalDataPage :
        ContentPage, IQueryAttributable         // IQueryAttributable pozwala odbierać dane przekazane podczas nawigacji
                                                // Zobowiązuje klasę do udostępnienia metody ApplyQueryAttributes,
                                                // której MAUI używa do przekazywania danych podczas nawigacji.
    {
        private string _email = "";

        public PersonalDataPage()
        {
            InitializeComponent();
        }

        // ApplyQueryAttributes to metoda wywoływana przez MAUI, gdy strona otrzymuje
        // dane przekazane podczas nawigacji.
        public void ApplyQueryAttributes(
            IDictionary<string, object> przekazaneDane)
        {
            if (przekazaneDane.TryGetValue("Email", out var email))
                _email = email?.ToString() ?? "";
        }

        private void OnSummaryClicked(object? sender, EventArgs e)
        {
            string firstName = FirstNameEntry.Text?.Trim() ?? "";
            string lastName = LastNameEntry.Text?.Trim() ?? "";
            string address = AddressEntry.Text?.Trim() ?? "";
            string pesel = PeselEntry.Text?.Trim() ?? "";

            SummaryTitle.IsVisible = false;
            SummaryLabel.Text = "";

            if (string.IsNullOrWhiteSpace(firstName) ||
                string.IsNullOrWhiteSpace(lastName) ||
                string.IsNullOrWhiteSpace(address))
            {
                MessageLabel.Text =
                    "Wypełnij imię, nazwisko i adres.";
                return;
            }

            if (pesel.Length != 11 || !pesel.All(char.IsDigit))
            {
                MessageLabel.Text =
                    "PESEL musi składać się z 11 cyfr.";
                return;
            }

            MessageLabel.Text = "";
            SummaryTitle.IsVisible = true;

            SummaryLabel.Text =
                $"E-mail: {_email}\n" +
                $"Imię: {firstName}\n" +
                $"Nazwisko: {lastName}\n" +
                $"Adres: {address}\n" +
                $"PESEL: {pesel}";
        }
    }
}