namespace AppFitShare.Views;

public partial class Login : ContentPage
{
    public Login()
    {
        InitializeComponent();
    }
    private void ValidarLogin(object sender, EventArgs e)
    {
        Navigation.PushAsync(new FlyoutPageMenu());
    }

    private void OnButtonClickedCadastroBasico(object sender, EventArgs e)
    {

    }

    private void OnTapCadastrar(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new BasicCadastro());
    }
}
