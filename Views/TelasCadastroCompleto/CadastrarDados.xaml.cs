using AppFitShare.Models;
using AppFitShare.Repositories;
using System.ComponentModel;
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
		try
		{
            if (string.IsNullOrWhiteSpace(txt_idade.Text) ||
               string.IsNullOrWhiteSpace(txt_peso.Text) ||
               string.IsNullOrWhiteSpace(txt_altura.Text))
            {
                throw new Exception("Preencha todos os campos!");
            }
            await Navigation.PushAsync(new CadastroObjetivo());
		}
		catch (Exception ex)
		{
            await DisplayAlert("Ops...", ex.Message, "Fechar");
        }

    }

    private async void btnSelecionarFoto(object sender, EventArgs e)
    {
		try
		{
			var foto = await MediaPicker.PickPhotoAsync();

			if (foto == null) return;
			
			var stream = await foto.OpenReadAsync();
			var imgSource = ImageSource.FromStream(() => stream);

            imgPerfil.Source = imgSource;
			imgPerfil.IsVisible = true;
            var usuario = RepositorioUsuarios.ObterUsuarioLogado();
			usuario.FotoPerfil = imgSource;
        }
		catch (Exception ex)
		{
			await DisplayAlert("Erro", ex.Message, "OK");
		}
    }

	private void Picker_SelectedIndexChanged(object sender, EventArgs e)
	{
		
		txt_altura.IsEnabled = true;
		var medida = ((Picker)sender);
		String unidadeSelecionada = (String)medida.SelectedItem;
		txt_altura.Text = null;
	
	}
		
}