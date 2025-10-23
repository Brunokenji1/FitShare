using AppFitShare.Repositories;

namespace AppFitShare.Views;

public partial class Menu : ContentPage
{
	public Menu()
	{
		InitializeComponent();

		string? usuario_logado = null;

		Task.Run(async () =>
		{
			usuario_logado = await SecureStorage.Default.GetAsync("usuario_logado");
        });

    }
	private async void OnTapSair(object sender, TappedEventArgs e)
	{
        var label = (Label)sender;
        label.IsEnabled = false;

        bool confirmacao = await DisplayAlert("Confirma��o", "Deseja realmente sair da sua conta?", "Sim", "N�o");
        if (confirmacao)
		{
            SecureStorage.Default.Remove("usuario_logado");
			App.Current.MainPage = new NavigationPage(new Login());
        }
		label.IsEnabled = true;
    }
    private void OnTapHome(object sender, TappedEventArgs e)
    {
        if (Application.Current.MainPage is FlyoutPage flyoutpage)
        {
            flyoutpage.Detail = new NavigationPage(new Home());
            flyoutpage.IsPresented = false;
        }
    }
    private void OnTapMeusTreinos(object sender, TappedEventArgs e)
	{
        if (Application.Current.MainPage is FlyoutPage flyoutpage)
		{
			flyoutpage.Detail = new NavigationPage(new MeusTreinos());
			flyoutpage.IsPresented = false;
        }
    }
    private void OnTapAlimentacao(object sender, TappedEventArgs e)
    {
        if (Application.Current.MainPage is FlyoutPage flyoutpage)
        {
            flyoutpage.Detail = new NavigationPage(new Alimentacao());
            flyoutpage.IsPresented = false;
        }
    }
    private void OnTapConfiguracao(object sender, TappedEventArgs e)
    {
        if (Application.Current.MainPage is FlyoutPage flyoutpage)
        {
            flyoutpage.Detail = new NavigationPage(new Configuracao());
            flyoutpage.IsPresented = false;
        }
    }
    private void OnTapSuporte(object sender, TappedEventArgs e)
    {
        if (Application.Current.MainPage is FlyoutPage flyoutpage)
        {
            flyoutpage.Detail = new NavigationPage(new Suporte());
            flyoutpage.IsPresented = false;
        }
    }
    private void OnTapPerfil(object sender, TappedEventArgs e)
    {
        if (Application.Current.MainPage is FlyoutPage flyoutpage)
        {
            flyoutpage.Detail = new NavigationPage(new Perfil());
            flyoutpage.IsPresented = false;
        }
    }
}