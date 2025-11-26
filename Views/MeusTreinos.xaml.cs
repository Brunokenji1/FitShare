using AppFitShare.Models;
using AppFitShare.Repositories;
using AppFitShare.Views.TelasCadastroCompleto;
using Microsoft.Maui.Controls.PlatformConfiguration;
using System.Threading.Tasks;

namespace AppFitShare.Views;

public partial class MeusTreinos : ContentPage
{
    private List<Treino> treinos = new();

    public MeusTreinos()
    {
        InitializeComponent();
        var usuario = RepositorioUsuarios.ObterUsuarioLogado();
        if (usuario.CadastroSaude)
        {
            cadastro_saude.IsVisible = false;
            dados.IsVisible = true;
        }
        _ = CarregarTreinosAsync();
    }
    private async Task CarregarTreinosAsync()
    { }
    private async void BotaoIniciarTreinoClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ExerciciosTreinos());
    }

    private async void CriarNovoTreino(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SelecionarGrupoMuscular());
    }

    private async void BtnCadastroSaude(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CadastrarDados());
    } 
}

