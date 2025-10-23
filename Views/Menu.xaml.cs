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

        bool confirmacao = await DisplayAlert("Confirmação", "Deseja realmente sair da sua conta?", "Sim", "Não");
        if (confirmacao)
		{
            SecureStorage.Default.Remove("usuario_logado");
			App.Current.MainPage = new NavigationPage(new Login());
        }
		label.IsEnabled = true;
    }
	private void OnTapMeusTreinos(object sender, TappedEventArgs e)
	{
        App.Current.MainPage=new MeusTreinos();
    }
}