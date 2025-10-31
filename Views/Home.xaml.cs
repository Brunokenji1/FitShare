using AppFitShare.Repositories;

namespace AppFitShare.Views;

public partial class Home : ContentPage
{
	public Home()
	{
		InitializeComponent();
        var usuario_logado = RepositorioUsuarios.usuario_logado?.Nome;
        if (usuario_logado != null)
        {
            lbl_boasvindas.Text = $"Olá, {usuario_logado}!";
        }
    }
    private void OnVerTreino(object sender, EventArgs e)
    {
        if (Application.Current.MainPage is NavigationPage navigationPage)
        {
            if (navigationPage.CurrentPage is TabbedPage tabbedPage)
            {
                var paginaMeusTreino = tabbedPage.Children.FirstOrDefault(p => p is MeusTreinos);
                if (paginaMeusTreino != null)
                {
                    tabbedPage.CurrentPage = paginaMeusTreino;
                }
            }
        }
    }
    private void OnVerPlanoAlimentar(object sender, EventArgs e)
    {
        if (Application.Current.MainPage is NavigationPage navigationPage)
        {
            if (navigationPage.CurrentPage is TabbedPage tabbedPage)
            {
                var paginaPlanoAlimentacao = tabbedPage.Children.FirstOrDefault(p => p is PlanoAlimentacao);
                if (paginaPlanoAlimentacao != null)
                {
                    tabbedPage.CurrentPage = paginaPlanoAlimentacao;
                }
            }
        }
    }

}