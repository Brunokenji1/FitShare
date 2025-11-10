namespace AppFitShare.Views.TelasCadastroCompleto;

public partial class CadastroCondicoesMedicas : ContentPage
{
	public CadastroCondicoesMedicas()
	{
		InitializeComponent();
	}
    private async void BtnDoencaCardiovascular(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new CadastroSaudeCondicionamento());
    }
    private async void BtnMetabolicas(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new CadastroSaudeCondicionamento());
    }

    private async void BtnOsteoarticulares(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new CadastroSaudeCondicionamento());
    }
    private async void BtnNeurologicas(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new CadastroSaudeCondicionamento());
    }
    private async void BtnSensorial(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new CadastroSaudeCondicionamento());
    }
    private async void BtnRespiratórias(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new CadastroSaudeCondicionamento());
    }

    public async void BtnCadastroCondicoesMedicas(object sender, EventArgs e)
	{

		await Navigation.PushAsync(new CadastroSaudeCondicionamento());
    }

}