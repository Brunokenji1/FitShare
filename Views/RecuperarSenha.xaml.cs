namespace AppFitShare.Views;

public partial class RecuperarSenha : ContentPage
{
	public RecuperarSenha()
	{
		InitializeComponent();
	}

    private async void OnRecuperarSenha(object sender, EventArgs e)
    {
		try
		{
			var email = txt_email.Text?.Trim();
			if (string.IsNullOrWhiteSpace(email))
			{
				throw new Exception("Preencha o campo de e-mail!");
            }

        }
		catch (Exception ex)
		{
			await DisplayAlert("Ops...", ex.Message, "Fechar");
        }
    }
}