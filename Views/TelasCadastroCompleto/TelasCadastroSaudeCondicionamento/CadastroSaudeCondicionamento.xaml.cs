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
        opt_dificuldade_para_caminhar.IsVisible = false;
        opt_dificuldade_para_ficar_em_pe.IsVisible = false;
        opt_dificuldade_para_levantar_peso.IsVisible = false;
        opt_dor_no_cotovelo.IsVisible = false;
        opt_dor_no_joelho.IsVisible = false;
        opt_dor_lombar.IsVisible = false;
        opt_escoliose.IsVisible = false;

        opt_fraqueza_nas_pernas.IsVisible = false;
        opt_hernia_de_disco.IsVisible = false;
        opt_instabilidade_ao_andar.IsVisible = false;
        opt_limitacao_no_ombro.IsVisible = false;
        opt_postura_curvada.IsVisible = false;
        opt_problemas_no_quadril.IsVisible = false;
        opt_tendinite_no_braco.IsVisible = false;

        foreach (var restricao in RepositorioUsuarios.RestricoesFisicasEscolhidasTemp)
        {
            switch (restricao)
            {
                case "Dificuldade para caminhar":
                    opt_dificuldade_para_caminhar.IsVisible = true;
                    break;
                case "Dificuldade para ficar em pé":
                    opt_dificuldade_para_ficar_em_pe.IsVisible = true;
                    break;
                case "Dificuldade para levantar peso":
                    opt_dificuldade_para_levantar_peso.IsVisible = true;
                    break;
                case "Dor no cotovelo":
                    opt_dor_no_cotovelo.IsVisible = true;
                    break;
                case "Dor no joelho":
                    opt_dor_no_joelho.IsVisible = true;
                    break;
                case "Dor Lombar":
                    opt_dor_lombar.IsVisible = true;
                    break;

                case "Escoliose":
                    opt_escoliose.IsVisible = true;
                    break;
                case "Fraqueza nas pernas":
                    opt_fraqueza_nas_pernas.IsVisible = true;
                    break;
                case "Hérnia de disco":
                    opt_hernia_de_disco.IsVisible = true;
                    break;
                case "Instabilidade ao andar":
                    opt_instabilidade_ao_andar.IsVisible = true;
                    break;
                case "Limitação no ombro":
                    opt_limitacao_no_ombro.IsVisible = true;
                    break;
                case "Postura curvada":
                    opt_postura_curvada.IsVisible = true;
                    break;
                case "Problemas no quadril":
                    opt_problemas_no_quadril.IsVisible = true;
                    break;
                case "Tendinite no braço":
                    opt_tendinite_no_braco.IsVisible = true;
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