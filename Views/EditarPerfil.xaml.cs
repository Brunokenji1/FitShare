using AppFitShare.Repositories;

namespace AppFitShare.Views;

public partial class EditarPerfil : ContentPage
{
	public EditarPerfil()
	{
		InitializeComponent();
        RepositorioUsuarios.IniciarUsuarioTemp();
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        var usuario = RepositorioUsuarios.ObterUsuarioTemp();

        if (usuario.Idade != null)
        {
            txt_idade.Text = $"{usuario.Idade}";
        }
        if (usuario.Altura != null)
        {
            txt_altura.Text = $"{usuario.Altura}";
        }
        if (usuario.Peso != null)
        {
            txt_peso.Text = $"{usuario.Peso}";
        }

        imgPerfil.Source = usuario.FotoPerfil;
    }
    private async void BtnContinuar(object sender, EventArgs e)
    {
        try
        {
            var usuarioTemp = RepositorioUsuarios.ObterUsuarioTemp();


            if (string.IsNullOrWhiteSpace(txt_idade.Text) ||
               string.IsNullOrWhiteSpace(txt_peso.Text) ||
               string.IsNullOrWhiteSpace(txt_altura.Text))
            {
                throw new Exception("Preencha todos os campos!");
            }
            usuarioTemp.Altura = double.Parse(txt_altura.Text);
            usuarioTemp.Idade = int.Parse(txt_idade.Text);
            usuarioTemp.Peso = double.Parse(txt_peso.Text);
            RepositorioUsuarios.AtualizarUsuarioTemp(usuarioTemp);
            bool confirmacao = await DisplayAlert("Confirma a edição dos seguintes dados?", $"  Altura : {usuarioTemp.Altura}\n  Peso : {usuarioTemp.Peso}\n" +
    $"  Idade : {usuarioTemp.Idade}  ", "Sim", "Não");
            if (confirmacao)
            {
                usuarioTemp.Status = "Ativo";
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

    private async void BtnSelecionarFoto(object sender, EventArgs e)
    {
        try
        {
            var foto = await MediaPicker.PickPhotoAsync();

            if (foto == null) return;

            var stream = await foto.OpenReadAsync();
            var imgSource = ImageSource.FromStream(() => stream);

            imgPerfil.Source = imgSource;
            imgPerfil.IsVisible = true;
            var usuario = RepositorioUsuarios.ObterUsuarioLogado();
            usuario.FotoPerfil = imgSource;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", ex.Message, "OK");
        }
    }
}