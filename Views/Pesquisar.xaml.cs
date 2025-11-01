namespace AppFitShare.Views;

public partial class Pesquisar : ContentPage
{
	public Pesquisar()
	{
		InitializeComponent();
	}

    private void SearchBar_SearchButtonPressed(object sender, EventArgs e)
    {
		var pesquisa = ((SearchBar)sender).Text;
    }
}