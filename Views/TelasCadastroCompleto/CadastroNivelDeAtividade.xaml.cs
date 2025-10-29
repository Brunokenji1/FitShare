namespace AppFitShare.Views.TelasCadastroCompleto;

public partial class CadastroNivelDeAtividade : ContentPage
{
	public CadastroNivelDeAtividade()
	{
		InitializeComponent();
	}

    private void CadastroNivelAtividadeClicked(object sender, EventArgs e)
    {
		App.Current.MainPage = new TabbedPageMenu();
    }
}