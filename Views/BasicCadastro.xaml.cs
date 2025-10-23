using AppFitShare.Models;
using AppFitShare.Repositories;

namespace AppFitShare.Views;

public partial class BasicCadastro : ContentPage
{
	public BasicCadastro()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {

            if(string.IsNullOrWhiteSpace(txt_nome.Text) ||
               string.IsNullOrWhiteSpace(txt_username.Text) ||
               string.IsNullOrWhiteSpace(txt_email.Text) ||
               string.IsNullOrWhiteSpace(txt_senha.Text) || 
               string.IsNullOrWhiteSpace(txt_confirmarSenha.Text)) 
            {
                throw new Exception("Preencha todos os campos!");
            }
            var usernameExistente = RepositorioUsuarios.ObterPorUsername(txt_username.Text);
            var emailExistente = RepositorioUsuarios.ObterPorEmail(txt_email.Text);

            
            if (!txt_email.Text.Contains("@")){
                throw new Exception("E-mail inválido!");
            }
            if (usernameExistente != null)
            {
                throw new Exception("Já existe um usuário cadastrado com este Username!");
            }
            if (emailExistente != null)
            {
                throw new Exception("Já existe um usuário cadastrado com este E-mail!");
            }
            if (txt_senha.Text.Length < 8)
            {
                throw new Exception("A senha precisa ter no mínimo 8 caracteres!");
            }
            if(txt_confirmarSenha.Text != txt_senha.Text)
            {
                throw new Exception("As senhas não coincidem!");
            }
            
            var novoUsuario = new Usuario(RepositorioUsuarios.ListarTodos().Count+1, txt_nome.Text, txt_email.Text, txt_senha.Text);
            RepositorioUsuarios.Cadastrar(novoUsuario);
            await DisplayAlert("Sucesso", "Cadastro realizado com sucesso!", "Fechar");
            App.Current.MainPage = new Login();

        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops...", ex.Message, "Fechar");
        }
    }
}