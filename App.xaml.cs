using AppFitShare.Views;

namespace AppFitShare
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage( new Login());
        }

    }
}