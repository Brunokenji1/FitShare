using AppFitShare.Views.TelasCadastroCompleto.TelasCadastroSaudeCondicionamento;
using System.Threading.Tasks;

namespace AppFitShare.Views.TelasCadastroCompleto;

public partial class CadastroCondicoesMedicas : ContentPage
{
	public CadastroCondicoesMedicas()
	{
		InitializeComponent();
	}



    private async void BtnCardiacasCirculatórias(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new CMOpcoesCardiacasCirculares());
    }
    private async void BtnMetabolicas(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new CMOpcoesMetabolicas());
    }
    private async void BtnNeurologicas(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new CMOpcoesNeurologicas());
    }


    private async void BtnOsteomusculares(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new CMOpcoesOsteomusculares());
    }
    private async void BtnRespiratorias(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new CMOpcoesRespiratorias());
    }
}