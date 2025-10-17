using AppFitShare.Models;

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
            List<Usuario> lista_usuarios = new List<Usuario>()
            {
                new Usuario(1, "B", "b@gmail.com", "123456"),
                new Usuario(2, "A", "a@gmail.com", "abcde"),
            };
            Usuario dados_digitados = new Usuario(0, txt_usuario.Text, "", txt_senha.Text);


            if (lista_usuarios.Any(usuario => (dados_digitados.Nome == usuario.Nome && dados_digitados.Senha == usuario.Senha)))
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

    private void OnButtonClickedCadastroBasico(object sender, EventArgs e)
    {

    }

    private void OnTapCadastrar(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new BasicCadastro());
    }
}
