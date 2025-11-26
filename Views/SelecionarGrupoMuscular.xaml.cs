namespace AppFitShare.Views;

public partial class SelecionarGrupoMuscular : ContentPage
{
	public SelecionarGrupoMuscular()
	{
		InitializeComponent();
	}
	
	private async void BtnSelecionarExercicio(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new EscolherExercicio());
	}
	private async void BtnVoltar(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
	private async void BtnTreinosInferiores(object sender, TappedEventArgs e)
	{
		await Navigation.PushAsync(new ExerciciosInferiores());
	}
    private async void BtnTreinosSuperiores(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new ExerciciosSuperiores());
    }
    private async void BtnTreinosPosturaColuna(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new ExerciciosPosturaColuna());
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {

    }
}