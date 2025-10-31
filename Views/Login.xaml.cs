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
                //await SecureStorage.Default.SetAsync("usuario_logado", usuarioEncontrado.Nome);
                RepositorioUsuarios.LogarUsuario(usuarioEncontrado);
                App.Current.MainPage = new NavigationPage(new TabbedPageMenu());
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

    private async void OnTapCadastrar(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new BasicCadastro());
    }

    private async void OnTapRecuperarSenha(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new RecuperarSenha());
    }

    private void Button_Pressed(object sender, EventArgs e)
    {

    }

    private void IbtnSenhaVisibilidade(object sender, EventArgs e)
    {
        txt_senha.IsPassword = !txt_senha.IsPassword;
        var imagebButton = (ImageButton)sender;
        if(txt_senha.IsPassword)
        {
            imagebButton.Source = "eye_closed.png";
        }
        else
        {
            imagebButton.Source = "eye_open.png";
        }
    }
}
