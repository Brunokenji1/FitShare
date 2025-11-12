using AppFitShare.Repositories;

namespace AppFitShare.Views.TelasCadastroCompleto.TelasCadastroSaudeCondicionamento;

public partial class RFOpcoesNeurologicas : ContentPage
{
	public RFOpcoesNeurologicas()
	{
		InitializeComponent();
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (AppState.DificuldadeDeCoordenacaoMotora) btn_CoordenacaoMotora.IsVisible = false;
        if (AppState.FaltaDeEquilibrio) btn_FaltaDeEquilibrio.IsVisible = false;
        if (AppState.TonturasFrequentes) btn_TonturasFrequentes.IsVisible = false;

    }
    private async void BtnDificuldadeDeCoordenacaoMotora(object sender, TappedEventArgs e)
    {
        AppState.DificuldadeDeCoordenacaoMotora = true;
        RepositorioUsuarios.RestricoesFisicasEscolhidasTemp.Add("Dificuldade de Coordenação Motora");
        await Navigation.PushAsync(new CadastroSaudeCondicionamento());
    }

    private async void BtnFaltaDeEquilibrio(object sender, TappedEventArgs e)
    {
        AppState.FaltaDeEquilibrio = true;
        RepositorioUsuarios.RestricoesFisicasEscolhidasTemp.Add("Falta de Equilíbrio");
        await Navigation.PushAsync(new CadastroSaudeCondicionamento());
    }

    private async void BtnTonturasFrequentes(object sender, TappedEventArgs e)
    {
        AppState.TonturasFrequentes = true;
        RepositorioUsuarios.RestricoesFisicasEscolhidasTemp.Add("Tonturas Frequentes");
        await Navigation.PushAsync(new CadastroSaudeCondicionamento());
    }
}