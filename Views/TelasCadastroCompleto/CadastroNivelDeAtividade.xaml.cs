using AppFitShare.Repositories;

namespace AppFitShare.Views.TelasCadastroCompleto;

public partial class CadastroNivelDeAtividade : ContentPage
{

    private string _objetivoSelecionado = null;
    private Border _botaoSelecionado = null;

    public CadastroNivelDeAtividade()
	{
		InitializeComponent();
	}
    private async void CadastroObjetivo1Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CadastroNivelDeAtividade());
    }

    private void btnNivelAtividade(object sender, TappedEventArgs e)
    {

        if (sender is not Border botaoSelecionado) return;

        if (_botaoSelecionado != null)
        {
            ResetarBotao(_botaoSelecionado);
        }
        if (_botaoSelecionado == botaoSelecionado)
        {
            _botaoSelecionado = null;
            _objetivoSelecionado = "";
            ResetarBotao(botaoSelecionado);
            return;
        }

        SelecionarBotao(botaoSelecionado);
        _botaoSelecionado = botaoSelecionado;
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
    private async void btnAtualizarDados(object sender, EventArgs e)
    {
        try
        {

            var usuarioTemp = RepositorioUsuarios.ObterUsuarioTemp();

            if (string.IsNullOrEmpty(_objetivoSelecionado))
            {
                await DisplayAlert("Atenção", "Por favor, selecione um Nivel de Atividade para continuar.", "OK");
                return;
            }

            usuarioTemp.NivelAtividade = _objetivoSelecionado;
            RepositorioUsuarios.AtualizarUsuarioTemp(usuarioTemp);

            await DisplayAlert("Nivel de Atividade Selecionado", $"Você selecionou: {_objetivoSelecionado}", "OK");

            bool confirmacao = await DisplayAlert("Confirma o cadastro com os seguintes dados?", $"  Altura : {usuarioTemp.Altura}\n  Peso : {usuarioTemp.Peso}\n" +
                $"  Objetivo : {usuarioTemp.Objetivo1}\n  Nivel de Atividade : {usuarioTemp.NivelAtividade}  ", "Sim", "Não");
            if (confirmacao)
            {
                usuarioTemp.Status = "Ativo";
                usuarioTemp.CadastroSaude = true;
                RepositorioUsuarios.AtualizarUsuarioTemp(usuarioTemp);
                RepositorioUsuarios.SalvarUsuarioTemp();

                await DisplayAlert("Sucesso", "Cadastro das informações realizado com sucesso!", "Fechar");
                App.Current.MainPage = new NavigationPage(new TabbedPageMenu());
            }
            

        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops...", ex.Message, "Fechar");
        }
    }
    private async void BtnVoltar(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}