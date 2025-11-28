namespace AppFitShare.Views;

public partial class PlanoAlimentarA : ContentPage
{
	public PlanoAlimentarA()
	{
		InitializeComponent();
	}
	private async void Voltar(object sender, EventArgs e)
	{
		await Navigation.PopAsync();
    }
}