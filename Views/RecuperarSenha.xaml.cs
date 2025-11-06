using AppFitShare.Repositories;

namespace AppFitShare.Views;

public partial class RecuperarSenha : ContentPage
{
	public RecuperarSenha()
	{
		InitializeComponent();
	}

    private async void btnRecuperarSenha(object sender, EventArgs e)
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
				colocarTelefone.IsEnabled = false;
                cadastrarnovasenha.IsVisible=true;
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
}