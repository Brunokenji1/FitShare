using AppFitShare.Models;
using AppFitShare.Repositories;
namespace AppFitShare.Views;

public partial class Login : ContentPage
{
    public Login()
    {
        InitializeComponent();
    }
    private async void ValidarLogin(object sender, EventArgs e)
    {
        try
        {
            var usuario = RepositorioUsuarios.ObterPorEmail(txt_usuario.Text);
            Usuario dados_digitados = new Usuario(0, txt_usuario.Text, "", txt_senha.Text);
            if(usuario!= null && usuario.Senha == txt_senha.Text)
            {
                await SecureStorage.Default.SetAsync("usuario_logado", usuario.Nome);
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

    private void OnTapCadastrar(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new BasicCadastro());
    }
}
