namespace AppFitShare.Views.TelasCadastroCompleto;

public partial class CadastroObjetivo : ContentPage
{
    public CadastroObjetivo()
    {
        InitializeComponent();
    }
    private bool isSelecionado = false;
    private async void CadastroObjetivo1Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CadastroNivelDeAtividade());
    }

    private void OnObjetivo1(object sender, TappedEventArgs e)
    {
        var border = (Border)sender;

        isSelecionado = !isSelecionado;

        if (isSelecionado)
        {
            border.BackgroundColor = Color.FromArgb("#01b853");
            border.Stroke = Colors.Transparent;

            lblTitulo1.TextColor = Colors.Black;
            lblDescricao1.TextColor = Colors.Black;
        }
        else
        {
            border.BackgroundColor = Color.FromArgb("#0d1117");
            border.Stroke = Color.FromArgb("#01c853");

            lblTitulo1.TextColor = Colors.White;
            lblDescricao1.TextColor = Color.FromArgb("#a0a0a0");
        }
    }
    private async void OnContinuar(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CadastroObjetivo2());
    }
}