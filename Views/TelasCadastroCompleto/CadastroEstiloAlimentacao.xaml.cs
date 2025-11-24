using AppFitShare.Repositories;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace AppFitShare.Views.TelasCadastroCompleto;

public partial class CadastroEstiloAlimentacao : ContentPage
{
    private List<string> _estiloAlimentar = new List<string>();

    private readonly Color _corSelecionada = Color.FromArgb("#01b853");
    private readonly Color _corTransparente = Colors.Transparent;

    public CadastroEstiloAlimentacao()
	{
		InitializeComponent();
	}
    private async void BtnVoltar(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private void GerenciarSelecao(string estiloAlimentar)
    {
        if(estiloAlimentar == "Não")
        {
            if (_estiloAlimentar.Contains("Não"))
            {
                _estiloAlimentar.Remove(estiloAlimentar);
            }
            else
            {
                _estiloAlimentar.Clear();
                _estiloAlimentar.Add(estiloAlimentar);
            }
        }
        else
        {
            if (_estiloAlimentar.Contains("Não"))
            {
                _estiloAlimentar.Remove("Não");
            }
            if (_estiloAlimentar.Contains(estiloAlimentar))
            {
                _estiloAlimentar.Remove(estiloAlimentar);
            }
            else
            {
                _estiloAlimentar.Add(estiloAlimentar);
            }
        }
        AtualizarVisualBotoes();
    }
    private void AtualizarVisualBotoes()
    {
        var botoes = new List<Border> { btn_nao, btn_vegano, btn_vegetariano, btn_ovolactovegetariano, btn_ovovegetariano, btn_lactovegetariano, btn_pescetariano };
        foreach(var btn in botoes)
        {
            string id = btn.ClassId;
            if (_estiloAlimentar.Contains(id))
            {
                btn.BackgroundColor = _corSelecionada;
            }
            else
            {
                btn.BackgroundColor = _corTransparente;
            }
        }
    }

    private void BtnNao(object sender, TappedEventArgs e) => GerenciarSelecao(btn_nao.ClassId);

    private void BtnVegano(object sender, TappedEventArgs e) => GerenciarSelecao(btn_vegano.ClassId);

    private void BtnVegetariano(object sender, TappedEventArgs e) => GerenciarSelecao(btn_vegetariano.ClassId);

    private void BtnOvolactovegetariano(object sender, TappedEventArgs e) => GerenciarSelecao(btn_ovolactovegetariano.ClassId);

    private void BtnOvovegetariano(object sender, TappedEventArgs e) => GerenciarSelecao(btn_ovovegetariano.ClassId);
    private void BtnLactovegetariano(object sender, TappedEventArgs e) => GerenciarSelecao(btn_lactovegetariano.ClassId);

    private void BtnPescetariano(object sender, TappedEventArgs e) => GerenciarSelecao(btn_pescetariano.ClassId);

    private async void BtnCadastrarAlimetacao(object sender, EventArgs e)
    {
        if(_estiloAlimentar.Count == 0)
        {
            await DisplayAlert("Atenção", "Por favor, selecione uma opção ou 'Não' para continuar.", "Ok");
            return;
        }
        var usuarioTemp = RepositorioUsuarios.ObterUsuarioTemp();
        usuarioTemp.EstiloAlimentar = _estiloAlimentar;
        string estiloAlimentarEscolhido = string.Join(", ", usuarioTemp.EstiloAlimentar);
        string alergiaAlimentarEscolhida = string.Join(", ", usuarioTemp.AlergiasAlimentares);
        await DisplayAlert("Confirmação", $"Tem algum estilo alimentar: {estiloAlimentarEscolhido}", "OK");
        bool confirmacao = await DisplayAlert("Confirma o cadastro com os seguintes dados?", $"Alergia alimentar: {alergiaAlimentarEscolhida}\nEstilo alimentar: {estiloAlimentarEscolhido} ", "Sim", "Não");
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