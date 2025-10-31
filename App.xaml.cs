using AppFitShare.Repositories;
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
            Width = 412,
            Height = 915
        };
        var usuario_logado = RepositorioUsuarios.ObterUsuarioLogado();

        if (usuario_logado==null)
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
