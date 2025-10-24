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
            var usuariosCadastrados = RepositorioUsuarios.ListarTodos();

            string identificador = txt_usuario.Text?.Trim();
            string senha = txt_senha.Text?.Trim();

            if(string.IsNullOrWhiteSpace(identificador) || string.IsNullOrWhiteSpace(senha))
            {
                throw new Exception("Preencha todos os campos!");
            }
            var usuarioEncontrado = usuariosCadastrados.FirstOrDefault(usuario =>
                ((usuario.Username?.Equals(identificador, StringComparison.OrdinalIgnoreCase) == true) ||
                (usuario.Email?.Equals(identificador, StringComparison.OrdinalIgnoreCase) == true ))
                && usuario.Senha == senha);

            if (usuarioEncontrado != null)
            {
                await SecureStorage.Default.SetAsync("usuario_logado", usuarioEncontrado.Nome);
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
