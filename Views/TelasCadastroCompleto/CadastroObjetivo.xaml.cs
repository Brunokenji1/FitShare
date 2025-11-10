using AppFitShare.Repositories;

namespace AppFitShare.Views.TelasCadastroCompleto;

public partial class CadastroObjetivo : ContentPage
{

    private string _objetivoSelecionado = null;
    private Border _botaoSelecionado = null;

    public CadastroObjetivo()
    {
        InitializeComponent();
    }
    
    private async void CadastroObjetivo1Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CadastroNivelDeAtividade());
    }

    private void btnObjetivo1(object sender, TappedEventArgs e)
    {

        if (sender is not Border botaoSelecionado) return;

        if (_botaoSelecionado != null)
        {
            ResetarBotao(_botaoSelecionado);
        }
        if(_botaoSelecionado == botaoSelecionado)
        {
            _botaoSelecionado = null;
            _objetivoSelecionado = "";
            ResetarBotao(botaoSelecionado);
            return;
        }

        SelecionarBotao(botaoSelecionado);
        _botaoSelecionado =  botaoSelecionado;
        _objetivoSelecionado = botaoSelecionado.ClassId;

    }

    private void ResetarBotao(Border border)
    {
        border.BackgroundColor = Colors.Transparent;

    }
    private void SelecionarBotao(Border border)
    {
        border.BackgroundColor = Color.FromArgb("#01b853");
    }
    private async void btnContinuar(object sender, EventArgs e)
    {
        try
        {

            var usuarioTemp = RepositorioUsuarios.ObterUsuarioTemp();
            
            if (string.IsNullOrEmpty(_objetivoSelecionado))
            {
                await DisplayAlert("Atenção", "Por favor, selecione um objetivo para continuar.", "OK");
                return;
            }

            usuarioTemp.Objetivo1 = _objetivoSelecionado;
            RepositorioUsuarios.AtualizarUsuarioTemp(usuarioTemp);

            await DisplayAlert("Objetivo Selecionado", $"Você selecionou: {_objetivoSelecionado}", "OK");
            await Navigation.PushAsync(new CadastroSaudeCondicionamento());

        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops...", ex.Message, "Fechar");
        }
    }
}