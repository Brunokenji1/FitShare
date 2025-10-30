namespace AppFitShare.Views;

public partial class Home : ContentPage
{
	public Home()
	{
		InitializeComponent();
	}

    private void OnVerTreino(object sender, EventArgs e)
    {
        var tabbedPage = Application.Current.MainPage as TabbedPage;
        if (tabbedPage != null)
        {
            var paginaMeusTreino = tabbedPage.Children.FirstOrDefault(p => p is MeusTreinos);
            if (paginaMeusTreino != null)
            {
                tabbedPage.CurrentPage = paginaMeusTreino;
            }
        }
    }

    private void OnVerPlanoAlimentar(object sender, EventArgs e)
    {
        var tabbedPage = Application.Current.MainPage as TabbedPage;
        if (tabbedPage != null)
        {
            var paginaPlanoAlimentacao = tabbedPage.Children.FirstOrDefault(p => p is PlanoAlimentacao);
            if(paginaPlanoAlimentacao != null)
            {
                tabbedPage.CurrentPage = paginaPlanoAlimentacao;
            }
        }
    }
}