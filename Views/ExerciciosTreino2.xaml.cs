using AppFitShare.Repositories;
using AppFitShare.Views;

namespace AppFitShare.Views;

public partial class ExerciciosTreino2 : ContentPage
{
	public ExerciciosTreino2()
	{
		InitializeComponent();
	}
	private void Voltar(object sender, EventArgs e)
	{
		Navigation.PopAsync();
	}
    private void IniciarTreino(object sender, EventArgs e)
    {
        RepositorioHistorico.MarcarTreinoHoje();
    }
}