namespace AppFitShare.Views.TelasCadastroCompleto;

public partial class CadastrarDados : ContentPage
{

	public CadastrarDados()
	{
		InitializeComponent();
	}
    private string _biotiposelecionado = null;

    private async void OnCadastroDadosClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CadastroObjetivo());
    }
    private void OnBiotipoClicked(object sender, EventArgs e)
    {
        foreach(var view in OpcoesBiotipo.Children)
        {
            if(view is Button btn)
            {
                btn.BackgroundColor = Colors.Green;
                btn.BorderColor = Colors.White;
                btn.TextColor = Colors.White;
            }
        }
        var botaoClicado = (Button)sender;
        botaoClicado.BackgroundColor = Colors.Green;
        botaoClicado.BorderColor = Colors.White;
        botaoClicado.TextColor = Colors.Black;
        _biotiposelecionado = botaoClicado.Text;
    }

    private void txt_telefone_TextChanged(object sender, TextChangedEventArgs e)
    {
        
    }

    private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
    {

    }
}