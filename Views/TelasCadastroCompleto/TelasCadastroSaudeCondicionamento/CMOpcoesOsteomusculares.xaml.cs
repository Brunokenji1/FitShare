using AppFitShare.Repositories;
using System.Threading.Tasks;

namespace AppFitShare.Views.TelasCadastroCompleto.TelasCadastroSaudeCondicionamento;

public partial class CMOpcoesOsteomusculares : ContentPage
{
	public CMOpcoesOsteomusculares()
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
                case "Artrite":
                    btn_artrite.IsVisible = false;
                    break;
                case "Artrose":
                    btn_artrose.IsVisible = false;
                    break;
                case "Osteoporose":
                    btn_osteoporose.IsVisible = false;
                    break;
                case "Tendinite":
                    btn_tendinite.IsVisible = false;
                    break;
            }
        }

    }

    private async void BtnArtrite(object sender, TappedEventArgs e)
    {
        RepositorioSaudeCondicionamento.AdicionarCondicaoMedicaTemp(btn_artrite.ClassId);
        await Navigation.PushAsync(new CadastroSaudeCondicionamento());

    }

    private async void BtnArtrose(object sender, TappedEventArgs e)
    {
        RepositorioSaudeCondicionamento.AdicionarCondicaoMedicaTemp(btn_artrose.ClassId);
        await Navigation.PushAsync(new CadastroSaudeCondicionamento());
    }

    private async void BtnOsteoporose(object sender, TappedEventArgs e)
    {
        RepositorioSaudeCondicionamento.AdicionarCondicaoMedicaTemp(btn_osteoporose.ClassId);
        await Navigation.PushAsync(new CadastroSaudeCondicionamento());
    }

    private async void BtnTendinite(object sender, TappedEventArgs e)
    {
        RepositorioSaudeCondicionamento.AdicionarCondicaoMedicaTemp(btn_tendinite.ClassId);
        await Navigation.PushAsync(new CadastroSaudeCondicionamento());
    }
}