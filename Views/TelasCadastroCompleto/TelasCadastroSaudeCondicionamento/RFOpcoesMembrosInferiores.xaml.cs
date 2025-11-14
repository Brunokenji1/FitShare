using AppFitShare.Repositories;

namespace AppFitShare.Views.TelasCadastroCompleto.TelasCadastroSaudeCondicionamento;

public partial class RFOpcoesMembrosInferiores : ContentPage
{
	public RFOpcoesMembrosInferiores()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (AppState.DificuldadeParaCaminhar) btn_dificuldade_para_caminhar.IsVisible = false;
        if (AppState.DorNoJoelho) btn_dor_no_joelho.IsVisible = false;
        if (AppState.FraquezaNasPernas) btn_fraqueza_nas_pernas.IsVisible = false;
        if (AppState.ProblemasNoQuadril) btn_problemas_no_quadril.IsVisible = false;

    }

    private async void BtnDificuldadeParaCaminhar(object sender, TappedEventArgs e)
    {
        AppState.DificuldadeParaCaminhar = true;
        RepositorioUsuarios.RestricoesFisicasEscolhidasTemp.Add(btn_dificuldade_para_caminhar.ClassId);
        await Navigation.PushAsync(new CadastroSaudeCondicionamento());
    }

    private async void BtnProblemasNoQuadril(object sender, TappedEventArgs e)
    {
        AppState.ProblemasNoQuadril = true;
        RepositorioUsuarios.RestricoesFisicasEscolhidasTemp.Add(btn_problemas_no_quadril.ClassId);
        await Navigation.PushAsync(new CadastroSaudeCondicionamento());
    }

    private async void BtnDorNoJoelho(object sender, TappedEventArgs e)
    {
        AppState.DorNoJoelho = true;
        RepositorioUsuarios.RestricoesFisicasEscolhidasTemp.Add(btn_dor_no_joelho.ClassId);
        await Navigation.PushAsync(new CadastroSaudeCondicionamento());
    }

    private async void BtnFraquezaNasPernas(object sender, TappedEventArgs e)
    {
        AppState.FraquezaNasPernas = true;
        RepositorioUsuarios.RestricoesFisicasEscolhidasTemp.Add(btn_fraqueza_nas_pernas.ClassId);
        await Navigation.PushAsync(new CadastroSaudeCondicionamento());
    }

}