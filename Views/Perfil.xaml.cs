using AppFitShare.Repositories;
using AppFitShare.Views.TelasCadastroCompleto;
using System.Threading.Tasks;

namespace AppFitShare.Views;

public partial class Perfil : ContentPage
{
	public Perfil()
	{
		InitializeComponent();
    }

    private async void BtnCadastrarDados(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CadastrarDados());
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        var usuario = RepositorioUsuarios.ObterUsuarioLogado();

        lbl_username.Text = usuario.Username;
        lbl_nome.Text = usuario.Nome;
        if(usuario.Idade != null && usuario.Idade !=0)
        {
            lbl_idade.Text = $"Idade: {usuario.Idade}";
            lbl_idade.IsVisible = true;
        }
        if(usuario.Telefone != null && usuario.Telefone == "0")
        {
            lbl_telefone.Text = $"Telefone: {usuario.Telefone}";
            lbl_telefone.IsVisible = true;
        }
        if(usuario.Altura != null && usuario.Altura != 0)
        {
            lbl_altura.Text = $"Altura: {usuario.Altura}cm";
            lbl_altura.IsVisible = true;
        }
        if(usuario.Peso != null && usuario.Peso != 0)
        {
            lbl_peso.Text = $"Peso: {usuario.Peso}kg";
            lbl_peso.IsVisible = true;
        }
        
        imgPerfil.Source = usuario.FotoPerfil;
    }

    private async void BtnEditarPerfil(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EditarPerfil());
    }

    private async void BtnSair(object sender, EventArgs e)
    {
        bool confirmacao = await DisplayAlert("Confirmação", "Deseja realmente sair da sua conta?", "Sim", "Não");
        if (confirmacao)
        {
            RepositorioUsuarios.DeslogarUsuario();
            App.Current.MainPage = new NavigationPage(new Login());
        }
    }
}
