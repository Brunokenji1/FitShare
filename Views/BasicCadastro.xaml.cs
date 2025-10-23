using AppFitShare.Models;
using AppFitShare.Repositories;

namespace AppFitShare.Views;

public partial class BasicCadastro : ContentPage
{
	public BasicCadastro()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            var usuario = new Usuario(01, txt_nome.Text, txt_email.Text, txt_senha.Text);
            usuarioService.SalvarUsuario(usuario);
            RepositorioUsuarios usuarios = new RepositorioUsuarios();
            Usuario dados_digitados = new Usuario(01, txt_nome.Text, txt_email.Text, txt_senha.Text);
            
            if (usuarios.Whele)
            {
                await SecureStorage.Default.SetAsync("usuario_logado", dados_digitados.Nome);
                App.Current.MainPage = new FlyoutPageMenu();
            }
            else
            {
                throw new Exception("Usuário ou senha inválidos!");
            }


        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops...", ex.Message, "Fechar");
        }
    }
}