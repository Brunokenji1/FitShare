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
		var dados = new UsuarioCompleto()
		{
			Idade = int.Parse(txt_idade.Text),
			Peso = double.Parse(txt_peso.Text),
			Altura = double.Parse(txt_altura.Text),
			Telefone = txt_telefone.Text
		};
		CadastroTemp.AtualizarDados(dados);

        await Navigation.PushAsync(new CadastroObjetivo());
    }

    private void OnTelefoneTextChanged(object sender, TextChangedEventArgs e)
    {
		try { 
			var entry = (Entry)sender;
			if(string.IsNullOrEmpty(e.NewTextValue))
			{
				return;
            }
            string texto = new string(e.NewTextValue.Where(char.IsDigit).ToArray());
			if(texto.Length > 11)
			{
				texto = texto.Substring(0, 11);
			}


			string formatado = texto;
            if (texto.Length <= 2)
            {
                formatado = $"({texto}";
            }
            else if (texto.Length <= 6)
            {
                formatado = $"({texto.Substring(0, 2)}) {texto.Substring(2)}";
            }
            else if (texto.Length <= 10)
            {
                formatado = $"({texto.Substring(0, 2)}) {texto.Substring(2, 4)}-{texto.Substring(6)}";
            }
            else
            {
                formatado = $"({texto.Substring(0, 2)}) {texto.Substring(2, 5)}-{texto.Substring(7)}";
            }

            if (entry.Text != formatado)
            {
                entry.Text = formatado;
                entry.CursorPosition = formatado.Length;
            }
        

        }
		catch 
		{
            System.Diagnostics.Debug.WriteLine("Erro ao formatar telefone.");
        }
    }
}