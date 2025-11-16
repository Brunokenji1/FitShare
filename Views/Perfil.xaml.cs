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
    private async void btnTapSair(object sender, EventArgs e)
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

    private async void BtnCadastrarDados(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CadastrarDados());
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        var usuario = RepositorioUsuarios.ObterUsuarioLogado();
        
        lbl_nome.Text = usuario.Nome;
        if(usuario.Peso != 0 && usuario.Altura != 0)
        {
            lbl_altura.Text = $"Altura: {usuario.Altura} m";
            lbl_peso.Text = $"Peso: {usuario.Peso} kg";
            lbl_nivelAtividade.Text = $"Nível de Atividade: {usuario.NivelAtividade}";
            lbl_idade.Text = $"Idade: {usuario.Idade} anos";
            lbl_objetivo.Text = $"Objetivo: {usuario.Objetivo1}";
            lbl_telefone.Text = $"Telefone: {usuario.Telefone}";
        }
        
        
        
        imgPerfil.Source = usuario.FotoPerfil;
    }

    private async void BtnEditarPerfil(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EditarPerfil());
    }
}
