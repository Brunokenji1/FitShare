using AppFitShare.Models;

namespace AppFitShare.Views;

public partial class MeusTreinos : ContentPage
{
    public MeusTreinos()
    {
        InitializeComponent();
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
