using AppFitShare.Models;
using AppFitShare.Repositories;

namespace AppFitShare.Views.TelasCadastroCompleto;

public partial class CadastrarDados : ContentPage
{

	public CadastrarDados()
	{
		InitializeComponent();
	}
	private async void OnContinuar(object sender, EventArgs e)
	{
		//var dados = new UsuarioCompleto()
		//{
		//	Idade = int.Parse(txt_idade.Text),
		//	Peso = double.Parse(txt_peso.Text),
		//	Altura = double.Parse(txt_altura.Text)
		//};
		//CadastroTemp.AtualizarDados(dados);

        await Navigation.PushAsync(new CadastroObjetivo());
    }


}