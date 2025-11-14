using AppFitShare.Repositories;

namespace AppFitShare.Views.TelasCadastroCompleto.TelasCadastroSaudeCondicionamento;

public partial class RFOpcoesMembrosSuperiores : ContentPage
{
	public RFOpcoesMembrosSuperiores()
	{
		InitializeComponent();
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (AppState.DificuldadeParaLevantarPeso) btn_dificuldade_para_levantar_peso.IsVisible = false;
        if (AppState.DorNoCotovelo) btn_dor_no_cotovelo.IsVisible = false;
        if (AppState.LimitacaoNoOmbro) btn_limitacao_no_ombro.IsVisible = false;
        if (AppState.TendiniteNoBraco) btn_tendinite_no_braco.IsVisible = false;

    }

    private async void BtnDificuldadeParaLevantarPeso(object sender, TappedEventArgs e)
    {
        AppState.DificuldadeParaLevantarPeso = true;
        RepositorioUsuarios.RestricoesFisicasEscolhidasTemp.Add(btn_dificuldade_para_levantar_peso.ClassId);
        await Navigation.PushAsync(new CadastroSaudeCondicionamento());
    }

    private async void BtnDorNoCotovelo(object sender, TappedEventArgs e)
    {
        AppState.DorNoCotovelo = true;
        RepositorioUsuarios.RestricoesFisicasEscolhidasTemp.Add(btn_dor_no_cotovelo.ClassId);
        await Navigation.PushAsync(new CadastroSaudeCondicionamento());
    }

    private async void BtnLimitacaoNoOmbro(object sender, TappedEventArgs e)
    {
        AppState.LimitacaoNoOmbro = true;
        RepositorioUsuarios.RestricoesFisicasEscolhidasTemp.Add(btn_limitacao_no_ombro.ClassId);
        await Navigation.PushAsync(new CadastroSaudeCondicionamento());
    }

    private async void BtnTendiniteNoBraco(object sender, TappedEventArgs e)
    {
        AppState.TendiniteNoBraco = true;
        RepositorioUsuarios.RestricoesFisicasEscolhidasTemp.Add(btn_tendinite_no_braco.ClassId);
        await Navigation.PushAsync(new CadastroSaudeCondicionamento());
    }
}