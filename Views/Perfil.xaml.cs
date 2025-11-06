using AppFitShare.Repositories;
using AppFitShare.Views.TelasCadastroCompleto;

namespace AppFitShare.Views;

public partial class Perfil : ContentPage
{
	public Perfil()
	{
		InitializeComponent();
	}
    private async void OnTapSair(object sender, EventArgs e)
    {
        var label = (Label)sender;
        label.IsEnabled = false;

        bool confirmacao = await DisplayAlert("Confirmação", "Deseja realmente sair da sua conta?", "Sim", "Não");
        if (confirmacao)
        {
            RepositorioUsuarios.DeslogarUsuario();
            App.Current.MainPage = new NavigationPage(new Login());
        }
        label.IsEnabled = true;
    }

    private async void OnCadastrarDados(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CadastrarDados());
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        var usuario = RepositorioUsuarios.ObterUsuarioLogado();
        imgPerfil.Source = usuario.FotoPerfil;
    }
}
