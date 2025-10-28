namespace AppFitShare.Views;

public partial class Perfil : ContentPage
{
	public Perfil()
	{
		InitializeComponent();
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
}