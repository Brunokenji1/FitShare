using AppFitShare.Models;
using AppFitShare.Repositories;
using System.Threading.Tasks;

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

    private async void btnSelecionarFoto(object sender, EventArgs e)
    {
		try
		{
			var foto = await MediaPicker.PickPhotoAsync();
			if (foto != null)
			{
				using var stream = await foto.OpenReadAsync();
				imgPerfil.Source = ImageSource.FromStream(()=>stream);
            }
        }
		catch (Exception ex)
		{
			await DisplayAlert("Erro", ex.Message, "OK");
		}
    }
}