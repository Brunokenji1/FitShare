using AppFitShare.Repositories;
using System.Threading.Tasks;

namespace AppFitShare.Views.TelasCadastroCompleto;

public partial class CadastroEstiloAlimentacao : ContentPage
{
	public CadastroEstiloAlimentacao()
	{
		InitializeComponent();
	}
    private async void BtnVoltar(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private void BtnNao(object sender, TappedEventArgs e)
    {

    }

    private void BtnVegano(object sender, TappedEventArgs e)
    {

    }

    private void BtnVegetariano(object sender, TappedEventArgs e)
    {

    }

    private void BtnOvolactovegetariano(object sender, TappedEventArgs e)
    {

    }

    private void BtnOvovegetariano(object sender, TappedEventArgs e)
    {

    }

    private void BtnLactovegetariano(object sender, TappedEventArgs e)
    {

    }

    private void BtnPescetariano(object sender, TappedEventArgs e)
    {

    }

    private async void BtnCadastrarAlimetacao(object sender, EventArgs e)
    {
        var usuarioTemp = RepositorioUsuarios.ObterUsuarioTemp();

        bool confirmacao = await DisplayAlert("Confirma o cadastro com os seguintes dados?", " ", "Sim", "Não");
        if (confirmacao)
        {
            
            usuarioTemp.CadastradoAlimentacao = true;
            RepositorioUsuarios.AtualizarUsuarioTemp(usuarioTemp);
            RepositorioUsuarios.SalvarUsuarioTemp();

            await DisplayAlert("Sucesso", "Cadastro das informações realizado com sucesso!", "Fechar");
            App.Current.MainPage = new NavigationPage(new TabbedPageMenu());
        }

    }
}