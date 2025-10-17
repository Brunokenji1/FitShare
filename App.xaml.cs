using AppFitShare.Views;
namespace AppFitShare
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //Task.Run(async () =>
            //{
            //    usuario_logado = await SecureStorage.Default.GetAsync("usuario_logado");
            //});
            MainPage = new NavigationPage( new Login());
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