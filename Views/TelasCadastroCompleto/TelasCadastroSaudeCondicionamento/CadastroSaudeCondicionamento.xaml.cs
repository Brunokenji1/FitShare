using AppFitShare.Repositories;

namespace AppFitShare.Views.TelasCadastroCompleto;

public partial class CadastroSaudeCondicionamento : ContentPage
{
    private string _objetivoSelecionado = null;
	public CadastroSaudeCondicionamento()
	{
		InitializeComponent();
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        artrose_quadril_ou_ombro.IsVisible = false;
        cirurgia_recente.IsVisible = false;
        dificuldade_de_coordenacao_motora.IsVisible = false;
        dores_cronicasNasCostas.IsVisible = false;
        dor_lombar.IsVisible = false;
        problema_falta_de_ar.IsVisible = false;
        falta_de_equilibrio.IsVisible = false;
        fraqueza_muscular_localizada.IsVisible = false;
        lesao_manguito_rotador.IsVisible = false;
        pressao_alta.IsVisible = false;
        problema_cardiaco.IsVisible = false;
        tonturas_frequentes.IsVisible = false;

        foreach (var restricao in RepositorioUsuarios.RestricoesFisicasEscolhidasTemp)
        {
            switch (restricao)
            {
                case "Artrose no Quadril ou Ombro":
                    artrose_quadril_ou_ombro.IsVisible = true;
                    break;
                case "Cirurgia Recente":
                    cirurgia_recente.IsVisible = true;
                    break;
                case "Dificuldade de Coordenação Motora":
                    dificuldade_de_coordenacao_motora.IsVisible = true;
                    break;
                case "Dores Crônicas nas Costas":
                    dores_cronicasNasCostas.IsVisible = true;
                    break;
                case "Dor Lombar":
                    dor_lombar.IsVisible = true;
                    break;
                case "Problema de Falta de Ar":
                    problema_falta_de_ar.IsVisible = true;
                    break;
                case "Falta de Equilíbrio":
                    falta_de_equilibrio.IsVisible = true;
                    break;
                case "Fraqueza Muscular Localizada":
                    fraqueza_muscular_localizada.IsVisible = true;
                    break;
                case "Lesão no Manguito Rotador":
                    lesao_manguito_rotador.IsVisible = true;
                    break;
                case "Pressão Alta":
                    pressao_alta.IsVisible = true;
                    break;
                case "Problema Cardíaco":
                    problema_cardiaco.IsVisible = true;
                    break;
                case "Tonturas Frequentes":
                    tonturas_frequentes.IsVisible = true;
                    break;
            }
        }

    }
    private async void BtnContinuar(object sender, EventArgs e)
    {
        try
        {
            var usuarioTemp = RepositorioUsuarios.ObterUsuarioTemp();

            bool confirmacao = await DisplayAlert("Confirmação", "Cadastrar informações de saúde e condicionamento", "Sim", "Não");
            if (confirmacao)
            {
                RepositorioUsuarios.AtualizarRestricoesFisicasTemp(RepositorioUsuarios.RestricoesFisicasEscolhidasTemp);
                await DisplayAlert("Sucesso", "Cadastro realizado com sucesso!", "Fechar");

                await Navigation.PushAsync(new CadastroNivelDeAtividade());
            }

            
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops...", ex.Message, "Fechar");
        }

    }



    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CadastroCondicoesMedicas());
    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CadastroRestricaoFisica());
    }

    private void ImageButton_Clicked(object sender, EventArgs e)
    {
        var botao = sender as ImageButton;

        if (botao?.Parent?.Parent is Border border)
        {
            border.IsVisible = false;
            var nome = border.ClassId;
            RepositorioUsuarios.RestricoesFisicasEscolhidasTemp.Remove(nome);
        }
    }
}