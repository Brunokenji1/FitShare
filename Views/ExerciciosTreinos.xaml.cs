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
}