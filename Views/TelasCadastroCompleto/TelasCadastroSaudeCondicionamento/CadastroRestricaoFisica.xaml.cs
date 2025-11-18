
using AppFitShare.Views.TelasCadastroCompleto.TelasCadastroSaudeCondicionamento;

namespace AppFitShare.Views.TelasCadastroCompleto;

public partial class CadastroRestricaoFisica : ContentPage
{
	public CadastroRestricaoFisica()
	{
		InitializeComponent();
	}
    private async void BtnOrtopedia(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new RFOpcoesMembrosInferiores());
    }
    private async void BtnMuscularesArticulares(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new RFOpcoesMembrosSuperiores());
    }
    private async void BtnNeurologico(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new RFOpcoesColunaPostura());
    }

    private async void BtnCardiorrespiratorio(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new RFOpcoesEquilibrioEMobilidade());
    }

    private async void BtnOutrasRestricoes(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new CadastroSaudeCondicionamento());
    }
    private async void BtnVoltar(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}