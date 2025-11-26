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
}