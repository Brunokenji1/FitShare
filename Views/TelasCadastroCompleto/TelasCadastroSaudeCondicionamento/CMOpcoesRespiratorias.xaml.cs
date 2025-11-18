using AppFitShare.Repositories;

namespace AppFitShare.Views.TelasCadastroCompleto.TelasCadastroSaudeCondicionamento;

public partial class CMOpcoesRespiratorias : ContentPage
{
	public CMOpcoesRespiratorias()
	{
		InitializeComponent();
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();

        foreach (var restricao in RepositorioSaudeCondicionamento.ObterCondicoesMedicasTemp())
        {
            switch (restricao)
            {
                case "Asma":
                    btn_asma.IsVisible = false;
                    break;
                case "Bronquite crônica":
                    btn_bronquite_cronica.IsVisible = false;
                    break;
                case "DPOC":
                    btn_DPOC.IsVisible = false;
                    break;
            }
        }

    }

    private async void BtnAsma(object sender, TappedEventArgs e)
    {
        RepositorioSaudeCondicionamento.AdicionarCondicaoMedicaTemp(btn_asma.ClassId);
        await Navigation.PopAsync();
    }

    private async void BtnBronquiteCronica(object sender, TappedEventArgs e)
    {
        RepositorioSaudeCondicionamento.AdicionarCondicaoMedicaTemp(btn_bronquite_cronica.ClassId);
        await Navigation.PopAsync();

    }

    private async void BtnDPOC(object sender, TappedEventArgs e)
    {
        RepositorioSaudeCondicionamento.AdicionarCondicaoMedicaTemp(btn_DPOC.ClassId);
        await Navigation.PopAsync();

    }
    private async void BtnVoltar(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}