namespace AppFitShare.Views.TelasCadastroCompleto;

public partial class CadastroSaudeCondicionamento : ContentPage
{
	public CadastroSaudeCondicionamento()
	{
		InitializeComponent();
	}
    private async void btnContinuar(object sender, EventArgs e)
    {
        try
        {


            await Navigation.PushAsync(new CadastroNivelDeAtividade());
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops...", ex.Message, "Fechar");
        }

    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {

    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new CadastroCondicoesMedicas());
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        Navigation.PushAsync(new CadastroRestricaoFisica());
    }
}