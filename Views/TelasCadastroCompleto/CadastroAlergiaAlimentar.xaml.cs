using AppFitShare.Repositories;
using System.Threading.Tasks;

namespace AppFitShare.Views.TelasCadastroCompleto;

public partial class CadastroAlergiaAlimentar : ContentPage
{
	public CadastroAlergiaAlimentar()
	{
		InitializeComponent();
        RepositorioUsuarios.IniciarUsuarioTemp();
	}
    private async void BtnVoltar(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private void BtnNao(object sender, TappedEventArgs e)
    {

    }

    private void BtnLactose(object sender, TappedEventArgs e)
    {

    }

    private void BtnNozes(object sender, TappedEventArgs e)
    {

    }

    private void BtnSoja(object sender, TappedEventArgs e)
    {

    }

    private void BtnFrutosDoMar(object sender, TappedEventArgs e)
    {

    }

    private void BtnAmendoim(object sender, TappedEventArgs e)
    {

    }

    private void BtnPeixe(object sender, TappedEventArgs e)
    {

    }

    private void BtnOvo(object sender, TappedEventArgs e)
    {

    }

    private async void BtnContinuar(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CadastroEstiloAlimentacao());

    }
}