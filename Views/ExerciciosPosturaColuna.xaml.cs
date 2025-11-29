namespace AppFitShare.Views;

public partial class ExerciciosPosturaColuna : ContentPage
{
	public ExerciciosPosturaColuna()
	{
		InitializeComponent();
	}
    private async void Voltar(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
    private async void CriarLista(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MeusTreinos2());
    }
}