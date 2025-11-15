using AppFitShare.Repositories;
using System.Threading.Tasks;

namespace AppFitShare.Views.TelasCadastroCompleto.TelasCadastroSaudeCondicionamento;

public partial class CMOpcoesNeurologicas : ContentPage
{
	public CMOpcoesNeurologicas()
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
                case "Parkinson":
                    btn_parkinson.IsVisible = false;
                    break;
                case "Vertigem":
                    btn_vertigem.IsVisible = false;
                    break;

            }
        }

    }
    private async void BtnParkinson(object sender, TappedEventArgs e)
    {
        RepositorioSaudeCondicionamento.AdicionarCondicaoMedicaTemp(btn_parkinson.ClassId);
        await Navigation.PushAsync(new CadastroSaudeCondicionamento());
    }

    private async void BtnVertigem(object sender, TappedEventArgs e)
    {
        RepositorioSaudeCondicionamento.AdicionarCondicaoMedicaTemp(btn_vertigem.ClassId);
        await Navigation.PushAsync(new CadastroSaudeCondicionamento());
    }
}