
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
        await Navigation.PushAsync(new RFOpcoesOrtopedicas());
    }
    private async void BtnMuscularesArticulares(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new RFOpcoesMuscularesEArticulares());
    }
    private async void BtnNeurologico(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new RFOpcoesNeurologicas());
    }

    private async void BtnCardiorrespiratorio(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new RFOpcoesCardiorrespiratorias());
    }

    private async void BtnOutrasRestricoes(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new CadastroSaudeCondicionamento());
    }
   
    public async void BtnCadastroCondicoesMedicas(object sender, EventArgs e)
    {

        await Navigation.PushAsync(new CadastroSaudeCondicionamento());
    }
}