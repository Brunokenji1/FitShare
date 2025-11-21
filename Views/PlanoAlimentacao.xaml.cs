using AppFitShare.Repositories;
using AppFitShare.Views.TelasCadastroCompleto;
using System.Threading.Tasks;

namespace AppFitShare.Views;

public partial class PlanoAlimentacao : ContentPage
{
	public PlanoAlimentacao()
	{
		InitializeComponent();
        var usuario = RepositorioUsuarios.ObterUsuarioLogado();
        if (usuario.CadastradoAlimentacao)
        {
            cadastro_alimentacao.IsVisible= false;
            alimentacao.IsVisible = true;
        }
	}

    private async void BotaoPlanoAlimentar(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new MinhasDietas());
    }

    private async void BtnCadastrarAlimentacao(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CadastroAlergiaAlimentar());
    }
}