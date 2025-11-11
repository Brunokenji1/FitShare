namespace AppFitShare.Views.TelasCadastroCompleto;

public partial class CadastroRestricaoFisica : ContentPage
{
	public CadastroRestricaoFisica()
	{
		InitializeComponent();
	}
    private async void BtnOrtopedia(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new CadastroSaudeCondicionamento());
    }
    private async void BtnMuscularesArticulares(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new CadastroSaudeCondicionamento());
    }
    private async void BtnNeurologico(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new CadastroSaudeCondicionamento());
    }

    private async void BtnCardiorrespiratorio(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new CadastroSaudeCondicionamento());
    }

    private async void BtnOutrasRestricoes(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new CadastroSaudeCondicionamento());
    }
   
    public async void BtnCadastroCondicoesMedicas(object sender, EventArgs e)
    {

        await Navigation.PushAsync(new CadastroSaudeCondicionamento());
    }
}