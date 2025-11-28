namespace AppFitShare.Views;

public partial class ExerciciosPosturaColuna : ContentPage
{
	public ExerciciosPosturaColuna()
	{
		InitializeComponent();
	}
    private void Voltar(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}