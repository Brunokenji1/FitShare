namespace AppFitShare.Views;

public partial class PlanoAlimentarAPage : ContentPage
{
	public PlanoAlimentarAPage()
	{
		InitializeComponent();
	}
	private async void Voltar(object sender, EventArgs e)
	{
		await Navigation.PopAsync();
    }
}