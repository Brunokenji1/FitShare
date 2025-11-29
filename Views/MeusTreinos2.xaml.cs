using AppFitShare.Models;
namespace AppFitShare.Views;


public partial class MeusTreinos2 : ContentPage
{
	private List<Treino> treinos = new();
    public MeusTreinos2()
	{
		InitializeComponent();
	}
	private void Voltar(object sender, EventArgs e)
	{
		Navigation.PopAsync();
	}
    private async void BotaoIniciarTreinoClicked2(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ExerciciosTreino2());
    }
}