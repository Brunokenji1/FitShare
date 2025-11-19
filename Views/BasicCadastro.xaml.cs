using AppFitShare.Models;
using AppFitShare.Repositories;

namespace AppFitShare.Views;

public partial class BasicCadastro : ContentPage
{
	public BasicCadastro()
	{
		InitializeComponent();
	}
    private void txtUsername_TxtChanged(object sender, TextChangedEventArgs e)
    {
        
        string username = txt_username.Text?.Trim() ?? "";
        if (string.IsNullOrWhiteSpace(username))
        {
            lblAviso.Text = "";
            return;
        }
        if(!System.Text.RegularExpressions.Regex.IsMatch(username, "^[a-z0-9]+$"))
        {
            lblAviso.IsVisible = true;
            lblAviso.TextColor = Colors.Red;
            if (username.Any(char.IsUpper)) lblAviso.Text = "Use apenas letras minúsculas. ";
            else lblAviso.Text = "Use só letras e números, sem acento ou símbolos.";
        }
        else
        {
            var usernameExistente = RepositorioUsuarios.ObterPorUsername(txt_username.Text);
            if (usernameExistente != null)
            {
                lblAviso.IsVisible = true;
                lblAviso.TextColor = Colors.Red;
                lblAviso.Text = "Nome de usuario existente";
            }

            else
            {
                lblAviso.TextColor = Colors.Green;
                lblAviso.Text = "Nome de usuário válido";
                lblAviso.IsVisible = false;
            }
        }
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {

            if(string.IsNullOrWhiteSpace(txt_nome.Text) ||
               string.IsNullOrWhiteSpace(txt_username.Text) ||
               string.IsNullOrWhiteSpace(txt_telefone.Text) ||
               string.IsNullOrWhiteSpace(txt_senha.Text) || 
               string.IsNullOrWhiteSpace(txt_confirmarSenha.Text)) 
            {
                throw new Exception("Preencha todos os campos!");
            }

            var usernameExistente = RepositorioUsuarios.ObterPorUsername(txt_username.Text);
            var telefoneExistente = RepositorioUsuarios.ObterPorTelefone(txt_telefone.Text);

            if(lblAviso.Text != "Nome de usuário válido")
            {
                throw new Exception("Digite um username válido!");
            }
            if(txt_telefone.Text.Length < 11)
            {
                throw new Exception("Digite um telefone valido");
            }
            if (usernameExistente != null)
            {
                throw new Exception("Já existe um usuário cadastrado com este Username!");
            }
            if (telefoneExistente != null)
            {
                throw new Exception("Já existe um usuário cadastrado com este Telefone!");
            }
            if (txt_senha.Text.Length < 8)
            {
                throw new Exception("A senha precisa ter no mínimo 8 caracteres!");
            }
            if(txt_confirmarSenha.Text != txt_senha.Text)
            {
                throw new Exception("As senhas não coincidem!");
            }
            
            
            bool confirmacao = await DisplayAlert("Confirmação", "Criar Conta com esses dados?", "Sim", "Não");
            if (confirmacao)
            {
                var novoUsuario = new Usuario(RepositorioUsuarios.ListarTodos().Count + 1, txt_nome.Text, txt_username.Text, txt_telefone.Text, txt_senha.Text, DateTime.Now);
                RepositorioUsuarios.Cadastrar(novoUsuario);
                await DisplayAlert("Sucesso", "Cadastro realizado com sucesso!", "Fechar");
                
                App.Current.MainPage = new NavigationPage(new Login());
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops...", ex.Message, "Fechar");
        }
    }
    private void IbtnSenhaVisibilidade(object sender, EventArgs e)
    {
        txt_senha.IsPassword = !txt_senha.IsPassword;
        var imagebButton = (ImageButton)sender;
        if (txt_senha.IsPassword)
        {
            imagebButton.Source = "eye_closed.png";
        }
        else
        {
            imagebButton.Source = "eye_open.png";
        }
    }
    private void IbtnConfirmarSenhaVisibilidade(object sender, EventArgs e)
    {
        txt_confirmarSenha.IsPassword = !txt_confirmarSenha.IsPassword;
        var imagebButton = (ImageButton)sender;
        if (txt_confirmarSenha.IsPassword)
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