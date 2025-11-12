using AppFitShare.Repositories;
using System.Threading.Tasks;

namespace AppFitShare.Views.TelasCadastroCompleto.TelasCadastroSaudeCondicionamento;

public partial class RFOpcoesOrtopedicas : ContentPage
{
	public RFOpcoesOrtopedicas()
	{
		InitializeComponent();
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (AppState.ArtroseNoQuadrilOuOmbro) btn_ArtroseNoQuadrilOuOmbro.IsVisible = false;
        if (AppState.CirurgiaRecente) btn_CirurgiaRecente.IsVisible = false;
        if (AppState.DorLombar) btn_DorLombar.IsVisible = false;

    }
    private async void BtnArtroseNoQuadrilOuOmbro(object sender, TappedEventArgs e)
    {
        AppState.ArtroseNoQuadrilOuOmbro = true;
        RepositorioUsuarios.RestricoesFisicasEscolhidasTemp.Add("Artrose no Quadril ou Ombro");
        await Navigation.PushAsync(new CadastroSaudeCondicionamento());
    }

    private async void BtnCirurgiaRecente(object sender, TappedEventArgs e)
    {
        AppState.CirurgiaRecente = true;
        RepositorioUsuarios.RestricoesFisicasEscolhidasTemp.Add("Cirurgia Recente");
        await Navigation.PushAsync(new CadastroSaudeCondicionamento());
    }

    private async void BtnDorLombar(object sender, TappedEventArgs e)
    {
        AppState.DorLombar = true;
        RepositorioUsuarios.RestricoesFisicasEscolhidasTemp.Add("Dor Lombar");
        await Navigation.PushAsync(new CadastroSaudeCondicionamento());
    }
}