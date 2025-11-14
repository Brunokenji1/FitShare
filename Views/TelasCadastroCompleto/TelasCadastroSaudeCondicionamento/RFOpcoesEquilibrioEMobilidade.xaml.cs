using AppFitShare.Repositories;

namespace AppFitShare.Views.TelasCadastroCompleto.TelasCadastroSaudeCondicionamento;

public partial class RFOpcoesEquilibrioEMobilidade : ContentPage
{
	public RFOpcoesEquilibrioEMobilidade()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (AppState.DificuldadeParaFicarEmPe) btn_dificuldade_para_ficar_em_pe.IsVisible = false;
        if (AppState.InstabilidadeAoAndar) btn_instabilidade_ao_andar.IsVisible = false;
 
    }

    private async void BtnDificuldadeParaFicarEmPe(object sender, TappedEventArgs e)
    {
        AppState.DificuldadeParaFicarEmPe = true;
        RepositorioUsuarios.RestricoesFisicasEscolhidasTemp.Add(btn_dificuldade_para_ficar_em_pe.ClassId);
        await Navigation.PushAsync(new CadastroSaudeCondicionamento());
    }

    private async void BtnInstabilidadeAoAndar(object sender, TappedEventArgs e)
    {
        AppState.InstabilidadeAoAndar = true;
        RepositorioUsuarios.RestricoesFisicasEscolhidasTemp.Add(btn_instabilidade_ao_andar.ClassId);
        await Navigation.PushAsync(new CadastroSaudeCondicionamento());
    }
}