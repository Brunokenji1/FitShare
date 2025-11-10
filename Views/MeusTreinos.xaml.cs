using AppFitShare.Models;
using AppFitShare.Services;

namespace AppFitShare.Views;

public partial class MeusTreinos : ContentPage
{
    private readonly JsonStorageService storageService = new();
    private List<Treino> treinos = new();

    public MeusTreinos()
    {
        InitializeComponent();
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
                    exercicios = new List<Exercicio>
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

    private void AddTreinoPersonalizado(object sender, EventArgs e)
    {
    }

    private void BotaoIniciarTreinoClicked2(object sender, EventArgs e)
    {
    }
}
