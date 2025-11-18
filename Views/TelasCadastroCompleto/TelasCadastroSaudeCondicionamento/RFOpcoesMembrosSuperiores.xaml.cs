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

        foreach (var restricao in RepositorioSaudeCondicionamento.ObterRestricoesFisicasTemp())
        {
            switch (restricao)
            {
                case "Dificuldade para levantar peso":
                    btn_dificuldade_para_levantar_peso.IsVisible = false;
                    break;
                case "Dor no cotovelo":
                    btn_dor_no_cotovelo.IsVisible = false;
                    break;
                case "Limitação no ombro":
                    btn_limitacao_no_ombro.IsVisible = false;
                    break;
                case "Tendinite no braço":
                    btn_tendinite_no_braco.IsVisible = false;
                    break;


            }
        }
    }

    private async void BtnDificuldadeParaLevantarPeso(object sender, TappedEventArgs e)
    {
        RepositorioSaudeCondicionamento.AdicionarRestricaoFisicaTemp(btn_dificuldade_para_levantar_peso.ClassId);
        await Navigation.PopAsync();
    }

    private async void BtnDorNoCotovelo(object sender, TappedEventArgs e)
    {
        RepositorioSaudeCondicionamento.AdicionarRestricaoFisicaTemp(btn_dor_no_cotovelo.ClassId);
        await Navigation.PopAsync();
    }

    private async void BtnLimitacaoNoOmbro(object sender, TappedEventArgs e)
    {
        RepositorioSaudeCondicionamento.AdicionarRestricaoFisicaTemp(btn_limitacao_no_ombro.ClassId);
        await Navigation.PopAsync();
    }

    private async void BtnTendiniteNoBraco(object sender, TappedEventArgs e)
    {
        RepositorioSaudeCondicionamento.AdicionarRestricaoFisicaTemp(btn_tendinite_no_braco.ClassId);
        await Navigation.PopAsync();
    }
    private async void BtnVoltar(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}