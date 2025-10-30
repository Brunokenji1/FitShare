using AppFitShare.Views;
using Microsoft.Maui.Storage;

namespace AppFitShare;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        var window = new Window
        {
            Title = "App Fit Share",
            Width = 800,
            Height = 850
        };
        var usuario_logado = SecureStorage.Default.GetAsync("usuario_logado").GetAwaiter().GetResult();
        if (string.IsNullOrEmpty(usuario_logado))
        {
            window.Page = new NavigationPage(new Login());
        }
        else
        {
            window.Page = new NavigationPage(new TabbedPageMenu());
        }
        return window;
    }
}
