using System.Threading.Tasks;

namespace AppFitShare.Views;

public partial class ExerciciosSuperiores : ContentPage
{
	public ExerciciosSuperiores()
	{
		InitializeComponent();
	}
	private void Voltar(object sender, EventArgs e)
	{
		Navigation.PopAsync();
	}
}