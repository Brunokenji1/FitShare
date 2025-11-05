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

            lblTitulo.TextColor = Colors.Black;
            lblDescricao.TextColor = Colors.Black;
        }
        else
        {
            border.BackgroundColor = Color.FromArgb("#0d1117");
            border.Stroke = Color.FromArgb("#01c853");

            lblTitulo.TextColor = Colors.White;
            lblDescricao.TextColor = Color.FromArgb("#a0a0a0");
        }
    }
    private async void OnContinuar(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CadastroObjetivo2());
    }
}