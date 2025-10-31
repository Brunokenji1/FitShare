using AppFitShare.Models;
using AppFitShare.Repositories;
namespace AppFitShare.Views;

public partial class Login : ContentPage
{

    public Login()
    {
        InitializeComponent();
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
        if (txt_senha.IsPassword)
        {
            imagebButton.Source = "eye_closed.png";
        }
        else
        {
            imagebButton.Source = "eye_open.png";
        }
    }
}
