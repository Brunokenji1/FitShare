namespace AppFitShare.Views.TelasCadastroCompleto;

public partial class CadastroObjetivo : ContentPage
{
	public CadastroObjetivo()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		App.Current.MainPage = new NavigationPage(new CadastroNivelDeAtividade());
    }
}