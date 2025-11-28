using AppFitShare.Repositories;

namespace AppFitShare;

public partial class ExerciciosTreinos : ContentPage

{
	public ExerciciosTreinos()
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