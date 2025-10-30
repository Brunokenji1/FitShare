namespace AppFitShare.Views;

public partial class PlanoAlimentacao : ContentPage
{
	public PlanoAlimentacao()
	{
		InitializeComponent();
	}

    private async void BotaoPlanoAlimentar(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new MinhasDietas());
    }
}