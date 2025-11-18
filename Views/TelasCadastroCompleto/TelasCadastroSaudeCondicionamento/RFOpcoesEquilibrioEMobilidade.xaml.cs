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
        foreach (var restricao in RepositorioSaudeCondicionamento.ObterRestricoesFisicasTemp())
        {
            switch (restricao)
            {

                case "Dificuldade para ficar em pé":
                    btn_dificuldade_para_ficar_em_pe.IsVisible = false;
                    break;

                case "Instabilidade ao andar":
                    btn_instabilidade_ao_andar.IsVisible = false;
                    break;

            }
        }

    }

    private async void BtnDificuldadeParaFicarEmPe(object sender, TappedEventArgs e)
    {
        RepositorioSaudeCondicionamento.AdicionarRestricaoFisicaTemp(btn_dificuldade_para_ficar_em_pe.ClassId);
        await Navigation.PopAsync();
    }

    private async void BtnInstabilidadeAoAndar(object sender, TappedEventArgs e)
    {
        RepositorioSaudeCondicionamento.AdicionarRestricaoFisicaTemp(btn_instabilidade_ao_andar.ClassId);
        await Navigation.PopAsync();
    }
    private async void BtnVoltar(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}