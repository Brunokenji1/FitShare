namespace AppFitShare.Views.TelasCadastroCompleto;

public partial class CadastroObjetivo2 : ContentPage
{
	public CadastroObjetivo2()
	{
		InitializeComponent();
	}
    private async void CadastroObjetivo2Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CadastroNivelDeAtividade());
    }

 
}