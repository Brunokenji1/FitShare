using AppFitShare.Repositories;

namespace AppFitShare.Views.TelasCadastroCompleto.TelasCadastroSaudeCondicionamento;

public partial class RFOpcoesCardiorrespiratorias : ContentPage
{
	public RFOpcoesCardiorrespiratorias()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (AppState.ProblemaFaltaDeAr) btn_FaltaDeAr.IsVisible = false;
        if (AppState.PressaoAlta) btn_PressaoAlta.IsVisible = false;
        if (AppState.ProblemaCardiaco) btn_ProblemasCardiacos.IsVisible = false;
        
    }

    private async void BtnPressaoAlta(object sender, TappedEventArgs e)
    {
        AppState.PressaoAlta = true;
        RepositorioUsuarios.RestricoesFisicasEscolhidasTemp.Add("Pressão Alta");
        await Navigation.PushAsync(new CadastroSaudeCondicionamento());
    }

    private async void BtnProblemaCardiaco(object sender, TappedEventArgs e)
    {
        AppState.ProblemaCardiaco = true;
        RepositorioUsuarios.RestricoesFisicasEscolhidasTemp.Add("Problema Cardíaco");
        await Navigation.PushAsync(new CadastroSaudeCondicionamento());
    }

    private async void BtnFaltaDeAr(object sender, TappedEventArgs e)
    {
        AppState.ProblemaFaltaDeAr = true;
        RepositorioUsuarios.RestricoesFisicasEscolhidasTemp.Add("Problema de Falta de Ar");
        await Navigation.PushAsync(new CadastroSaudeCondicionamento());
    }

}