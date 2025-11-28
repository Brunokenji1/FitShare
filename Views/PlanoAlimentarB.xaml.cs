namespace AppFitShare.Views;

public partial class PlanoAlimentarB : ContentPage
{
	public PlanoAlimentarB()
	{
		InitializeComponent();
	}
	private async void Voltar(object sender, EventArgs e)
	{
		await Navigation.PopAsync();
    }	
}