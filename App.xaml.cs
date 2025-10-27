using AppFitShare.Views;
namespace AppFitShare
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new ContentPage();
            _ = VerificasLogin();
        }
        private async Task VerificasLogin() { 

            var usuario_logado = await SecureStorage.Default.GetAsync("usuario_logado");

            if(string.IsNullOrEmpty(usuario_logado))
            {
                MainPage = new TabbedPageMenu();
            }
            else
            {
                MainPage = new FlyoutPageMenu();
            }
            
        }
        protected override Window CreateWindow(IActivationState activationState)
        {
            var window = base.CreateWindow(activationState);
            window.Title = "App Fit Share";
            window.Width = 400;
            window.Height = 850;
            return window;

        }

    }
}