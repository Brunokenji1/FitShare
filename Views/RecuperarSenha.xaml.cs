using Android.Content.Res;
using AppFitShare.Models;
using AppFitShare.Repositories;
using System.Threading.Tasks;

namespace AppFitShare.Views;

public partial class RecuperarSenha : ContentPage
{
    public RecuperarSenha()
    {
        InitializeComponent();
    }

    public Usuario usuario_temp{ get; set; }

    private async void BtnRecuperarSenha(object sender, EventArgs e)
    {
		try
		{
            var usuariosCadastrados = RepositorioUsuarios.ListarTodos();
            var telefone = txt_telefone.Text?.Trim();
			if (string.IsNullOrWhiteSpace(telefone))
			{
				throw new Exception("Preencha o campo de Telefone!");
            }
			var usuario = usuariosCadastrados.FirstOrDefault(u => u.Telefone == telefone);
			if(usuario != null)
			{
                usuario_temp = usuario;
                coloca_telefone.IsEnabled = false;
                botao_telefone.IsVisible = false;
                cadastrar_nova_senha.IsVisible=true;

            }
			else
			{
				throw new Exception("Digite um telefone cadastrado!");
			}
        }
		catch (Exception ex)
		{
			await DisplayAlert("Ops...", ex.Message, "Fechar");
        }
    }

    private async void BtnCadastrarNovaSenha(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(txt_novasenha.Text) ||
                string.IsNullOrWhiteSpace(txt_novasenhaloginconfirmar.Text))
            {
                throw new Exception("Preencha todos os campos!");
            }

            if (txt_novasenha.Text.Length < 8)
            {
                throw new Exception("A senha precisa ter no mínimo 8 caracteres!");
            }
            if (txt_novasenhaloginconfirmar.Text != txt_novasenha.Text)
            {
                throw new Exception("As senhas não coincidem!");
            }

            usuario_temp.Senha = txt_novasenha.Text;
            RepositorioUsuarios.TrocarSenha(usuario_temp);
            App.Current.MainPage = new NavigationPage(new Login());
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops...", ex.Message, "Fechar");
        }
    }

    private void IbtnNovaSenhaVisibilidade(object sender, EventArgs e)
    {
        txt_novasenha.IsPassword = !txt_novasenha.IsPassword;
        var imagebButton = (ImageButton)sender;
        if (txt_novasenha.IsPassword)
        {
            imagebButton.Source = "eye_closed.png";
        }
        else
        {
            imagebButton.Source = "eye_open.png";
        }
    }
    private void IbtnNovaSenhaVisibilidadeConfirmar(object sender, EventArgs e)
    {
        txt_novasenhaloginconfirmar.IsPassword = !txt_novasenhaloginconfirmar.IsPassword;
        var imagebButton = (ImageButton)sender;
        if (txt_novasenhaloginconfirmar.IsPassword)
        {
            imagebButton.Source = "eye_closed.png";
        }
        else
        {
            imagebButton.Source = "eye_open.png";
        }
    }

    private async void BtnVoltar(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}