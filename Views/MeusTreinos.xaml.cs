using AppFitShare.Models;
using AppFitShare.Repositories;
using AppFitShare.Services;
using AppFitShare.Views.TelasCadastroCompleto;
using Microsoft.Maui.Controls.PlatformConfiguration;
using System.Threading.Tasks;

namespace AppFitShare.Views;

public partial class MeusTreinos : ContentPage
{
    private readonly JsonStorageService storageService = new();
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
    {
        treinos = await storageService.LoadAsync<Treino>("treinos.json");
        if (treinos.Count == 0)
        {
            treinos = new List<Treino>
            {
                new Treino
                {
                    Id = 1, Nome = "Treino A",
                    ListaDeExercicios = new List<Exercicio>
                    {
                        new Exercicio{ Nome="Supino reto", Series=4, Repeticoes=10},
                        new Exercicio{ Nome="Crucifixo", Series=3, Repeticoes=12}
                    }
                }
            };
            await storageService.SaveAsync("treinos.json", treinos);
        }
    }
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
