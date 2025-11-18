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

        foreach (var restricao in RepositorioSaudeCondicionamento.ObterRestricoesFisicasTemp())
        {
            switch (restricao)
            {
                case "Dificuldade para caminhar":
                    btn_dificuldade_para_caminhar.IsVisible = false;
                    break;
                case "Dor no joelho":
                    btn_dor_no_joelho.IsVisible = false;
                    break;
                case "Fraqueza nas pernas":
                    btn_fraqueza_nas_pernas.IsVisible = false;
                    break;
                case "Problemas no quadril":
                    btn_problemas_no_quadril.IsVisible = false  ;
                    break;

            }
        }
    }

    private async void BtnDificuldadeParaCaminhar(object sender, TappedEventArgs e)
    {
        RepositorioSaudeCondicionamento.AdicionarRestricaoFisicaTemp(btn_dificuldade_para_caminhar.ClassId);
        await Navigation.PopAsync();
    }

    private async void BtnProblemasNoQuadril(object sender, TappedEventArgs e)
    {
        RepositorioSaudeCondicionamento.AdicionarRestricaoFisicaTemp(btn_problemas_no_quadril.ClassId);
        await Navigation.PopAsync();
    }

    private async void BtnDorNoJoelho(object sender, TappedEventArgs e)
    {
        RepositorioSaudeCondicionamento.AdicionarRestricaoFisicaTemp(btn_dor_no_joelho.ClassId);
        await Navigation.PopAsync();
    }

    private async void BtnFraquezaNasPernas(object sender, TappedEventArgs e)
    {
        RepositorioSaudeCondicionamento.AdicionarRestricaoFisicaTemp(btn_fraqueza_nas_pernas.ClassId);
        await Navigation.PopAsync();
    }
    private async void BtnVoltar(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

}