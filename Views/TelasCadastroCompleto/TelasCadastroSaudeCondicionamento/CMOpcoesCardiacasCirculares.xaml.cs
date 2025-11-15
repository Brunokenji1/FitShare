using AppFitShare.Repositories;

namespace AppFitShare.Views.TelasCadastroCompleto.TelasCadastroSaudeCondicionamento;

public partial class CMOpcoesCardiacasCirculares : ContentPage
{
	public CMOpcoesCardiacasCirculares()
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
                case "Arritmia":
                    btn_arritmia.IsVisible = false;
                    break;
                case "Hipertensão":
                    btn_hipertensao.IsVisible = false;
                    break;
                case "Hipotensão":
                    btn_hipotensao.IsVisible = false;
                    break;
                case "Insuficiência cardíaca":
                    btn_insuficiencia_cardiaca.IsVisible = false;
                    break;
            }
        }

    }

    private async void BtnHipertensao(object sender, TappedEventArgs e)
    {
        RepositorioSaudeCondicionamento.AdicionarCondicaoMedicaTemp(btn_hipertensao.ClassId);
        await Navigation.PushAsync(new CadastroSaudeCondicionamento());

    }

    private async void BtnArritmia(object sender, TappedEventArgs e)
    {
        RepositorioSaudeCondicionamento.AdicionarCondicaoMedicaTemp(btn_arritmia.ClassId);
        await Navigation.PushAsync(new CadastroSaudeCondicionamento());

    }

    private async void BtnHipotensao(object sender, TappedEventArgs e)
    {
        RepositorioSaudeCondicionamento.AdicionarCondicaoMedicaTemp(btn_hipotensao.ClassId);
        await Navigation.PushAsync(new CadastroSaudeCondicionamento());

    }

    private async void BtnInsuficienciaCardiaca(object sender, TappedEventArgs e)
    {
        RepositorioSaudeCondicionamento.AdicionarCondicaoMedicaTemp(btn_insuficiencia_cardiaca.ClassId);
        await Navigation.PushAsync(new CadastroSaudeCondicionamento());

    }
}