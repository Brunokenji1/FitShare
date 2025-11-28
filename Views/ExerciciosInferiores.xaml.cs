using System.Threading.Tasks;

namespace AppFitShare.Views;

public partial class ExerciciosInferiores : ContentPage
{
    public ExerciciosInferiores()
    {
        InitializeComponent();
    }
	private void Voltar(object Sender, EventArgs e)
	{
		Navigation.PopAsync();
	}

}