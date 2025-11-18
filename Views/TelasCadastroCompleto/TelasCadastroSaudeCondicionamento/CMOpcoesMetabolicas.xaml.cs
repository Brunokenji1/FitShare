using AppFitShare.Repositories;
using System.Threading.Tasks;

namespace AppFitShare.Views.TelasCadastroCompleto.TelasCadastroSaudeCondicionamento;

public partial class CMOpcoesMetabolicas : ContentPage
{
	public CMOpcoesMetabolicas()
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
                case "Colesterol alto":
                    btn_colesterol_alto.IsVisible = false;
                    break;
                case "Obesidade":
                    btn_obesidade.IsVisible = false;
                    break;
            }
        }

    }

    private async void BtnColesterolAlto(object sender, TappedEventArgs e)
    {
        RepositorioSaudeCondicionamento.AdicionarCondicaoMedicaTemp(btn_colesterol_alto.ClassId);
        await Navigation.PopAsync();

    }

    private async void BtnObesidade(object sender, TappedEventArgs e)
    {
        RepositorioSaudeCondicionamento.AdicionarCondicaoMedicaTemp(btn_obesidade.ClassId);
        await Navigation.PopAsync();

    }
    private async void BtnVoltar(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}