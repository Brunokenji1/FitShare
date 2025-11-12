using AppFitShare.Repositories;

namespace AppFitShare.Views.TelasCadastroCompleto.TelasCadastroSaudeCondicionamento;

public partial class RFOpcoesMuscularesEArticulares : ContentPage
{
	public RFOpcoesMuscularesEArticulares()
	{
		InitializeComponent();
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (AppState.DoresCronicasNasCostas) btn_DoresCronicasNasCostas.IsVisible = false;
        if (AppState.FraquezaMuscularLocalizada) btn_FraquezaMuscularLocalizada.IsVisible = false;
        if (AppState.LesaoManguitoRotador) btnLesaoManguitoRotador.IsVisible = false;

    }
    private async void BtnFraquezaMuscularLocalizada(object sender, TappedEventArgs e)
    {
        AppState.FraquezaMuscularLocalizada = true;
        RepositorioUsuarios.RestricoesFisicasEscolhidasTemp.Add("Fraqueza Muscular Localizada");
        await Navigation.PushAsync(new CadastroSaudeCondicionamento());
    }

    private async void BtnDoresCronicasNasCostas(object sender, TappedEventArgs e)
    {
        AppState.DoresCronicasNasCostas = true;
        RepositorioUsuarios.RestricoesFisicasEscolhidasTemp.Add("Dores Crônicas nas Costas");
        await Navigation.PushAsync(new CadastroSaudeCondicionamento());
    }

    private async void BtnLesaoManguitoRotador(object sender, TappedEventArgs e)
    {
        AppState.LesaoManguitoRotador = true;
        RepositorioUsuarios.RestricoesFisicasEscolhidasTemp.Add("Lesão no Manguito Rotador");
        await Navigation.PushAsync(new CadastroSaudeCondicionamento());
    }
}