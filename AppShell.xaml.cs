namespace MauiApp1
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(
                nameof(PersonalDataPage),
                typeof(PersonalDataPage));
        }
    }
}