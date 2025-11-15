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

        foreach (var restricao in RepositorioSaudeCondicionamento.ObterRestricoesFisicasTemp())
        {
            switch (restricao)
            {
                case "Dor Lombar":
                    btn_dor_lombar.IsVisible = false;
                    break;
                case "Escoliose":
                    btn_escoliose.IsVisible = false;
                    break;
                case "Hérnia de disco":
                    btn_hernia_de_disco.IsVisible = false;
                    break;
                case "Postura curvada":
                    btn_postura_curvada.IsVisible = false;
                    break;
            }
        }

    }
    private async void BtnDorLombar(object sender, TappedEventArgs e)
    {
        RepositorioSaudeCondicionamento.AdicionarRestricaoFisicaTemp(btn_dor_lombar.ClassId);
        await Navigation.PushAsync(new CadastroSaudeCondicionamento());

    }

    private async void BtnEscoliose(object sender, TappedEventArgs e)
    {
        RepositorioSaudeCondicionamento.AdicionarRestricaoFisicaTemp(btn_escoliose.ClassId);
        await Navigation.PushAsync(new CadastroSaudeCondicionamento());
    }

    private async void BtnHerniaDeDisco(object sender, TappedEventArgs e)
    {
        RepositorioSaudeCondicionamento.AdicionarRestricaoFisicaTemp(btn_hernia_de_disco.ClassId);
        await Navigation.PushAsync(new CadastroSaudeCondicionamento());
    }

    private async void BtnPosturaCurvada(object sender, TappedEventArgs e)
    {
        RepositorioSaudeCondicionamento.AdicionarRestricaoFisicaTemp(btn_postura_curvada.ClassId);
        await Navigation.PushAsync(new CadastroSaudeCondicionamento());
    }
}