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

        foreach( var condicaoMedic in RepositorioSaudeCondicionamento.ObterCondicoesMedicasTemp())
        {
            switch (condicaoMedic)
            {
                case "Alergias respiratórias":
                    opt_alergias_respiratorias.IsVisible = true;
                    break;
                case "Asma":
                    opt_asma.IsVisible = true;
                    break;
                case "Arritmia":
                    opt_arritmia.IsVisible = true;
                    break;
                case "Artrite":
                    opt_artrite.IsVisible = true;
                    break;
                case "Artrose":
                    opt_artrose.IsVisible = true;
                    break;
                case "Bronquite crônica":
                    opt_bronquite_cronica.IsVisible = true;
                    break;
                case "Colesterol alto":
                    opt_colesterol_alto.IsVisible = true;
                    break;
                case "DPOC":
                    opt_DPOC.IsVisible = true;
                    break;
                case "Hipertensão":
                    opt_hipertensao.IsVisible = true;
                    break;
                case "Hipotensão":
                    opt_hipotensao.IsVisible = true;
                    break;
                case "Insuficiência cardíaca":
                    opt_insuficiencia_cardiaca.IsVisible = true;
                    break;
                case "Obesidade":
                    opt_obesidade.IsVisible = true;
                    break;
                case "Osteoporose":
                    opt_osteoporose.IsVisible = true;
                    break;
                case "Parkinson":
                    opt_parkinson.IsVisible = true;
                    break;
                case "Tendinite":
                    opt_tendinite.IsVisible = true;
                    break;
                case "Vertigem":
                    opt_vertigem.IsVisible = true;
                    break;
            }
        }


        foreach (var restricao in RepositorioSaudeCondicionamento.ObterRestricoesFisicasTemp())
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
            string condicaoMedica = string.Join(", ", RepositorioSaudeCondicionamento.ObterCondicoesMedicasTemp());
            string restricaoFisica = string.Join(", ", RepositorioSaudeCondicionamento.ObterRestricoesFisicasTemp());

           
            bool confirmacao = await DisplayAlert("Confirmação", $"Condição medica: {condicaoMedica} \nRestrição física: {restricaoFisica}", "Sim", "Não");
            if (confirmacao)
            {
                RepositorioUsuarios.AtualizarRestricoesFisicasTemp(RepositorioSaudeCondicionamento.ObterCondicoesMedicasTemp());
                RepositorioUsuarios.AtualizarCondicoesMedicas(RepositorioSaudeCondicionamento.ObterRestricoesFisicasTemp());
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
            RepositorioSaudeCondicionamento.RemoverRestricaoFisicaTemp(nome);
        }
    }

    private void BtnCancelarCondicaoFisica(object sender, EventArgs e)
    {
        var botao = sender as ImageButton;
        if (botao?.Parent?.Parent is Border border)
        {
            border.IsVisible = false;
            var nome = border.ClassId;
            RepositorioSaudeCondicionamento.RemoverCondicaoMedicaTemp(nome);
        }
    }
    private async void BtnVoltar(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}