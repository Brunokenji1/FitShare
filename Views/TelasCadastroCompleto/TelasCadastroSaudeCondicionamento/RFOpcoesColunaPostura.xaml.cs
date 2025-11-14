using AppFitShare.Repositories;

namespace AppFitShare.Views.TelasCadastroCompleto.TelasCadastroSaudeCondicionamento;

public partial class RFOpcoesColunaPostura : ContentPage
{
	public RFOpcoesColunaPostura()
	{
		InitializeComponent();
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (AppState.DorLombar) btn_dor_lombar.IsVisible = false;
        if (AppState.Escoliose) btn_escoliose.IsVisible = false;
        if (AppState.HerniaDeDisco) btn_hernia_de_disco.IsVisible = false;
        if (AppState.PosturaCurvada) btn_postura_curvada.IsVisible = false;

    }
    private async void BtnDorLombar(object sender, TappedEventArgs e)
    {
        AppState.DorLombar = true;
        RepositorioUsuarios.RestricoesFisicasEscolhidasTemp.Add("Dor Lombar");
        await Navigation.PushAsync(new CadastroSaudeCondicionamento());
    }

    private async void BtnEscoliose(object sender, TappedEventArgs e)
    {
        AppState.Escoliose = true;
        RepositorioUsuarios.RestricoesFisicasEscolhidasTemp.Add(btn_escoliose.ClassId);
        await Navigation.PushAsync(new CadastroSaudeCondicionamento());
    }

    private async void BtnHerniaDeDisco(object sender, TappedEventArgs e)
    {
        AppState.HerniaDeDisco = true;
        RepositorioUsuarios.RestricoesFisicasEscolhidasTemp.Add(btn_hernia_de_disco.ClassId);
        await Navigation.PushAsync(new CadastroSaudeCondicionamento());
    }

    private async void BtnPosturaCurvada(object sender, TappedEventArgs e)
    {
        AppState.PosturaCurvada = true;
        RepositorioUsuarios.RestricoesFisicasEscolhidasTemp.Add(btn_postura_curvada.ClassId);
        await Navigation.PushAsync(new CadastroSaudeCondicionamento());
    }
}